unit Unit2;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, PDFXEdit_TLB, ActiveX;

type
  TForm2 = class(TForm)
    procedure FormResize(Sender: TObject);
  private
    FInst: IPXV_Inst;
    FDoc: IPXC_Document;
  public
    { Public declarations }
    ppc : IPXV_PagesPreviewCtl;
    container : IUIX_Obj;

    procedure LoadInst(inst: IPXV_Inst; InstUIX: IUIX_Inst);
    procedure OpenDocument(fileName: string); overload;
    procedure OpenDocument(doc: IPXC_Document); overload;
  end;

var
  Form2: TForm2;

implementation

{$R *.dfm}

procedure TForm2.loadinst(inst: IPXV_Inst; InstUIX: IUIX_Inst);
var
  cop : UIX_CreateObjParams;
  rc: tagRECT;
begin
  FInst := inst;
  rc.left := ClientRect.Left;
  rc.right := ClientRect.Right;
  rc.top := ClientRect.Top;
  rc.bottom := ClientRect.Bottom;

  ZeroMemory(@cop, SizeOf(UIX_CreateObjParams));
  cop.hWndParent := Handle;
  cop.nStdClass := UIX_StdClass_Blank;
  //cop.nCreateFlags := UIX_CreateObj_Windowed;
  //cop.nWndStyle := WS_CHILD OR WS_CLIPCHILDREN OR WS_CLIPSIBLINGS;
  cop.rc := rc;

  container := InstUIX.CreateObj(cop);
  ppc := Inst.CreatePagesPreviewCtl(container, rc, 'preview',
    PXV_PagesPreviewStyle_NoHandTool or PXV_PagesPreviewStyle_NonInertialHand or PXV_PagesPreviewStyle_InteractiveLayout,
    UIX_ScrollStyle_Horz or UIX_ScrollStyle_Vert,  false);
end;

procedure TForm2.OpenDocument(doc: IPXC_Document);
begin
  ppc.Doc := doc;
end;

procedure TForm2.OpenDocument(fileName: string);
var
  nID: Integer;
  Op: IOperation;
  fsInst: IAFS_Inst;
begin
  nID := FInst.Str2ID('op.openDoc', false);
  Op := FInst.CreateOp(nID);
  fsInst := FInst.GetExtension('AFS') as IAFS_Inst;
  Op.Params.Root['Input'].v := fsInst.DefaultFileSys.StringToName(PWChar(fileName), 0, nil);
  Op.Params.Root['Options.NativeOnly'].v := true;
  Op.Do_(0);

  if (FDoc <> nil) then
  begin
    FDoc.Close(0);
    FDoc := nil;
  end;

  FDoc := Op.Params.Root['Output'].Unknown as IPXC_Document;
  OpenDocument(FDoc);
end;

procedure TForm2.FormResize(Sender: TObject);
var
  rc: tagRECT;
begin
  rc.left := ClientRect.Left;
  rc.right := ClientRect.Right;
  rc.top := ClientRect.Top;
  rc.bottom := ClientRect.Bottom;
  if ppc <> nil then
  begin
    container.Set_Rect(@rc);
    ppc.Obj.Parent.Set_Rect(@rc);
  end;
end;



end.
