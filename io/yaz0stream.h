#ifndef YAZ0STREAM_H
#define YAZ0STREAM_H

#include "io/binarystream.h"

class Yaz0Stream
{
public:
    Yaz0Stream(BinaryStream* s);

    QByteArray GetDecompressedData() const
    {
        return mDecompressedData;
    }

private:
    QByteArray mDecompressedData;
};

#endif // YAZ0STREAM_H
