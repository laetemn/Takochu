#include "yaz0stream.h"

#include <QDebug>

Yaz0Stream::Yaz0Stream(BinaryStream* s)
{
    if (s->ReadString(4) != "Yaz0")
    {
        throw new std::exception("Invalid Yaz0!");
    }

    quint32 decompressedSize = s->ReadU32();
    s->Skip(0x8);

    QByteArray data(decompressedSize / 2, 0);

    quint32 outPos = 0;

    while (outPos < decompressedSize)
    {
        quint8 block = s->ReadU8();

        for (quint32 i = 0; i < 8; i++)
        {
            if ((block & 0x80) != 0)
            {
                data.insert(outPos++, s->ReadU8());
            }
            else
            {
                quint8 b1 = s->ReadU8();
                quint8 b2 = s->ReadU8();

                qint32 dist = ((b1 & 0xF) << 8) | b2;
                qint32 copySrc = outPos - (dist + 1);

                qint32 nbytes = b1 >> 4;
                if (nbytes == 0)
                {
                    nbytes = s->ReadU8() + 0x12;
                }
                else
                {
                    nbytes += 2;
                }

                for (qint32 j = 0; j < nbytes; j++)
                {
                    data.insert(outPos++, data.at(copySrc++));
                }
            }

            block <<= 1;

            if (outPos >= decompressedSize || s->Pos() >= s->Size())
                break;
        }
    }

    mDecompressedData = data;
}
