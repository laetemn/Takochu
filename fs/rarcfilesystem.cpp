#include "rarcfilesystem.h"

#include <QDebug>

RARCFilesystem::RARCFilesystem(BinaryStream* s)
{
    if (s->ReadString(4) != "RARC")
    {
        throw new std::exception("File is not a RARC!");
    }

    s->Seek(0xC);
    mFileDataOffset = s->ReadU32() + 0x20;
    s->Seek(0x20);
    mDirectoryNodeCount = s->ReadU32();
    mDirectoryNodesOffset = s->ReadU32() + 0x20;
    s->Skip(0x4);
    mFileEntriesOffset = s->ReadU32() + 0x20;
    s->Skip(0x4);
    mStringTableOffset = s->ReadU32() + 0x20;

    DirectoryEntry* rootNode = new DirectoryEntry();
    rootNode->mEntryID = 0;
    rootNode->mParentDirID = 0xFFFFFFFF;

    s->Seek(mDirectoryNodesOffset + 0x6);
    quint32 rootNodeOffset = s->ReadU16();
    s->Seek(mStringTableOffset + rootNodeOffset);
    rootNode->mName = s->ReadStringNT();
    rootNode->mFullName = "/" + rootNode->mName;
    mDirectoryEntries.insert(0, rootNode);

    for (quint32 i = 0; i < mDirectoryNodeCount; i++)
    {
        DirectoryEntry* e = mDirectoryEntries[i];
        s->Seek(mDirectoryNodesOffset + (i * 0x10) + 10);
        quint16 numEntries = s->ReadU16();
        quint32 firstEntry = s->ReadU32();

        for (quint32 j = 0; j < numEntries; j++)
        {
            quint32 entryOffset = mFileEntriesOffset + ((j + firstEntry) * 0x14);
            s->Seek(entryOffset);

            quint16 id = s->ReadU16();
            s->Skip(0x4);
            quint16 nameOffset = s->ReadU16();
            quint32 dataOffset = s->ReadU32();
            quint32 dataSize = s->ReadU32();

            s->Seek(mStringTableOffset + nameOffset);
            QString name = s->ReadStringNT();

            if (name == "." || name == "..")
                continue;

            QString fullName = e->mFullName + "/" + name;

            if (id == 0xFFFF)
            {
                DirectoryEntry* dir = new DirectoryEntry();
                dir->mEntryOffset = entryOffset;
                dir->mEntryID = dataOffset;
                dir->mParentDirID = i;
                dir->mNameOffset = nameOffset;
                dir->mName = name;
                dir->mFullName = fullName;

                mDirectoryEntries.insert(dataOffset, dir);
            }
            else
            {
                FileEntry* file = new FileEntry();
                file->mEntryOffset = entryOffset;
                file->mEntryID = id;
                file->mParentDirID = i;
                file->mNameOffset = nameOffset;
                file->mDataOffset = dataOffset;
                file->mDataSize = dataSize;
                file->mName = name;
                file->mFullName = fullName;

                mFileEntries.insert(id, file);
            }
        }
    }

    mStream = s;
}

RARCFilesystem::~RARCFilesystem()
{
    if (mStream)
    {
        delete mStream;
    }
}

RARCFileEntry* RARCFilesystem::OpenFile(QString name)
{
    QList<FileEntry*> vals = mFileEntries.values();

    foreach(FileEntry* entry, vals)
    {
        if (entry->mFullName == name)
        {
            qDebug() << "Successfully found" << name;
            return new RARCFileEntry(this, entry->mEntryID);
        }
    }

    qDebug() << "Failed to get file" << name;
    return nullptr;
}

QByteArray* RARCFilesystem::GetFile(RARCFileEntry* entry) const
{
    QByteArray* arr = new QByteArray();

    FileEntry* e = mFileEntries[entry->mID];
    mStream->Seek(mFileDataOffset + e->mDataOffset);
    mStream->ReadBytes(e->mDataSize, arr);
    return arr;
}

QList<QString> RARCFilesystem::GetAllNames() const
{
    QList<QString> list;

    QList<FileEntry*> vals = mFileEntries.values();

    foreach(FileEntry* entry, vals)
    {
        list.append(entry->mFullName);
    }

    return list;
}

RARCFileEntry::RARCFileEntry(RARCFilesystem* fs, quint32 id)
{
    mFS = fs;
    mID = id;
}
