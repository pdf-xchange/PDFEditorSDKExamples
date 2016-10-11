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
            List<string> raw_statistic_file = new List<string>();
            List<string> raw_statistic_options = new List<string>();
            List<long> raw_statistic_file_size = new List<long>();
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
                                OpParams = CompMode[compmode_number] + "_" + TransformMethodToUserFriendly(CompMode[compmode_number], methods_number) + "_" + "Quality" + (Quality - 1).ToString(CultureInfo.CurrentCulture);
                                logfile.WriteUnicodeString(log, "Start work on " + InputFilePaths[FileNumber] + " with params " + OpParams);
                                string OutputFilePath = TransformFileName(InputFilePaths[FileNumber], FoderToSaveFiles, OpParams);
                                if (!(File.Exists(OutputFilePath)))
                                {
                                    var watch = System.Diagnostics.Stopwatch.StartNew();
                                    editor.OptimizeDocument(InputFilePaths[FileNumber], OutputFilePath, CompMode[compmode_number], methods_number, Quality, out ErrCodes);
                                    watch.Stop();
                                    logfile.WriteUnicodeString(log, "Work  Ended with error code " + ErrCodes);
                                    logfile.WriteUnicodeString(log, "Time of Work = " + watch.ElapsedMilliseconds.ToString(CultureInfo.CurrentCulture));
                                    raw_statistic_file.Add(InputFilePaths[FileNumber]);
                                    raw_statistic_options.Add(OpParams);
                                    FileInfo f = new FileInfo(OutputFilePath);
                                    raw_statistic_file_size.Add(f.Length);
                                }
                                else { logfile.WriteUnicodeString(log, "File " + OutputFilePath + " exists skiping..."); }
                            }
                        }
                        else
                        {
                            OpParams = CompMode[compmode_number] + "_" + TransformMethodToUserFriendly(CompMode[compmode_number], methods_number);
                            logfile.WriteUnicodeString(log, "Start work on " + InputFilePaths[FileNumber] + " with params " + OpParams);
                            string OutputFilePath = TransformFileName(InputFilePaths[FileNumber], FoderToSaveFiles, OpParams);
                            if (!(File.Exists(OutputFilePath)))
                            {
                                var watch = System.Diagnostics.Stopwatch.StartNew();
                                editor.OptimizeDocument(InputFilePaths[FileNumber], OutputFilePath, CompMode[compmode_number], methods_number, 0, out ErrCodes);
                                watch.Stop();
                                logfile.WriteUnicodeString(log, "Work  Ended with error code " + ErrCodes);
                                logfile.WriteUnicodeString(log, "Time of Work = " + watch.ElapsedMilliseconds.ToString(CultureInfo.CurrentCulture));
                                raw_statistic_file.Add(InputFilePaths[FileNumber]);
                                raw_statistic_options.Add(OpParams);
                                FileInfo f = new FileInfo(OutputFilePath);
                                raw_statistic_file_size.Add(f.Length);
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
                logfile.WriteUnicodeString(log, "Work ended");
            }
            logfile.WriteUnicodeString(log, "Statistic info:");
            string[] got_statistic = StatisticInfo.GetInfo(raw_statistic_file, raw_statistic_options, raw_statistic_file_size);
            for (int i = 0; i < got_statistic.Length; i++)
            {
                logfile.WriteUnicodeString(log, got_statistic[i]);
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
        static string TransformMethodToUserFriendly(string comp_mode, int Method)
        {
            switch (comp_mode)
            {
                case "Color":
                    switch (Method)
                    {
                        case 0:
                            return "Retain Existing";
                            break;
                        case 1:
                            return "Jpeg2000";
                            break;
                        case 2:
                            return "Jpeg";
                            break;
                        case 3:
                            return "Zip";
                            break;
                        default:
                            return "Error_Index";
                            break;
                    }
                    break;
                case "Grayscale":
                    switch (Method)
                    {
                        case 0:
                            return "Retain Existing";
                            break;
                        case 1:
                            return "Jpeg2000";
                            break;
                        case 2:
                            return "Jpeg";
                            break;
                        case 3:
                            return "Zip";
                            break;
                        default:
                            return "Error_Index";
                            break;
                    }
                    break;
                case "Indexed":
                    switch (Method)
                    {
                        case 0:
                            return "Retain Existing";
                            break;
                        case 1:
                            return "Zip";
                            break;
                        case 2:
                            return "RunLength";
                            break;
                        case 3:
                            return "LZW";
                            break;
                        default:
                            return "Error_Index";
                            break;
                    }
                    break;
                case "Mono":
                    switch (Method)
                    {
                        case 0:
                            return "Retain Existing";
                            break;
                        case 1:
                            return "Jbig2";
                            break;
                        case 2:
                            return "CCIT3";
                            break;
                        case 3:
                            return "CCIT4";
                            break;
                        case 4:
                            return "Zip";
                            break;
                        case 5:
                            return "RunLength";
                            break;
                        default:
                            return "Error_Index";
                            break;
                    }
                    break;
                default:
                    return "Error_index_inCompMethod";
                    break;
            }

        }

    }


}