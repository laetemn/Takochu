﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Takochu.io;

namespace Takochu.fmt
{
    public class BCSV
    {
        public BCSV(FileBase file)
        {
            mFile = file;

            mFields = new Dictionary<uint, Field>();
            mEntries = new List<Entry>();

            if (mFile.GetLength() == 0)
            {
                return;
            }

            int entryCount = mFile.ReadInt32();
            int fieldCount = mFile.ReadInt32();
            int dataOffs = mFile.ReadInt32();
            int entryDataSize = mFile.ReadInt32();

            int stringTableOffs = (dataOffs + (entryCount * entryDataSize));

            for (int i = 0; i < fieldCount; i++)
            {
                Field f = new Field();
                mFile.Seek(0x10 + (0xC * i));

                f.mHash = mFile.ReadUInt32();
                f.mMask = mFile.ReadUInt32();
                f.mEntryOffset = mFile.ReadUInt16();
                f.mShiftAmount = mFile.ReadByte();
                f.mType = mFile.ReadByte();

                string fieldName = HashToFieldName(f.mHash);
                f.mName = fieldName;
                mFields.Add(f.mHash, f);
            }

            for (int i = 0; i < entryCount; i++)
            {
                Entry e = new Entry();

                foreach (Field f in mFields.Values)
                {
                    mFile.Seek(dataOffs + (i * entryDataSize) + f.mEntryOffset);

                    object val = null;

                    switch (f.mType)
                    {
                        case 0:
                        case 3:
                            val = Convert.ToUInt32((mFile.ReadUInt32() & f.mMask) >> f.mShiftAmount);
                            break;

                        case 4:
                            val = Convert.ToUInt16((mFile.ReadUInt16() & f.mMask) >> f.mShiftAmount);
                            break;

                        case 5:
                            val = Convert.ToByte((mFile.ReadByte() & f.mMask) >> f.mShiftAmount);
                            break;

                        case 2:
                            val = mFile.ReadSingle();
                            break;

                        case 6:
                            int offs = mFile.ReadInt32();
                            mFile.Seek(stringTableOffs + offs);
                            val = mFile.ReadString();
                            break;

                        default:
                            throw new Exception($"BCSV::BCSV() - Unknown field type {f.mType}.");
                    }

                    e[f.mHash] = val;
                }

                mEntries.Add(e);
            }
        }

        public void Save()
        {
            int[] dataSizes = { 4, -1, 4, 4, 2, 1, 4 };
            int entrySize = 0;

            foreach (Field f in mFields.Values)
            {
                short end = Convert.ToInt16(f.mEntryOffset + dataSizes[f.mType]);
                if (end > entrySize)
                    entrySize = end;
            }

            entrySize = ((entrySize + 3) & ~3);

            int dataOffs = (0x10 + (0xC * mFields.Count));
            int strTableOffs = (dataOffs + (mEntries.Count * entrySize));
            int curStr = 0;

            mFile.SetLength(strTableOffs);
            mFile.Seek(0);
            mFile.Write(mEntries.Count);
            mFile.Write(mFields.Count);
            mFile.Write(dataOffs);
            mFile.Write(entrySize);

            foreach(Field f in mFields.Values)
            {
                mFile.Write(f.mHash);
                mFile.Write(f.mMask);
                mFile.Write(f.mEntryOffset);
                mFile.Write(f.mShiftAmount);
                mFile.Write(f.mType);
            }

            int i = 0;
            Dictionary<string, int> stringOffsets = new Dictionary<string, int>();

            foreach(Entry e in mEntries)
            {
                foreach(Field f in mFields.Values)
                {
                    int valOffs = (dataOffs + (i * entrySize) + f.mEntryOffset);
                    mFile.Seek(valOffs);

                    switch(f.mType)
                    {
                        case 0:
                        case 3:
                            {
                                uint val = mFile.ReadUInt32();
                                val &= f.mMask;
                                val |= ((uint)e[f.mHash] << f.mShiftAmount) & f.mMask;

                                mFile.Seek(valOffs);
                                mFile.Write(val);
                                break;
                            }

                        case 4:
                            {
                                short val = mFile.ReadInt16();
                                val &= (short)f.mMask;
                                val |= (short)(((short)e[f.mHash] << f.mShiftAmount) & f.mMask);

                                mFile.Seek(valOffs);
                                mFile.Write(val);
                                break;
                            }

                        case 5:
                            {
                                byte val = mFile.ReadByte();
                                val &= (byte)f.mMask;
                                val |= (byte)(((byte)e[f.mHash] << f.mShiftAmount) & f.mMask);

                                mFile.Seek(valOffs);
                                mFile.Write(val);
                                break;
                            }

                        case 2:
                            mFile.Write((float)e[f.mHash]);
                            break;

                        case 6:
                            {
                                string val = (string)e[f.mHash];
                                if (stringOffsets.ContainsKey(val))
                                    mFile.Write(stringOffsets[val]);
                                else
                                {
                                    stringOffsets.Add(val, curStr);
                                    mFile.Write(curStr);
                                    mFile.Seek(strTableOffs + curStr);
                                    mFile.WriteStringNT(val);
                                    curStr += val.Length + 1;
                                }

                                break;
                            }
                    }
                }

                i++;
            }

            i = mFile.GetLength();
            mFile.Seek(i);
            int align = (i + 0x1F) & ~0x1F;

            for (; i < align; i++)
            {
                mFile.Write((byte)0x40);
            }

            mFile.Save();
        }

        public void Close()
        {
            mFile.Close();
        }

        public Field AddField(string name, int offs, int type, uint mask, int shift, object val)
        {
            int[] sizes = { 4, -1, 4, 4, 2, 1, 4 };
            AddHash(name);

            if (type == 2 || type == 6)
            {
                mask = 0xFFFFFFFF;
                shift = 0;
            }

            if (offs == -1)
            {
                foreach(Field fe in mFields.Values)
                {
                    short end = Convert.ToInt16(fe.mEntryOffset + sizes[fe.mType]);
                    if (end > offs)
                        offs = end;
                }
            }

            Field f = new Field();
            f.mName = name;
            f.mHash = FieldNameToHash(name);
            f.mMask = (uint)mask;
            f.mShiftAmount = (byte)shift;
            f.mType = (byte)type;
            f.mEntryOffset = (ushort)offs;
            mFields.Add(f.mHash, f);

            foreach(Entry e in mEntries)
            {
                e.Set(name, val);
            }

            return f;
        }

        public void RemoveField(string name)
        {
            uint hash = FieldNameToHash(name);
            mFields.Remove(hash);

            foreach (Entry e in mEntries)
            {
                e.Remove(hash);
            }
        }

        public class Field
        {
            public uint mHash;
            public uint mMask;
            public ushort mEntryOffset;
            public byte mShiftAmount;
            public byte mType;

            public string mName;
        }

        public class Entry : Dictionary<uint, object>
        {
            public Entry() : base() { }

            public object Get(string key)
            {
                return this[FieldNameToHash(key)];
            }

            public void Set(string key, object val)
            {
                this[FieldNameToHash(key)] = val;
            }

            public bool ContainsKey(string key)
            {
                return this.ContainsKey(FieldNameToHash(key));
            }
        }

        public static uint FieldNameToHash(string name)
        {
            uint ret = 0;

            foreach (char c in name.ToCharArray())
            {
                ret *= 0x1F;
                ret += c;
            }

            return ret;
        }

        public static string HashToFieldName(uint hash)
        {
            if (!sHashTable.ContainsKey(hash))
                return String.Format($"[{hash.ToString("X").ToUpper()}]");

            return sHashTable[hash];
        }

        public static void AddHash(string field)
        {
            uint hash = FieldNameToHash(field);

            if (!sHashTable.ContainsKey(hash))
                sHashTable.Add(hash, field);
        }

        public static void PopulateHashTable()
        {
            sHashTable = new Dictionary<uint, string>();

            string[] lines = File.ReadAllLines("res/FieldNames.txt");

            foreach(string line in lines)
            {
                AddHash(line);
            }
        }

        private FileBase mFile;
        public Dictionary<uint, Field> mFields;
        public List<Entry> mEntries;


        public static Dictionary<uint, string> sHashTable;
    }
}
