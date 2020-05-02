#include "externalfilesystem.h"

#include "io/binarystream.h"

#include <QDebug>

QString ExternalFilesystem::mPath = "";

void ExternalFilesystem::SetPath(QString path)
{
    mPath = path;
    qDebug() << "Sucessfully set filesystem root to" << path;
}

bool ExternalFilesystem::DoesFileExist(QString filePath)
{
    return QFileInfo(mPath + filePath).exists();
}

bool ExternalFilesystem::DoesDirectoryExist(QString dirPath)
{
    return QDir(mPath + dirPath).exists();
}

QStringList ExternalFilesystem::GetDirsFromDir(QString dir)
{
    return GetListFromDir(dir, QDir::Dirs);
}

QStringList ExternalFilesystem::GetFilesFromDir(QString dir)
{
    return GetListFromDir(dir, QDir::Files);
}

BinaryStream* ExternalFilesystem::OpenFile(QString file, QDataStream::ByteOrder bo)
{
    if (DoesFileExist(file))
    {
        return new BinaryStream(mPath + file, bo);
    }

    qDebug() << "File " << file << " not found.";
    return nullptr;
}
