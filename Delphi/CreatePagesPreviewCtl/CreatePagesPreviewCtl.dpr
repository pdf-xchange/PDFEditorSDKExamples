program CreatePagesPreviewCtl;

uses
  Vcl.Forms,
  uMain in 'uMain.pas' {frmMain},
  Unit2 in 'Unit2.pas' {Form2};

{$R *.res}

{$IFDEF WIN32}
{$EXTENSION .x86.exe}
{$ENDIF}
{$IFDEF WIN64}
{$EXTENSION .x64.exe}
{$ENDIF}


begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TfrmMain, frmMain);
  Application.Run;
end.
