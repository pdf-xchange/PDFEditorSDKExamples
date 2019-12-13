program CreatePagesPreviewCtl;

uses
  Vcl.Forms,
  uMain in 'uMain.pas' {frmMain},
  Unit2 in 'Unit2.pas' {Form2};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TfrmMain, frmMain);
  Application.Run;
end.
