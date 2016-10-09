using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace OptimizeImagesCompression
{
    class Program
    {
        private static string[] CompMode = { "Color", "Grayscale", "Indexed", "Mono" };
        static void Main()
        {
            ShowHelp();
            string FolderWithTestFilesPath = CmdArgsParser.GetCmdArgForParam("-f");
            string LogPath = CmdArgsParser.GetCmdArgForParam("-l");
            string FoderToSaveFiles = CmdArgsParser.GetCmdArgForParam("-s");

            FileStream log;
            Logger logfile = new Logger();
            logfile.StartLogging(LogPath, out log);
            string[] InputFilePaths;
            GetTestFiles.FolderWithTestFilesPath = FolderWithTestFilesPath;
            InputFilePaths = GetTestFiles.GetAllFilesInFolder();

            PDFXEDIT editor = new PDFXEDIT();
            editor.InitPDFControl();
            for (int FileNumber = 0; FileNumber < InputFilePaths.Length; FileNumber++)//Do Optimization this for all files in folder
            {
                string OpParams;
                string ErrCodes;
                for (int compmode_number = 0; compmode_number < CompMode.Length; compmode_number++) //Choose Color
                {
                    int methods_count = GetValidCountMethodsForCompMode(CompMode[compmode_number]);
                    for (int methods_number = 0; methods_number < methods_count; methods_number++) //Type of compression
                    {
                        if (((CompMode[compmode_number] == "Color") || (CompMode[compmode_number] == " Grayscale")) && (methods_number == 1 || methods_number == 2)) //Jpeg and Jpeg 200 have additional parametr Quality;
                        {
                            for (int Quality = 1; Quality < 7; Quality++)
                            {
                                OpParams = CompMode[compmode_number] + "_" + methods_number.ToString(CultureInfo.CurrentCulture) + "_" + (Quality - 1).ToString(CultureInfo.CurrentCulture);
                                logfile.WriteUnicodeString(log, "Start work on " + InputFilePaths[FileNumber] + " with params " + OpParams);
                                string OutputFilePath = TransformFileName(InputFilePaths[FileNumber], FoderToSaveFiles, OpParams);
                                if (!(File.Exists(OutputFilePath)))
                                {
                                    var watch = System.Diagnostics.Stopwatch.StartNew();
                                    editor.OptimizeDocument(InputFilePaths[FileNumber], OutputFilePath, CompMode[compmode_number], methods_number, Quality, out ErrCodes);
                                    watch.Stop();
                                    logfile.WriteUnicodeString(log, "Work  Ended with error code " + ErrCodes);
                                    logfile.WriteUnicodeString(log, "Time of Work = " + watch.ElapsedMilliseconds.ToString(CultureInfo.CurrentCulture));
                                }
                                else { logfile.WriteUnicodeString(log, "File " + OutputFilePath + " exists skiping..."); }
                            }
                        }
                        else
                        {
                            OpParams = CompMode[compmode_number] + "_" + methods_number.ToString(CultureInfo.CurrentCulture);
                            logfile.WriteUnicodeString(log, "Start work on " + InputFilePaths[FileNumber] + " with params " + OpParams);
                            string OutputFilePath = TransformFileName(InputFilePaths[FileNumber], FoderToSaveFiles, OpParams);
                            if (!(File.Exists(OutputFilePath)))
                            {
                                var watch = System.Diagnostics.Stopwatch.StartNew();
                                editor.OptimizeDocument(InputFilePaths[FileNumber], OutputFilePath, CompMode[compmode_number], methods_number, 0, out ErrCodes);
                                watch.Stop();
                                logfile.WriteUnicodeString(log, "Work  Ended with error code " + ErrCodes);
                                logfile.WriteUnicodeString(log, "Time of Work = " + watch.ElapsedMilliseconds.ToString(CultureInfo.CurrentCulture));
                            }
                            else { logfile.WriteUnicodeString(log, "File " + OutputFilePath + " exists skiping..."); }
                        }
                    }
                }
            }

            try { editor.m_Inst.Shutdown(); }
            catch (Exception e)
            { logfile.WriteUnicodeString(log, "Work ended with error " + e.Message); }
            if (InputFilePaths.Length == 0) { logfile.WriteUnicodeString(log, "No files in folder, work ended"); }
            else
            {
                logfile.WriteUnicodeString(log, " Work ended");
            }


            
            StatisticInfo statistic = new StatisticInfo();
            statistic.FolderWithOriginalFiles = FolderWithTestFilesPath;
            statistic.FolderWithOptimizedFiles = FoderToSaveFiles;
            string[] st_info=statistic.GetInfo();
            for (int i=0;i<st_info.Length; i++)
            {
                logfile.WriteUnicodeString(log,st_info[i]);
            }
            Logger.EndLogging(log);

        }

        static void ShowHelp()
        {
            Console.WriteLine("OptimizeImageCompression ver 0.0.3");
            Console.WriteLine("For correct work plugin PDFOptimizer.pvp must be in the same directory that executable project");
            Console.WriteLine("Supported arguments");
            Console.WriteLine("-f path to folder with test files");
            Console.WriteLine("-s path to folder in which files will be saved");
            Console.WriteLine("-l path to log file in which log will be written");
            Console.WriteLine("===============================================================================================");
            Console.WriteLine("Limitations:");
            Console.WriteLine("In input  folder must be only pdf files");
            Console.WriteLine("Output folder must be empty if you want to see corect statistic");
        }

        static int GetValidCountMethodsForCompMode(string comp_mode)
        {
            switch (comp_mode)
            {
                case "Color":
                    return 4;
                    break;
                case "Grayscale":
                    return 4;
                    break;
                case "Indexed":
                    return 4;
                    break;
                case "Mono":
                    return 6;
                    break;
                default:
                    return 0;
                    break;
            }

        }

        static string TransformFileName(string InputFile, string SaveFolder, string Options)
        {
            string temp = Path.GetFileNameWithoutExtension(InputFile);
            temp += Options;
            temp += Path.GetExtension(InputFile);

            temp = SaveFolder + "\\" + temp;
            return temp;

        }

    }


}