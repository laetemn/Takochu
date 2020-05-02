#include "mainwindow.h"
#include "ui_mainwindow.h"

#include "fmt/bcsv.h"
#include "fs/externalfilesystem.h"
#include "fs/rarcfilesystem.h"
#include "io/yaz0stream.h"
#include "util/bcsvutil.h"
#include "util/settingsmgr.h"

#include <QDebug>
#include <QFileDialog>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);

    SettingsMgr::Initialize();
    qDebug() << SettingsMgr::Get()->GetValue("LastPath");
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_pushButton_clicked()
{
    SettingsMgr::Get()->SetValue("LastPath", QFileDialog::getExistingDirectory(this, tr("Choose SMG1/2 Extracted Folder"), ".", QFileDialog::ReadOnly) + "/");
    ExternalFilesystem::SetPath(SettingsMgr::Get()->GetValue("LastPath").value<QString>());

    Yaz0Stream* strm = new Yaz0Stream(ExternalFilesystem::OpenFile("StageData/IslandFleetGalaxy/IslandFleetGalaxyMap.arc"));
    BinaryStream* rdr = new BinaryStream(strm->GetDecompressedData());
    RARCFilesystem* rarc = new RARCFilesystem(rdr);
    RARCFileEntry* e = rarc->OpenFile("/Stage/jmp/Start/LayerB/StartInfo");
    QByteArray* buf = rarc->GetFile(e);

    BinaryStream* butts = new BinaryStream(*buf);
    BCSV* b = new BCSV(butts);

    foreach(BCSV::Entry* e, b->mEntries)
    {
        qDebug() << BCSVUtil::GetValue<float>(e, "pos_x");
    }
}
