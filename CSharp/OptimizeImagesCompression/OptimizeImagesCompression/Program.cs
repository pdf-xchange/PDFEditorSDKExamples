using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizeImagesCompression
{
    class Program
    {
        static void Main(string[] args)
        {
            CmdArgsParser parser = new CmdArgsParser();
            GetTestFiles fileEnumerator = new GetTestFiles();
            ShowHelp();
            string FolderWithTestFilesPath = parser.GetCmdArgForParam("-f");
            string LogPath = parser.GetCmdArgForParam("-l");
            string FoderToSaveFiles = parser.GetCmdArgForParam("-s");
            fileEnumerator.FolderWithTestFilesPath = FolderWithTestFilesPath;
            string[] InputFilePaths = fileEnumerator.GetAllFilesInFolder();
            string[] OutputFilePaths = fileEnumerator.GetSavedFileNames(InputFilePaths, FoderToSaveFiles);
            PDFXEDIT editor = new PDFXEDIT();
            editor.InitPDFControl();
            for (int i =0;i< InputFilePaths.Length;i++)
            {
                
                editor.OptimizeDocument(InputFilePaths[i], OutputFilePaths[i]);

            }
            editor.m_Inst.Shutdown();
                    

        }

        static void ShowHelp()
        {
            Console.WriteLine("Supported arguments");
            Console.WriteLine("-f path to folder with test files");
            Console.WriteLine("-s path to folder in which files will be saved");
            Console.WriteLine("-l path to log file in which log will be written");
        }


    }
       
   
}