#include "bcsv.h"

#include <QDebug>
#include <QFile>
#include <QTextStream>

QMap<quint32, QString> BCSV::sHashes = BCSV::GetHashTable();

BCSV::BCSV(BinaryStream* s)
{
    quint32 entryCount = s->ReadU32();
    quint32 fieldCount = s->ReadU32();
    quint32 dataOffset = s->ReadU32();
    quint32 entryDataSize = s->ReadU32();

    quint32 stringTableOffset = (dataOffset + (entryCount * entryDataSize));

    for (quint32 i = 0; i < fieldCount; i++)
    {
        Field* field = new Field();
        s->Seek(0x10 + (0xC * i));
        field->mNameHash = s->ReadU32();
        field->mMask = s->ReadU32();
        field->mEntryOffset = s->ReadU16();
        field->mShiftAmount = s->ReadU8();
        field->mFieldType = s->ReadU8();

        QString name = BCSV::HashToFieldName(field->mNameHash);
        field->mName = name;

        mFields.insert(field->mNameHash, field);
    }

    for (quint32 i = 0; i < entryCount; i++)
    {
        Entry* e = new Entry();

        foreach (Field* f, mFields.values())
        {
            s->Seek(dataOffset + (i * entryDataSize) + f->mEntryOffset);

            QVariant val = 0;

            switch (f->mFieldType)
            {
                case 0:
                case 3:
                    val = static_cast<quint32>((s->ReadU32() & f->mMask) >> f->mShiftAmount);
                    break;

                case 2:
                    val = s->ReadSingle();
                    break;

                case 4:
                    val = static_cast<quint16>((s->ReadU16() & f->mMask) >> f->mShiftAmount);
                    break;

                case 5:
                    val = static_cast<quint8>((s->ReadU8() & f->mMask) >> f->mShiftAmount);
                    break;

                case 6:
                    s->Seek(stringTableOffset + s->ReadU32());
                    val = s->ReadStringNT();
                    break;
            }

            e->Add(f->mNameHash, val);
        }

        mEntries.append(e);
    }
}

quint32 BCSV::FieldNameToHash(QString str)
{
    quint32 ret = 0;

    for (QChar c : str)
    {
        ret *= 0x1F;
        ret += c.toLatin1();
    }

    return ret;
}

QString BCSV::HashToFieldName(quint32 hash)
{
    if (BCSV::sHashes.contains(hash))
    {
        return BCSV::sHashes[hash];
    }

    return "";
}

QMap<quint32, QString> BCSV::GetHashTable()
{
    QMap<quint32, QString> map{};

    QFile f("res/hashes.txt");

    if (f.open(QIODevice::ReadOnly))
    {
        QTextStream s(&f);

        while (!s.atEnd())
        {
            QString line = s.readLine();
            map.insert(BCSV::FieldNameToHash(line), line);
        }
    }

    return map;
}

QVariant BCSV::Entry::GetValue(quint32 name) const
{
    return mMap[name];
}

void BCSV::Entry::Add(quint32 name, QVariant value)
{
    mMap.insert(name, value);
}

bool BCSV::Entry::ContainsKey(quint32 key) const
{
    return mMap.contains(key);
}
