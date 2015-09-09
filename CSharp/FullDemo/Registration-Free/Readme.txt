///////////////////////////////////////////////////////////////////////////////////////
// Registration-Free Redistribution
///////////////////////////////////////////////////////////////////////////////////////

Your application installer should locate all application executable files and the require PDF-XChange Editor SDK files in a single common folder along with two additional XML files with prescribed file names as follows:

<YourProgramName>.exe.manifest
PDFXEditCore.x86.X.manifest

Where <YourProgramName> - is the name of the application’s executable file without a file extension.

More detailed information regarding Registration-Free technology can be found here: https://msdn.microsoft.com/en-us/library/ms973913.aspx.

IMPORTANT: in your development environment you will also need to change the settings of your project to use external manifest files as opposed to those built-in by default.

---

To enable the Registration-Free mode for 'FullDemo' sample: 

1.	Go to project's Properties, select 'Application' tab, in 'Resources' section and choose 'Create application without a manifest' option and re-build application.
	Note: on this step the PDFXEditCore.x86.dll should be still installed in the system as regular COM-server.

2.	Copy PDFXEditCore.x86.X.manifest and FullDemo.exe.manifest files to <ProjectDir>\bin\x86\<ConfigurationDir>. 
	Also place the PDFXEditCore.x86.dll and Resources.dat files into this folder too. After that you will be able to start and use the FullDemo.exe even if PDFXEditCore.x86.dll is not installed as COM-server.