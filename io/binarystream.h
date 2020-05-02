#ifndef BINARYSTREAM_H
#define BINARYSTREAM_H

#include <QDataStream>
#include <QFile>

class BinaryStream : QDataStream
{
public:
    BinaryStream(QString path, QDataStream::ByteOrder = QDataStream::BigEndian);
    BinaryStream(QByteArray arr, QDataStream::ByteOrder = QDataStream::BigEndian);
    ~BinaryStream();

    quint8 ReadU8();
    quint16 ReadU16();
    quint32 ReadU32();

    qint8 ReadS8();
    qint16 ReadS16();
    qint32 ReadS32();

    float ReadSingle();
    double ReadDouble();
    bool ReadBoolean();

    QString ReadString(quint32 len);
    QString ReadStringNT();

    void ReadBytes(quint32 length, QByteArray* buffer);

    quint64 Pos() const;
    bool Seek(quint64 where);
    void Skip(quint64 len);
    quint64 Size() const;
    bool IsAtEOF() const;
    void Close();

    bool mIsReadOnly = false;
};

#endif // BINARYSTREAM_H
