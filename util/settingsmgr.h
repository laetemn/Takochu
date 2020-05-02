#ifndef SETTINGSMGR_H
#define SETTINGSMGR_H

#include "fs/externalfilesystem.h"

#include <QObject>
#include <QSettings>

class SettingsMgr : public QObject
{
    Q_OBJECT
public:
    SettingsMgr();

    static SettingsMgr* Initialize();
    static SettingsMgr* Get()
    {
        return sInstance;
    }

    QVariant GetValue(const QString key, const QVariant dValue = QVariant()) const;
    void SetValue(const QString key, const QVariant value);

private:
    static SettingsMgr* sInstance;

    QSettings mSettings;
    QString mBasePath;
};

#endif // SETTINGSMGR_H
