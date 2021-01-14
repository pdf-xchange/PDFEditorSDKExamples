unit untMain;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants,
  System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, System.Actions, Vcl.ActnList, Vcl.Menus,
  PDFXEdit_TLB, Vcl.OleServer, Vcl.OleCtrls, Vcl.StdActns, Vcl.StdCtrls;

type
  TForm1 = class(TForm)
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
    PXV_Control1: TPXV_Control;
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
    procedure actGotoExecute(Sender: TObject);
    procedure ImagesToDoc1Click(Sender: TObject);
    procedure actDrawImageExecute(Sender: TObject);
    procedure actSetZoomExecute(Sender: TObject);
    procedure actInsertPagesExecute(Sender: TObject);
  private
    { Private declarations }
    e_beforeShowContextMenu: Integer;
    procedure RegisterEvents(bRegister: Boolean);
    procedure ImageToDocEx(AInputFile, AOutputFile: String);
    procedure BmpToImage(const bmp: TBitmap; var Img: PDFXEdit_TLB.IIXC_Page);
    procedure ImageToBmp(const Img: PDFXEdit_TLB.IIXC_Page; var bmp: TBitmap);
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

uses
  About, PDFInst, System.Math, SXC_40;

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


type
   TTrackerScanLib = class
   public
    FImg: IIXC_Page;
    INST_IXC: PDFXEdit_TLB.IIXC_Inst;
    function CreateTwainObject: Boolean;
  private
    FIsProcessing: Boolean;
    procedure DoOnGetData(pData: pointer; DataSize: LongWord);
    function DibToPage(HDib: Cardinal): IIXC_Page;
   end;



procedure TForm1.AboutExecute(Sender: TObject);
begin
  AboutBox.Parent := Self;
  AboutBox.ShowModal;
end;

procedure TForm1.actCertTestExecute(Sender: TObject);
begin
  gInst.SignDocument(PXV_Control1.Doc.CoreDoc);
end;

procedure TForm1.actDrawImageExecute(Sender: TObject);
var
  bmp: TBitmap;
  ImgPage: PDFXEdit_TLB.IIXC_Page;
  Scan: TTrackerScanLib;
begin
  bmp := TBitmap.Create;
  try
    bmp.LoadFromFile('z:\\Project\\Delphi\\cat_banjo.bmp');
    BmpToImage(bmp, ImgPage);
  finally
    FreeAndNil(bmp);
  end;

  bmp := TBitmap.Create();
  try
    Scan := TTrackerScanLib.Create;
    Scan.INST_IXC := PXV_Control1.Inst.GetExtension('IXC') as PDFXEdit_TLB.IIXC_Inst;
    Scan.CreateTwainObject;
    ImageToBmp(Scan.FImg, bmp);
    bmp.SaveToFile('z:\\Project\\Delphi\\test1.bmp');

    ImageToBmp(ImgPage, bmp);
    bmp.SaveToFile('z:\\Project\\Delphi\\test2.bmp');
  finally
    FreeAndNil(bmp);
  end;
end;

procedure TForm1.ImageToBmp(const Img: PDFXEdit_TLB.IIXC_Page; var bmp: TBitmap);
var
  nWidth, nHeight: Cardinal;
Begin
  img.Get_Width(nWidth);
  img.Get_Height(nHeight);
  bmp.SetSize(nWidth, nHeight);
  img.DrawToDC(bmp.Canvas.Handle, 0, 0, nWidth, nHeight, 0, 0, 0);
End;
procedure TForm1.BmpToImage(const bmp: TBitmap; var Img: PDFXEdit_TLB.IIXC_Page);
var
  iInst: PDFXEdit_TLB.IIXC_Inst;
Begin
  Assert(bmp.HandleType = bmDIB);
  iInst := PXV_Control1.Inst.GetExtension('IXC') as PDFXEdit_TLB.IIXC_Inst;
  iInst.Page_CreateFromHBITMAP(bmp.Handle,0, Img);
End;


procedure GetData(userData: LongWord; pData: pointer; DataSize: LongWord); stdcall;
begin
  if (userData <> 0 ) and Assigned(TTrackerScanLib(userData)) then
  begin
    TTrackerScanLib(userData).DoOnGetData(pData, DataSize);
  end;
end;

procedure TTrackerScanLib.DoOnGetData(pData: pointer; DataSize: LongWord);
var
  HDib: Cardinal;
begin
  //pData seems to be freed by Tracker
  FIsProcessing := Assigned(pData) and (DataSize > 0);
  if FIsProcessing then
  begin
    HDib := Cardinal(pData);
    FImg := DibToPage(HDib);
  end;
end;


function TTrackerScanLib.DibToPage(HDib: Cardinal): IIXC_Page;
var
  pData: Pointer;
  pHeader: PBITMAPINFOHEADER;
  PalSize, Height, Width, DataSize: LongWord;
  MemType: IXC_MemoryType;
  NumColors: Integer;
  pPalette: PLongWord;
  Offset, xDPI, yDPI: Integer;
  pDataForCodex: PByte;
begin
  Result := nil;
  PalSize := 0;
  MemType := MemoryType_1bpp;
  NumColors := 0;
  pPalette := nil;
  Offset := 0;
  pDataForCodex := nil;

  GlobalLock(HDib);
  try
    pData := Pointer(HDib);
    pHeader := PBITMAPINFOHEADER(pData);

    case pHeader.biBitCount of
      1:
      begin
        NumColors := 2;
        PalSize := 2;
        MemType := MemoryType_1bpp;
      end;
      4:
      begin
        if (pHeader.biClrUsed <> 0) then
        begin
          NumColors := pHeader.biClrUsed;
          PalSize := pHeader.biClrUsed;
        end else
        begin
          NumColors := 16;
          PalSize := 16;
        end;
        if (pHeader.biCompression = BI_RLE4) then MemType := MemoryType_4RLE else MemType := MemoryType_4bpp;
      end;
      8:
      begin
        if (pHeader.biClrUsed <> 0) then
        begin
          NumColors := pHeader.biClrUsed;
          PalSize := pHeader.biClrUsed;
        end else
        begin
          NumColors := 256;
          PalSize := 256;
        end;
        if (pHeader.biCompression = BI_RLE8) then MemType := MemoryType_8RLE else MemType := MemoryType_8bpp;
      end;
      16, 24, 32:
      begin
        if (pHeader.biCompression = BI_BITFIELDS) then
        begin
          PalSize := 3;
        end else
        begin
          if (pHeader.biClrUsed <> 0) then PalSize := pHeader.biClrUsed;
        end;

        case pHeader.biBitCount of
          16: MemType := MemoryType_16bpp;
          24: MemType := MemoryType_24bpp;
          32: MemType := MemoryType_32bpp;
        end;
      end;
    end;

    PalSize := PalSize * SizeOf(RGBQUAD);
    if (NumColors <> 0) then pPalette := PLongWord(Integer(pData) + SizeOf(BITMAPINFOHEADER));

    pDataForCodex := PByte(Integer(pData) + SizeOf(BITMAPINFOHEADER) + PalSize);
    Offset := Floor(((pHeader.biBitCount * pHeader.biWidth) + 31) / 32) * 4;

    if (pHeader.biHeight < 0) and (pHeader.biCompression <> BI_RLE8) and (pHeader.biCompression <> BI_RLE4) then
    begin
      pDataForCodex := pDataForCodex + (-pHeader.biHeight - 1) * Offset;
      Offset := -Offset;
    end;

    Width := pHeader.biWidth;
    Height := Abs(pHeader.biHeight);
    DataSize := pHeader.biSizeImage + SizeOf(BITMAPINFOHEADER) + PalSize;


    INST_IXC.Page_CreateFromMemory(Width, Height, MemType, NumColors, pPalette^, pDataForCodex^, Offset, DataSize - (SizeOf(BITMAPINFOHEADER) + PalSize), 0, Result);


    if Assigned(Result) and (pHeader.biXPelsPerMeter <> 0) and (pHeader.biYPelsPerMeter <> 0) then
    begin
      xDPI := MulDiv(pHeader.biXPelsPerMeter, 254, 10000);
      yDPI := MulDiv(pHeader.biYPelsPerMeter, 254, 10000);

      Result.Set_FmtInt(FP_ID_XDPI, xDPI);
      Result.Set_FmtInt(FP_ID_YDPI, yDPI);
    end;
  finally
    GlobalUnlock(HDib);
  end;
end;

function TTrackerScanLib.CreateTwainObject: Boolean;
var
  UnlockKey, DevKey: string;
  hr: HRESULT;
  FRegKey: AnsiString;
  FDevCode: AnsiString;
  FErrorStr: string;
  FTwain: pointer;
begin
  Result := False;
  if Assigned(FTwain) then
  begin
    Result := True;
    exit;
  end;

  FTwain := SXC_CreateTwainObject(FRegKey, FDevCode);
  if not Assigned(FTwain) then
  begin
    FErrorStr := 'Could not create Twain Object';
    exit;
  end;

  hr := SXC_InitTwain(FTwain);
  if not IsError(hr) then
  begin
    SXC_SetProc(FTwain, GetData, Integer(Self));
    Result := True;

    SXC_SelectSourceGUI(FTwain);

    SXC_EnableSource(FTwain,GetActiveWindow(), true);
  end;

end;

procedure TForm1.actGetContentExecute(Sender: TObject);
begin
  ShowMessage(gInst.GetContent(PXV_Control1.Doc, 0));
end;

procedure TForm1.actGotoExecute(Sender: TObject);
var
  pxsInst: PDFXEdit_TLB.IPXS_Inst;
  GoTo1, GoToR, Launch: ULONG_T;
  i, j, k: integer;
  aCount, annotsCount, invalidCount, actionCount, nType: ULONG_T;
  page: PDFXEdit_TLB.IPXC_Page;
  annot: PDFXEdit_TLB.IPXC_Annotation;
  Actions: PDFXEdit_TLB.IPXC_ActionsList;
  actionGoTo: PDFXEdit_TLB.IPXC_Action_Goto;
  bValid: WordBool;
  path: PDFXEdit_TLB.IPXC_FileSpec;
  strPath: WideString;
  action: PDFXEdit_TLB.IPXC_Action;
begin
  if (PXV_Control1.Doc = nil) then
    exit;
  Memo1.Lines.Clear;
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
              Memo1.Lines.Add('Page #'+IntToStr(i)+ ' - annotation index #'+ inttostr(j)+ ': ' +strPath);
              if (FileExists(strPath) = false) then
                inc(invalidCount);
            end;
          end
        end;
      end;
    end;
  end;
end;

procedure TForm1.actGotoPageExecute(Sender: TObject);
begin
  gInst.GotoPage(PXV_Control1, 1);
end;

procedure TForm1.actInsertPagesExecute(Sender: TObject);
begin
//  PXV_Control1.Frame.View.DocViewsArea.DocViews.Item[0];
  gInst.PDF_InsertPages( PXV_Control1.Frame.View.DocViewsArea.DocViews.Item[1].Doc,
                          PXV_Control1.Frame.View.DocViewsArea.DocViews.Item[0].Doc, '', '', -1, false);

  gInst.PDF_InsertPages( PXV_Control1.Frame.View.DocViewsArea.DocViews.Item[0].Doc,
                          PXV_Control1.Frame.View.DocViewsArea.DocViews.Item[1].Doc, '', '', -1, false);
  //gInst.PDF_InsertPages( PXV_Control1.Doc, nil, 'z:\Project\Numbers.pdf', '', 0, false);
  //gInst.PDF_InsertPages( PXV_Control1.Doc, nil, 'z:\Project\fileInfo.pdf', '', 0, false);
//  gInst.PDF_InsertPages( PXV_Control1.Doc, nil, 'z:\Project\356h.pdf', '', 0, false);
end;

procedure TForm1.actSetZoomExecute(Sender: TObject);
var
  evtID, objID: integer;
  evt: PDFXEdit_TLB.IEvent;
begin
  gInst.EnableSmallIcon(False);

{
  evtID := PXV_Control1.Inst.Str2ID('e.document.propsChanged', false);
  evt := PXV_Control1.Inst.EventServer.CreateNewEvent(evtID, PARAM_T(PXV_Control1.Doc), PDFXEdit_TLB.DocViewFlag_DisplayDocTitle);
  PXV_Control1.Inst.EventServer.FireEvent(evt, PXV_Control1.Doc);

  evtID := PXV_Control1.Inst.Str2ID('e.cmdCustomization', false);
  objID := PXV_Control1.Inst.Str2ID('mainView', false);
  evt := PXV_Control1.Inst.EventServer.CreateNewEvent(evtID, objID, $FFFF);
  PXV_Control1.Inst.EventServer.FireEvent(evt, PXV_Control1.Inst);
}

  //PXV_Control1.SetZoom(0, 200, true);
  //PXV_Control1.ZoomLevel := 200;
  //ShowMessage(Format('Zoom %f', [PXV_Control1.ZoomLevel]));
  //PXV_Control1.Inst.Settings['CustomUI.Colors'].Add(dt_Undefined).v := RGB(255, 255, 255);
  //PXV_Control1.
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
  evtID, objID: integer;
  evt: PDFXEdit_TLB.IEvent;
begin
	PXV_Control1.SetLicKey(licKeyDEMO);

  inst := PXV_Control1.Inst;
  gInst.Init(inst);
  ShowMessage('Start DBG');
  gInst.EnableSmallIcon(False);
  RegisterEvents(True);
  PXV_Control1.VisibleCmdPanes := 3;

//  evtID := PXV_Control1.Inst.Str2ID('e.cmdCustomization', false);
//  evt := PXV_Control1.Inst.EventServer.CreateNewEvent(evtID, PARAM_T(PXV_Control1.Doc), PDFXEdit_TLB.DocViewFlag_DisplayDocTitle);
//  PXV_Control1.Inst.EventServer.FireEvent(evt, PXV_Control1.Doc);

//    evtID := PXV_Control1.Inst.Str2ID('e.cmdCustomization', false);
//    objID := PXV_Control1.Inst.Str2ID('mainView', false);
//    evt := PXV_Control1.Inst.EventServer.CreateNewEvent(evtID, objID, UIX_CmdCustomized_Commands);
//    PXV_Control1.Inst.EventServer.FireEvent(evt, PXV_Control1.Inst);

  for objID := 0 to _PXV_AppPrefsChange_Max_ - 1 do
    PXV_Control1.Inst.FireAppPrefsChanged(objID, nil);
end;

procedure TForm1.ImagesToDoc1Click(Sender: TObject);
begin
  ImageToDocEx('z:\Project\Image\PDFCompare\lorry.png','z:\Project\rez.pdf');
end;

procedure TForm1.ImageToDocEx(AInputFile, AOutputFile: String);
var
  nID: integer;
  pOp: IOperation;
  output: ICabNode;
  input: ICabNode;
  new: ICabNode;
  options: ICabNode;
  imgPath: IAFS_Name;
  ATargetDoc: IPXC_Document;

  pxsInst: PDFXEdit_TLB.IPXS_Inst;
begin
  //pxsInst := PDFXEdit_TLB.IPXS_Inst(PXV_Control1.Inst.GetExtension('PXS'));


  nID := gInst.FInst.Str2ID('op.imagesToDoc', False);
  pOp := gInst.FInst.CreateOp(nID);

  imgPath := gInst.FInstFS.DefaultFileSys.StringToName(PChar(AInputFile), 0, nil);
  input := pOp.Params.Root['Input'];
  input.Add(dt_IUnknown).v := imgPath;

  options := pOp.Params.Root['Options'];
  options['KeepAspect'].v := True;

  pOp.Do_(0);

  output := pOp.Params.Root['Output'];

  try
    output.Unknown.QueryInterface(IID_IPXC_Document, ATargetDoc);
    //ATargetDoc :=  as IPXC_Document;

    ATargetDoc.WriteToFile(PChar(AOutputFile), nil, 0);
  finally

  end;
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
