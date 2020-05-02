#ifndef RARCFILESYSTEM_H
#define RARCFILESYSTEM_H

#include <QMap>
#include <QString>

#include "io/binarystream.h"

class RARCFileEntry;

class RARCFilesystem
{
public:
    RARCFilesystem(BinaryStream* s);
    ~RARCFilesystem();

    RARCFileEntry* OpenFile(QString name);
    QByteArray* GetFile(RARCFileEntry* entry) const;
    QList<QString> GetAllNames() const;

    struct FileEntry
    {
        quint32 mEntryOffset;
        quint32 mEntryID;
        quint32 mNameOffset;
        quint32 mDataOffset;
        quint32 mDataSize;
        quint32 mParentDirID;
        QString mName;
        QString mFullName;
    };

    struct DirectoryEntry
    {
        quint32 mEntryOffset;
        quint32 mEntryID;
        quint32 mNameOffset;
        quint32 mParentDirID;
        QString mName;
        QString mFullName;
    };

private:
    QMap<quint32, FileEntry*> mFileEntries;
    QMap<quint32, DirectoryEntry*> mDirectoryEntries;

    quint32 mFileDataOffset;
    quint32 mDirectoryNodeCount;
    quint32 mDirectoryNodesOffset;
    quint32 mFileEntriesOffset;
    quint32 mStringTableOffset;

    BinaryStream* mStream;

};

class RARCFileEntry
{
public:
    RARCFileEntry(RARCFilesystem* filesystem, quint32 fileID);

    RARCFilesystem* mFS;
    quint32 mID;

    QByteArray* mFileData;
};

#endif // RARCFILESYSTEM_H
