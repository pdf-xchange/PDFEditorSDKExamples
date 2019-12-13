#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#if defined _M_X64
#define Api_File "PDFXEditCore.x64.dll"
#else
#define Api_File "PDFXEditCore.x86.dll"
#endif

#pragma warning(push)
#pragma warning(disable:4192 4278)
#import Api_File rename_namespace("PXV"), raw_interfaces_only, exclude("LONG_PTR", "ULONG_PTR", "UINT_PTR")
#pragma warning(pop)

#include <QMainWindow>

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

private:
    Ui::MainWindow *ui;
};

#endif // MAINWINDOW_H
