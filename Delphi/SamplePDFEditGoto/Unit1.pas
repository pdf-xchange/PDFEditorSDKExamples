unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.ComCtrls, Vcl.ToolWin, Vcl.OleCtrls,
  PDFXEdit_TLB;

type
  TForm1 = class(TForm)
    ToolBar1: TToolBar;
    ToolButton1: TToolButton;
    PXV_Control1: TPXV_Control;
    ToolButton2: TToolButton;
    FileOpenDialog1: TFileOpenDialog;
    procedure ToolButton2Click(Sender: TObject);
    procedure ToolButton1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.ToolButton1Click(Sender: TObject);
const
  nPageNumber = 1;
var
  APage: IPXC_Page;
  rc: PXC_Rect;
  dest: PXC_Destination;
begin
  PXV_Control1.Doc.CoreDoc.Pages.Get_Item(nPageNumber, APage);
  APage.Get_Box(PDFXEdit_TLB.PBox_PageBox, rc);
  dest.nType := PDFXEdit_TLB.Dest_XYZ;
  dest.dValues[0] := rc.left + 10;
  dest.dValues[1] := rc.top - 100;
  dest.nNullFlags := 12;
  dest.nPageNum := nPageNumber;
  PXV_Control1.GoToDestination(dest, nPageNumber);
end;

procedure TForm1.ToolButton2Click(Sender: TObject);
var
  i: integer;
begin
  if (FileOpenDialog1.Execute) then
  Begin
    for i := 0 to FileOpenDialog1.Files.Count - 1 do
      PXV_Control1.OpenDocFromPath(FileOpenDialog1.Files[i], nil);
  End;
end;

end.
