program SamplePDFEdit;

uses
  Vcl.Forms,
  untMain in 'untMain.pas' {Form1},
  PDFInst in 'PDFInst.pas',
  ABOUT in 'about.pas' {AboutBox};

{$R *.res}


begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm1, Form1);
  Application.CreateForm(TAboutBox, AboutBox);
  Application.Run;
end.
