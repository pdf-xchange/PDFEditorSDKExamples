unit untMain;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants,
  System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, System.Actions, Vcl.ActnList, Vcl.Menus,
  PDFXEdit_TLB, Vcl.OleServer, Vcl.OleCtrls, Vcl.StdActns;

type
  TForm1 = class(TForm)
    PXV_Control1: TPXV_Control;
    MainMenu1: TMainMenu;
    ActionList1: TActionList;
    FileOpenDialog1: TFileOpenDialog;
    File1: TMenuItem;
    FileExit1: TFileExit;
    Exit1: TMenuItem;
    N1: TMenuItem;
    FileOpen1: TFileOpen;
    Open2: TMenuItem;
    actVerifyPageLinks: TAction;
    VerifyPageLinks1: TMenuItem;
    Tool1: TMenuItem;
    Doc: TMenuItem;
    insertPage: TAction;
    deletePage: TAction;
    insertPage1: TMenuItem;
    deletePage1: TMenuItem;
    About: TAction;
    Help1: TMenuItem;
    About1: TMenuItem;
    actCertTest: TAction;
    CertTest1: TMenuItem;
    actGetContent: TAction;
    GetContent1: TMenuItem;
    actGotoPage: TAction;
    actGotoPage1: TMenuItem;
    procedure FileOpen1Accept(Sender: TObject);
    procedure actVerifyPageLinksExecute(Sender: TObject);
    procedure insertPageExecute(Sender: TObject);
    procedure deletePageExecute(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure AboutExecute(Sender: TObject);
    procedure actCertTestExecute(Sender: TObject);
    procedure actGetContentExecute(Sender: TObject);
    procedure actGotoPageExecute(Sender: TObject);
    procedure PXV_Control1Event(ASender: TObject; nEventID: Integer;
      const pEvent: IEvent; const pFrom: IInterface);
    procedure FormCreate(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
  private
    { Private declarations }
    e_beforeShowContextMenu: Integer;
    procedure RegisterEvents(bRegister: Boolean);
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

uses
  About, PDFInst;

const
  licKeyDEMO: string  =
    'dEmOk4WZ3uxwI/9oEZODemogFi61n61nNVt6UTzu16hUPvDEmots7yE5IUcd4Z+NvMgQzdQ1' +
    '7lAG3IrDeMogTpzOfxzKsRfNQRD9UqkyyZx6sYwPrDtnWzndqSV/zSl+0QpJ5b8QtdemOBsq' +
    '8511v3l+sgec6JExR944vi35DEMOGC1GOsXDd9LzSU/Eg9TY/Y3yctxyh5UA9ljIWviQ9W4T' +
    'OzDmaiyv5giyCPYwO2HyZdemoa3fi8zpvOy2EeYgWvfPSGjRqxlCT1a0wBxpNe4QB5R6tr+X' +
    'qR9JPV/p8DJ4vRqDDsDEMOX4xm/iXP3fdz/1KQs/elwMqwtUUrJYjzvDu7AwBpWEQ9so04ZO' +
    'baGYL3C6N/oaKioFL+0d7cyEA+2+/CdEMoelQKDEVqvEUxatrMJsD6yald01Cd1DA1eq7Tt1' +
    'b3vn58E2dEMobiBmg4qkdOpLtjcYxh69t3BVtKxmu6uyXZd+gO0NZxHkQT+6/U1334DEMO+H' +
    '"oou1/TmICS9GS6p+nfTQLZpButSOkGfaT7V17n6NkTvSKwLtrwDEMO==';

  strBeforeShowContextMenu:string = 'e.beforeShowContextMenu';

procedure TForm1.AboutExecute(Sender: TObject);
begin
  AboutBox.Parent := Self;
  AboutBox.ShowModal;
end;

procedure TForm1.actCertTestExecute(Sender: TObject);
begin
  gInst.SignDocument(PXV_Control1.Doc.CoreDoc);
end;

procedure TForm1.actGetContentExecute(Sender: TObject);
begin
  ShowMessage(gInst.GetContent(PXV_Control1.Doc, 0));
end;

procedure TForm1.actGotoPageExecute(Sender: TObject);
begin
  gInst.GotoPage(PXV_Control1, 1);
end;

procedure TForm1.actVerifyPageLinksExecute(Sender: TObject);
var
  GoTo1, GoToR, Launch, invalidCount: Cardinal;
  i, j, k: Cardinal;
  annotsCount: Cardinal;
  aCount: Cardinal;
  actionCount: Cardinal;
  nType: Cardinal;
  bValid: WordBool;
  strPath: WideString;

  page: PDFXEdit_TLB.IPXC_Page;
  annot: PDFXEdit_TLB.IPXC_Annotation;
  Actions: PDFXEdit_TLB.IPXC_ActionsList;
  actionGoTo: PDFXEdit_TLB.IPXC_Action_Goto;
  path: PDFXEdit_TLB.IPXC_FileSpec;
  pxsInst: PDFXEdit_TLB.IPXS_Inst;
  actionLaunch: PDFXEdit_TLB.IPXC_Action_Launch;
  action: PDFXEdit_TLB.IPXC_Action;
begin
  if (PXV_Control1.Doc = nil) then
    exit;
  pxsInst := PDFXEdit_TLB.IPXS_Inst(PXV_Control1.Inst.GetExtension('PXS'));
  GoTo1 := pxsInst.StrToAtom('GoTo');
  GoToR := pxsInst.StrToAtom('GoToR');
  Launch := pxsInst.StrToAtom('Launch');
  invalidCount := 0;
  PXV_Control1.Doc.CoreDoc.Pages.Get_Count(aCount);
  for i := 1 to aCount do
  begin
    PXV_Control1.Doc.CoreDoc.Pages.Get_Item(i - 1, page);
    page.GetAnnotsCount(annotsCount);
    for j := 1 to annotsCount do
    begin
      page.GetAnnot(j - 1, annot);
      if (Assigned(annot)) then
        annot.get_Actions(PDFXEdit_TLB.Trigger_Up, Actions);
      if Assigned(Actions) then
      begin
        Actions.Get_Count(actionCount);
        for k := 1 to actionCount do
        begin
          Actions.Get_Item(k - 1, action);
          action.Get_type_(nType);

          if ((nType = GoTo1) or (nType = GoToR)) then
          begin
            actionGoTo := PDFXEdit_TLB.IPXC_Action_Goto(action);
            actionGoTo.Get_IsValid(bValid);
            if (bValid = false) then
            begin
              inc(invalidCount);
            end
            else if (nType = GoToR) then
            begin
              actionGoTo.Get_Target(path);
              path.Get_DIPath(strPath);
              if (FileExists(strPath) = false) then
                inc(invalidCount);
            end;
          end
          else if (nType = Launch) then
          begin
            actionLaunch := PDFXEdit_TLB.IPXC_Action_Launch(action);
            actionLaunch.Get_IsValid(bValid);
            if (bValid = false) then
            begin
              inc(invalidCount);
            end
            else
            begin
              actionLaunch.Get_FileSpec(path);
              if (path = nil) then
              begin
                actionLaunch.Get_FileName(strPath);
                if (FileExists(strPath) = false) then
                  inc(invalidCount);
              end
              else
              begin
                path.Get_DIPath(strPath);
                if (FileExists(strPath) = false) then
                  inc(invalidCount);
              end;
            end;
          end;
        end;
      end;
    end;
  end;
end;

procedure TForm1.deletePageExecute(Sender: TObject);
begin
  gInst.deletePages(PXV_Control1.Doc, 1, 1);
end;

procedure TForm1.FileOpen1Accept(Sender: TObject);
var
  i: integer;
begin
  for i := 0 to FileOpen1.Dialog.Files.Count - 1 do
    PXV_Control1.OpenDocFromPath(FileOpen1.Dialog.Files[i], nil);
end;


procedure TForm1.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  RegisterEvents(False);
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  e_beforeShowContextMenu := PXV_Control1.Inst.Str2ID(strBeforeShowContextMenu, false);
end;

procedure TForm1.FormShow(Sender: TObject);
var
  inst: PDFXEdit_TLB.IPXV_Inst;
begin
	PXV_Control1.SetLicKey(licKeyDEMO);

  inst := PXV_Control1.Inst;
  gInst.Init(inst);

  RegisterEvents(True);
end;

procedure TForm1.insertPageExecute(Sender: TObject);
begin
  //
  gInst.InsertEmptyPage(PXV_Control1.Doc, 0, 1);
end;

procedure TForm1.PXV_Control1Event(ASender: TObject; nEventID: Integer;
  const pEvent: IEvent; const pFrom: IInterface);
begin
  if nEventID = e_beforeShowContextMenu then
  begin
    ShowMessage('ContextMenu');
  end;
end;

procedure TForm1.RegisterEvents(bRegister: Boolean);
begin
  PXV_Control1.EnableEventListening(strBeforeShowContextMenu, bRegister);
end;

end.
