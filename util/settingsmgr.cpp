#include "settingsmgr.h"

#include <QApplication>
#include <QDir>
#include <QFileInfo>
#include <QStandardPaths>

SettingsMgr* SettingsMgr::sInstance = NULL;

SettingsMgr::SettingsMgr()
{
    QFileInfo localDir(QCoreApplication::applicationDirPath() + "/data");

    if (localDir.isDir() && localDir.isReadable())
    {
        mBasePath = localDir.absoluteFilePath();
    }
    else
    {
        mBasePath = QStandardPaths::writableLocation(QStandardPaths::AppDataLocation) + "/data";
        QDir().mkpath(mBasePath);
    }
}

SettingsMgr* SettingsMgr::Initialize()
{
    QCoreApplication::setOrganizationName("bonerville");
    QCoreApplication::setApplicationName("Takochu");

    if (SettingsMgr::sInstance != NULL)
        throw new std::exception("settings instance has already been intialized!");

    sInstance = new SettingsMgr();
    return sInstance;
}

QVariant SettingsMgr::GetValue(const QString key, const QVariant dValue) const
{
    return mSettings.value(key, dValue);
}

void SettingsMgr::SetValue(const QString key, const QVariant value)
{
    mSettings.setValue(key, value);
}
