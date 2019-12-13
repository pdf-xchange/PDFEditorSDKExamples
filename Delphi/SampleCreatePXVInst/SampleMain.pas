unit SampleMain;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, PDFXEdit_TLB, Vcl.StdCtrls, ActiveX;

type
  TForm1 = class(TForm)
    Label1: TLabel;
    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
  private
    { Private declarations }
    FInst: PDFXEdit_TLB.IPXV_Inst;
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

{ TForm1 }



procedure TForm1.FormCreate(Sender: TObject);
begin
  FInst := CoPXV_Inst.Create();
  ////uses PDFXEdit_TLB
  FInst.Init(nil, '', nil, nil, nil, 0, nil);
  //uses ActiveX
  //CoCreateInstance(CLASS_PXV_Inst, nil, CLSCTX_INPROC_SERVER, IPXV_Inst, FInst);
  Label1.Caption := FInst.GetLocalStr2(42);
end;

procedure TForm1.FormDestroy(Sender: TObject);
begin
  FInst.Shutdown(0);
end;

end.
