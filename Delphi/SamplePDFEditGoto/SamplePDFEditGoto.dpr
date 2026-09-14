program SamplePDFEditGoto;

uses
  Vcl.Forms,
  Unit1 in 'Unit1.pas' {Form1};

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
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
