program SamplePDFEdit;

uses
  Vcl.Forms,
  untMain in 'untMain.pas' {Form1},
  PDFInst in 'PDFInst.pas',
  about in 'about.pas' {AboutBox},
  SXC_40 in 'SXC_40.pas';

{$R *.res}


begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm1, Form1);
  Application.CreateForm(TAboutBox, AboutBox);
  Application.Run;
end.
