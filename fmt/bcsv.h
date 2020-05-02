#ifndef BCSV_H
#define BCSV_H

#include <QObject>
#include <QMap>

#include "io/binarystream.h"

class BCSV
{
public:
    BCSV(BinaryStream *);

    class Entry
    {
    public:
        QVariant GetValue(quint32 name) const;
        void Add(quint32 name, QVariant val);
        bool ContainsKey(quint32 key) const;

        QMap<quint32, QVariant> mMap;
    };

    class Field
    {
    public:
        quint32 mNameHash;
        quint32 mMask;
        quint16 mEntryOffset;
        quint8 mShiftAmount;
        quint8 mFieldType;
        QString mName;
    };

    QMap<quint32, Field*> mFields;
    QList<Entry*> mEntries;

    static quint32 FieldNameToHash(QString);
    static QString HashToFieldName(quint32);
    static QMap<quint32, QString> GetHashTable();

    static QMap<quint32, QString> sHashes;
};

#endif // BCSV_H
