#ifndef EXTERNALFILESYSTEM_H
#define EXTERNALFILESYSTEM_H

#include <QDir>
#include <QFileInfo>
#include <QString>

#include "io/binarystream.h"

class ExternalFilesystem
{
public:
    static void SetPath(QString path);

    static bool DoesFileExist(QString filePath);
    static bool DoesDirectoryExist(QString dirPath);
    static QStringList GetDirsFromDir(QString dir);
    static QStringList GetFilesFromDir(QString dir);
    static BinaryStream* OpenFile(QString file, QDataStream::ByteOrder = QDataStream::BigEndian);

    static QString mPath;

    static QStringList GetListFromDir(QString dir, QDir::Filter f)
    {
        return QDir(mPath + dir).entryList(f);
    }
};

#endif // EXTERNALFILESYSTEM_H
