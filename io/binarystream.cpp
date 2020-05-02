#include "binarystream.h"

#include <QDebug>

BinaryStream::BinaryStream(QString path, QDataStream::ByteOrder bo) : QDataStream(new QFile(path))
{
    if (!device()->open(QIODevice::ReadWrite))
    {
        if (device()->open(QIODevice::ReadOnly))
        {
            mIsReadOnly = true;
        }
    }

    setFloatingPointPrecision(QDataStream::DoublePrecision);
    setByteOrder(bo);
}

BinaryStream::BinaryStream(QByteArray arr, QDataStream::ByteOrder bo) : QDataStream(arr)
{
    setFloatingPointPrecision(QDataStream::SinglePrecision);
    setByteOrder(bo);
}

BinaryStream::~BinaryStream()
{
    if (device()->isOpen())
    {
        device()->close();
    }

    delete device();
}

quint8 BinaryStream::ReadU8()
{
    quint8 ret;
    *this >> ret;
    return ret;
}

quint16 BinaryStream::ReadU16()
{
    quint16 ret;
    *this >> ret;
    return ret;
}

quint32 BinaryStream::ReadU32()
{
    quint32 ret;
    *this >> ret;
    return ret;
}

qint8 BinaryStream::ReadS8()
{
    qint8 ret;
    *this >> ret;
    return ret;
}

qint16 BinaryStream::ReadS16()
{
    qint16 ret;
    *this >> ret;
    return ret;
}

qint32 BinaryStream::ReadS32()
{
    qint32 ret;
    *this >> ret;
    return ret;
}

float BinaryStream::ReadSingle()
{
    float ret;
    *this >> ret;
    return ret;
}

double BinaryStream::ReadDouble()
{
    double ret;
    *this >> ret;
    return ret;
}

bool BinaryStream::ReadBoolean()
{
    bool ret;
    *this >> ret;
    return ret;
}

QString BinaryStream::ReadString(quint32 len)
{
    QString str;

    for (quint32 i = 0; i < len; i++)
        str += QChar(ReadU8());

    return str;
}

QString BinaryStream::ReadStringNT()
{
    QString str;
    quint8 cur;

    do
    {
        cur = ReadU8();

        if (cur == 0)
            break;
        str += QChar(cur);
    }
    while (cur != 0);

    return str;
}

void BinaryStream::ReadBytes(quint32 length, QByteArray* arr)
{
    for (quint32 i = 0; i < length; i++)
    {
        quint8 derp = ReadU8();
        arr->append(derp);
    }
}

quint64 BinaryStream::Pos() const
{
    return device()->pos();
}

bool BinaryStream::Seek(quint64 where)
{
    return device()->seek(where);
}

void BinaryStream::Skip(quint64 len)
{
    Seek(Pos() + len);
}

quint64 BinaryStream::Size() const
{
    return device()->size();
}

bool BinaryStream::IsAtEOF() const
{
    return atEnd();
}

void BinaryStream::Close()
{
    device()->close();
}
