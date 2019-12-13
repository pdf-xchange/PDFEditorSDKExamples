unit PDFInst;

interface

uses
  System.SysUtils, PDFXEdit_TLB, Soap.Win.CertHelper, Math;

type
  TInst = class
  private
    { private declarations }
  protected
    { protected declarations }
  public
    { public declarations }
    FInst: PDFXEdit_TLB.IPXV_Inst;
    FInstCore: PDFXEdit_TLB.IPXC_Inst;
    FInstFS: PDFXEdit_TLB.IAFS_Inst;
    FInstAUX: IAUX_Inst;
    INST_UIX: PDFXEdit_TLB.IUIX_Inst;

    constructor Create;
    destructor Destroy; override;

    procedure Init(inst: PDFXEdit_TLB.IPXV_Inst);
    procedure InsertEmptyPage(doc: PDFXEdit_TLB.IPXV_Document; nPage: integer;
      nCount: integer);
    procedure DeletePages(doc: PDFXEdit_TLB.IPXV_Document;
      nPageStart, nPageStop: integer);

    procedure InsertPagesTest();

    function PDF_InsertPages(ADoc, ASrcDoc: IPXV_Document; ASrcFileName,
      ASrcPagesAsCommaText: String; ABeforeIndex: Integer;
      ADeleteSource: Boolean): Boolean;

    procedure SignDocument(doc: PDFXEdit_TLB.IPXC_Document);
    function GetContent(doc: PDFXEdit_TLB.IPXV_Document; nPage: Cardinal)
      : WideString;
    procedure GotoPage(pdfCtl: TPXV_Control; nPageNumber: Cardinal = 1);
    procedure EnableSmallIcon(AEnable: Boolean);

  published
    { published declarations }
  end;

var
  gInst: TInst;

implementation

uses
  Vcl.Dialogs;
{ TInst }

constructor TInst.Create;
begin
  inherited;
  FInst := nil;
end;

destructor TInst.Destroy;
begin
  FInst := nil;
  inherited;
end;

procedure TInst.EnableSmallIcon(AEnable: Boolean);
var
  cmds: IUIX_CmdCollection;
  cmd: IUIX_Cmd;
  i, cnt: integer;
begin
  //FInst.LockCmdCustomizationEvent();

  cmds := INST_UIX.CmdManager.cmds;
  cnt := cmds.Count;
  for i := 0 to cnt - 1 do
  begin
    cmd := cmds[i];
    // cmd.Offline := True;
    //cmd.Set_NewItemStyle(UIX_CmdItemStyle_HideIcon or UIX_CmdItemStyle_HideTitle);
    //cmd.Set_NewItemStyleMaskEU($FFFFFF);

    cmd.NewItemStyle := cmd.NewItemStyle or (UIX_CmdItemStyle_HideTitle);
    cmd.NewItemStyleMaskEU := cmd.NewItemStyleMaskEU or (UIX_CmdItemStyle_HideTitle);
    // INST_UIX.CmdManager.UpdateCmdItems(UIX_CmdItemUpdate_Title, cmd.ID);
    cmd := nil;
    //INST_UIX.CmdManager.UpdateCmdItems(UIX_CmdItemUpdate_All, i);
  end;
  //FInst.UnlockCmdCustomizationEvent();

  FInst.ActiveMainView.CmdPaneTop.Item[1].BarSize := UIX_CmdBarSize_Normal;
end;

function TInst.GetContent(doc: PDFXEdit_TLB.IPXV_Document; nPage: Cardinal)
  : WideString;
var
  APage: IPXC_Page;
  AContent: IPXC_Content;
  AContentItems: IPXC_ContentItems;
  ACItem: IPXC_ContentItem;
  ACount: Cardinal;
  i: integer;
  AType: PXC_CIType;
  ALen: Cardinal;
  AByte: PByte;
  ABufByte: TBytes;
  AText: WideString;
begin
  doc.CoreDoc.Pages.Get_Item(nPage, APage);
  APage.GetContent(CAccessMode_Readonly, AContent);
  // APage.GetText();
  AContent.Get_Items(AContentItems);
  AContentItems.Get_Count(ACount);
  for i := 1 to ACount do
  begin
    AContentItems.Get_ItemType(i - 1, AType);
    // For example we will take all of the text items
    if (AType = CIT_Text) then
    begin
      AContentItems.Get_Item(i - 1, ACItem);
      ACItem.Text_GetTextLen(ALen);
      GetMem(AByte, ALen);
      try
        ACItem.Text_GetData(AByte[0], ALen);
        AText := TEncoding.BigEndianUnicode.GetString
          (TBytes(@AByte[0]), 0, ALen);
        // AText := TEncoding.Default.GetString(TBytes(@AByte[0]), 0, ALen);
      finally
        FreeMem(AByte);
      end;
      Result := Result + ' ' + AText;
    end;
  end;
end;

procedure TInst.GotoPage(pdfCtl: TPXV_Control; nPageNumber: Cardinal);
var
  APage: IPXC_Page;
  rc: PXC_Rect;
  dest: PXC_Destination;
begin
  pdfCtl.doc.CoreDoc.Pages.Get_Item(nPageNumber, APage);
  APage.Get_Box(PDFXEdit_TLB.PBox_PageBox, rc);
  dest.nType := PDFXEdit_TLB.Dest_XYZ;
  dest.dValues[0] := rc.left + 10;
  dest.dValues[1] := rc.top - 100;
  dest.nNullFlags := 12;
  dest.nPageNum := nPageNumber;
  pdfCtl.GoToDestination(dest, nPageNumber);
end;

procedure TInst.Init(inst: PDFXEdit_TLB.IPXV_Inst);
begin
  FInst := inst;
  FInstCore := FInst.GetExtension('PXC') as PDFXEdit_TLB.IPXC_Inst;
  FInstAUX := FInstCore.GetExtension('AUX') as IAUX_Inst;
  FInstFS := FInstCore.GetExtension('AFS') as IAFS_Inst;
  INST_UIX := FInst.GetExtension('UIX') as IUIX_Inst;

end;

procedure TInst.DeletePages(doc: PDFXEdit_TLB.IPXV_Document;
  nPageStart, nPageStop: integer);
var
  nID: integer;
  pOp: PDFXEdit_TLB.IOperation;
  input: PDFXEdit_TLB.ICabNode;
  options: PDFXEdit_TLB.ICabNode;
begin
  nID := FInst.Str2ID('op.document.deletePages', false);
  pOp := FInst.CreateOp(nID);
  input := pOp.Params.Root['Input'];
  input.v := doc;
  options := pOp.Params.Root['Options'];
  options['PagesRange.Type'].v := 'Exact';
  options['PagesRange.Text'].v := Format('%d-%d', [nPageStart, nPageStop]);
  // Select pages range that will be deleted from the document
  pOp.Do_(0);
end;

procedure TInst.InsertEmptyPage(doc: PDFXEdit_TLB.IPXV_Document;
  nPage, nCount: integer);
var
  nID: integer;
  pOp: PDFXEdit_TLB.IOperation;
  input: PDFXEdit_TLB.ICabNode;
  options: PDFXEdit_TLB.ICabNode;
begin
  nID := FInst.Str2ID('op.document.insertEmptyPages', false);
  pOp := FInst.CreateOp(nID);
  input := pOp.Params.Root['Input'];
  input.v := doc;
  options := pOp.Params.Root['Options'];
  options['PaperType'].v := 2; // Apply custom paper type
  options['Count'].v := nCount; // Create nCount new pages
  options['Width'].v := 800; // Width of new pages
  options['Height'].v := 1200; // Height of new pages
  options['Location'].v := 1; // New pages will be inserted after first page
  options['Position'].v := nPage; // Page number
  pOp.Do_(0);
end;

procedure TInst.InsertPagesTest;
var
  AFile1, AFile2: String;
  ADoc1, ADoc2: IPXC_Document;
  BS: IBitSet;
  APageCount1, APageCount2: Cardinal;
begin
  AFile1 := 'F:\TEMP\Numbers.pdf';
  AFile2 := 'F:\TEMP\Letters.pdf';
  try
    ADoc1 := FInstCore.OpenDocumentFromFile(PChar(AFile1), nil, nil, 0, 0);
    ADoc2 := FInstCore.OpenDocumentFromFile(PChar(AFile2), nil, nil, 0, 0);

    ADoc1.Pages.Get_Count(APageCount1);
    ADoc2.Pages.Get_Count(APageCount2);

    BS := FInstAUX.CreateBitSet(APageCount2);
    BS.SetSize(APageCount2);
    BS.Item[0] := True;
    BS.Item[1] := True;
    ADoc1.Pages.InsertPagesFromDocEx(ADoc2, APageCount1, BS,
      IPF_Annots_Copy + IPF_Bookmarks_CopyAll, nil);
    ADoc1.WriteToFile(PChar(AFile1), nil, 0);
  finally
  end;
end;

procedure TInst.SignDocument(doc: PDFXEdit_TLB.IPXC_Document);
const
  CERT_FIND_SUBJECT_STR = $00080007;
  CERT_ENCODING = $00000001 or $00010000;
  // X509_ASN_ENCODING =0x00000001 | PKCS_7_ASN_ENCODING = 0x00010000
  MyFlags = (PDFXEdit_TLB.Sign_GR_Name or PDFXEdit_TLB.Sign_TX_Name or
    PDFXEdit_TLB.Sign_TX_Date or PDFXEdit_TLB.Sign_TX_Location or
    PDFXEdit_TLB.Sign_TX_Reason or PDFXEdit_TLB.Sign_TX_DName);
var
  strCertSubject: WideString;
  // lpszCertSubject: PWideChar;
  lpszCertSubject: array [0 .. 64] of WideChar;
  hSysStore: HCERTSTORE;
  hCertCntxt: PCCERT_CONTEXT;
  rc: PDFXEdit_TLB.PXC_Rect;
  MyContext: PDFXEdit_TLB.PUserType8;
begin
  hSysStore := CertOpenSystemStore(0, 'MY'); // kijken in 'my' store
  if (hSysStore = nil) then
  begin
    Assert(false, 'CertOpenSystemStore');
    exit;
  end;
  strCertSubject := 'dima';
  StringToWideChar(strCertSubject, lpszCertSubject, Length(lpszCertSubject));
  hCertCntxt := CertFindCertificateInStore(hSysStore, CERT_ENCODING,
    CERT_FIND_ANY, CERT_FIND_SUBJECT_STR, @lpszCertSubject, nil);
  if (hCertCntxt = nil) then
  Begin
    Assert(false, 'CertFindCertificateInStore');
    exit;
  End;

  rc.left := 0;
  rc.top := 36;
  rc.right := rc.left + 144;
  rc.bottom := 0;
  MyContext := PDFXEdit_TLB.PUserType8(hCertCntxt);
  // try
  // Doc.DeferedDigitalSign(MyContext^, MyFlags, 0, rc, 'Signed by', '', 'Support@...', '');
  // Doc.DeferedDigitalSign(PDFXEdit_TLB.PUserType8(hCertCntxt)^, MyFlags, 0, rc, 'Signed by', '', 'Support@...', '');
  { except
    on e: Exception do
    Assert(false, e.Message);
    end; }
  doc.WriteToFile('c:\Users\oliyn\Documents\TestFile_res.pdf', nil, 0);
end;

function TInst.PDF_InsertPages(ADoc, ASrcDoc: IPXV_Document; ASrcFileName, ASrcPagesAsCommaText: String; ABeforeIndex: Integer; ADeleteSource: Boolean): Boolean;
var
  nID: Integer;
  pOp: IOperation;
  input, options: ICabNode;
  APageCount: Cardinal;
begin
  Result := False;
  if not Assigned(ADoc) then exit;
  if not FileExists(ASrcFileName) and not Assigned(ASrcDoc) then exit;

  try
    ADoc.CoreDoc.Pages.Get_Count(APageCount);
    if (ABeforeIndex <= -1) then ABeforeIndex := APageCount; //Append
    ABeforeIndex := Max(0, Min(APageCount, ABeforeIndex));

    nID := FInst.Str2ID('op.document.insertPages', False);
    pOp := FInst.CreateOp(nID);
    input := pOp.Params.Root['Input'];
    input.v := ADoc;
    options := pOp.Params.Root['Options'];
    options['Position'].v := ABeforeIndex; //First page
    options['Location'].v := 'Before'; //The pages will be inserted before first page
    options['CommentsAction'].v := 'Copy'; //Copy all comments
    options['FieldsAction'].v := 'Copy'; //Copy all fields
    options['BookmarksAction'].v := 'CopyRelated'; //Copy bookmarks that are related to the
    if Assigned(ASrcDoc) then
    begin
      options['Src'].v := ASrcDoc;
    end else
    begin
      options['Src'].v := FInstFS.DefaultFileSys.StringToName(PChar(ASrcFileName), 0, nil);
    end;
    if (ASrcPagesAsCommaText = '') then
    begin
      options['PagesRange.Type'].v := 'All';
    end else
    begin
      options['PagesRange.Type'].v := 'Exact';
      options['PagesRange.Text'].v := ASrcPagesAsCommaText;
    end;
    pOp.Do_(0);

    //if ADeleteSource and Assigned(ASrcDoc) then PDF_DeletePages(ASrcDoc, ASrcPagesAsCommaText);

    Result := True;
  except
    ShowMessage('Error in PDF_InsertPages');
  end;
end;

begin
  gInst := TInst.Create;

end.
