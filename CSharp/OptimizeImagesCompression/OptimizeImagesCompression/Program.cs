using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OptimizeImagesCompression
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] CompMode = { "Color", "Grayscale", "Indexed", "Mono" };
            CmdArgsParser parser = new CmdArgsParser();
            GetTestFiles fileEnumerator = new GetTestFiles();

            ShowHelp();

            string FolderWithTestFilesPath = parser.GetCmdArgForParam("-f");
            string LogPath = parser.GetCmdArgForParam("-l");
            string FoderToSaveFiles = parser.GetCmdArgForParam("-s");

            FileStream log;
            Logger logfile = new Logger();
            logfile.StartLogging(LogPath, out log);


            fileEnumerator.FolderWithTestFilesPath = FolderWithTestFilesPath;
            string[] InputFilePaths = fileEnumerator.GetAllFilesInFolder();
            string[] OutputFilePaths = fileEnumerator.GetSavedFileNames(InputFilePaths, FoderToSaveFiles);

            PDFXEDIT editor = new PDFXEDIT();
            editor.InitPDFControl();
            for (int i = 0; i < InputFilePaths.Length; i++)
            {
                string OpParams;
                string ErrCodes;
                for (int compmode_number = 0; compmode_number < CompMode.Length; compmode_number++)
                {
                   int methods_count= GetValidCountMethodsForCompMode(CompMode[compmode_number]);
                    for (int methods_number = 0; methods_number < methods_count; methods_number++)
                    {                    
                        editor.SetOptParams(CompMode[compmode_number], methods_number);
                        OpParams = CompMode[compmode_number] + methods_number.ToString();
                        logfile.WriteUnicodeStringToLog(log, "Start work on " + InputFilePaths[i]);
                        editor.OptimizeDocument(InputFilePaths[i], OutputFilePaths[i], out ErrCodes);
                        logfile.WriteUnicodeStringToLog(log, OpParams);
                    }

                }
            }
        
            logfile.EndLogging(log);
            editor.m_Inst.Shutdown();
           

        }

        static void ShowHelp()
        {
            Console.WriteLine("OptimizeImageCompression ver 0.0.2");
            Console.WriteLine("For correct work plugin PDFOptimizer.pvp must be in the same directory that executable project");
            Console.WriteLine("Supported arguments");
            Console.WriteLine("-f path to folder with test files");
            Console.WriteLine("-s path to folder in which files will be saved");
            Console.WriteLine("-l path to log file in which log will be written");
        }

        static int GetValidCountMethodsForCompMode(string comp_mode)
        {
            switch (comp_mode)
            {
                case "Color":
                    return 3;
                    break;
                case "Grayscale":
                    return 3;
                    break;
                case "Indexed":
                    return 3;
                    break;
                case "Mono":
                    return 5;
                    break;
                default:
                   return 0;
                    break;
            }
          
        }

      

    }
       
   
}