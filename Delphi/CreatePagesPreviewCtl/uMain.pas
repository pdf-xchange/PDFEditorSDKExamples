unit uMain;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, PDFXEdit_TLB, ActiveX, Vcl.StdCtrls;

type
  TfrmMain = class(TForm)
    Button1: TButton;
    FileOpenDialog1: TFileOpenDialog;
    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure Button1Click(Sender: TObject);
  private
    Inst: PXV_Inst;
    InstUIX: IUIX_Inst;
    //InstAUX: IAUX_Inst;
  public
    { Public declarations }
  end;

var
  frmMain: tfrmmain;

implementation

{$R *.dfm}

uses Unit2;

procedure TfrmMain.Button1Click(Sender: TObject);
var
  f2 : TForm2;
begin
  if (FileOpenDialog1.Execute) then
  begin
    f2 := TForm2.Create(Application);
    f2.LoadInst(Inst, InstUIX);
    f2.OpenDocument(FileOpenDialog1.FileName);
    f2.Show;
  end;
end;

procedure TfrmMain.FormCreate(Sender: TObject);
begin
  Inst := CoPXV_Inst.Create();
  Inst.Init(nil, '', nil, nil, nil, 0, nil);
  InstUIX := Inst.GetExtension('UIX')as IUIX_Inst;
end;

procedure TfrmMain.FormDestroy(Sender: TObject);
begin
  InstUIX := nil;
  Inst.Shutdown(0);
end;

end.
