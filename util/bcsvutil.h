#ifndef BCSVUTIL_H
#define BCSVUTIL_H

#include "fmt/bcsv.h"

#include <QVariant>

namespace BCSVUtil
{
    template<typename T>
    T GetValue(BCSV::Entry* e, quint32 name_hash)
    {
        if (e->ContainsKey(name_hash))
            return (e->GetValue(name_hash).value<T>());

        return 0;
    }

    template<typename T>
    T GetValue(BCSV::Entry* e, QString name)
    {
        quint32 name_hash = BCSV::FieldNameToHash(name);

        if (e->ContainsKey(name_hash))
            return (e->GetValue(name_hash).value<T>());

        return 0;
    }
};

#endif // BCSVUTIL_H
