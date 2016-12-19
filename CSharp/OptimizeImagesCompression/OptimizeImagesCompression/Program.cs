using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using OptimizeImagesCompression.Properties;
using PDFXEdit;

namespace OptimizeImagesCompression
{
    class Program
    {
        private static readonly string[] CompMode = { "Color", "Grayscale", "Indexed", "Mono" };
        private static void Main()
        {
            ShowHelp();
            string folderWithTestFilesPath = CmdArgsParser.GetCmdArgForParam("-f");
            string logPath = CmdArgsParser.GetCmdArgForParam("-l");
            string foderToSaveFiles = CmdArgsParser.GetCmdArgForParam("-s");
            GetTestFiles.FolderWithTestFilesPath = folderWithTestFilesPath;
            string[] inputFilePaths = GetTestFiles.GetAllFilesInFolder();
            List<OperationParameters> operationTask = GenerateTaskList(inputFilePaths, foderToSaveFiles);
            Pdfxedit editor = new Pdfxedit();
            editor.InitPdfControl();
            foreach (var operation in operationTask)
            {
                editor.OptimizeDocument(operation.FileName, operation.OutputFilePath, operation.CompMode, operation.MethodsNumber, operation.Quality, out operation.ErrCodes);
            }
            try { editor.m_Inst.Shutdown(); }
            catch (Exception e)
            { }

        }

        private static List<OperationParameters> GenerateTaskList(string[] inputFilePaths, string foderToSaveFiles)
        {
            var operationTaskParams = new List<OperationParameters>();
            foreach (string fileName in inputFilePaths)
            {
                foreach (string compMode in CompMode)
                {
                    int methodsCount = GetValidCountMethodsForCompMode(compMode);
                    for (int methodsNumber = 0; methodsNumber < methodsCount; methodsNumber++) //Type of compression
                    {
                        int maxQuality = (compMode == "Color" || compMode == " Grayscale") &&
                                     (methodsNumber == 1 || methodsNumber == 2)
                            ? 6
                            : 0;
                        for (int quality = 0; quality <= maxQuality; quality++)
                        {
                            string opParams = compMode + "_" + TransformMethodToUserFriendly(compMode, methodsNumber) + "_"
                                + quality.ToString(CultureInfo.CurrentCulture);
                            string outputFilePath = TransformFileName(fileName, foderToSaveFiles, opParams);
                            if (!File.Exists(outputFilePath))
                            {
                                var operationParameters = new OperationParameters
                                {
                                    FileName = fileName,
                                    CompMode = compMode,
                                    MethodsNumber = methodsNumber,
                                    Quality = quality,
                                    OutputFilePath = outputFilePath
                                };
                                operationTaskParams.Add(operationParameters);
                            }
                        }
                    }
                }
            }
            return operationTaskParams;
        }

        static void ShowHelp()
        {
            Console.WriteLine(Resources.Program_ShowHelp_OptimizeImageCompression_ver_0_0_3);
            Console.WriteLine(Resources.Program_ShowHelp_For_correct_work_plugin_PDFOptimizer_pvp_must_be_in_the_same_directory_that_executable_project);
            Console.WriteLine(Resources.Program_ShowHelp_Supported_arguments);
            Console.WriteLine(Resources.Program_ShowHelp__f_path_to_folder_with_test_files);
            Console.WriteLine(Resources.Program_ShowHelp__s_path_to_folder_in_which_files_will_be_saved);
            Console.WriteLine(Resources.Program_ShowHelp__l_path_to_log_file_in_which_log_will_be_written);
            Console.WriteLine(Resources.Program_ShowHelp_);
            Console.WriteLine(Resources.Program_ShowHelp_Limitations_);
            Console.WriteLine(Resources.Program_ShowHelp_In_input__folder_must_be_only_pdf_files);
            Console.WriteLine(Resources.Program_ShowHelp_Output_folder_must_be_empty_if_you_want_to_see_corect_statistic);
        }

        static int GetValidCountMethodsForCompMode(string compMode)
        {
            switch (compMode)
            {
                case "Color":
                    return 4;
                case "Grayscale":
                    return 4;
                case "Indexed":
                    return 4;
                case "Mono":
                    return 6;
                default:
                    return 0;
            }
        }

        private static string TransformFileName(string inputFile, string saveFolder, string options)
        {
            string temp = Path.GetFileNameWithoutExtension(inputFile);
            temp += options;
            temp += Path.GetExtension(inputFile);
            temp = saveFolder + "\\" + temp;
            return temp;
        }
        private static string TransformMethodToUserFriendly(string compMode, int method)
        {
            switch (compMode)
            {
                case "Color":
                    switch (method)
                    {
                        case 0:
                            return "Retain Existing";
                        case 1:
                            return "Jpeg2000";
                        case 2:
                            return "Jpeg";
                        case 3:
                            return "Zip";
                        default:
                            return "Error_Index";
                    }
                case "Grayscale":
                    switch (method)
                    {
                        case 0:
                            return "Retain Existing";
                        case 1:
                            return "Jpeg2000";
                        case 2:
                            return "Jpeg";
                        case 3:
                            return "Zip";
                        default:
                            return "Error_Index";
                    }
                case "Indexed":
                    switch (method)
                    {
                        case 0:
                            return "Retain Existing";
                        case 1:
                            return "Zip";
                        case 2:
                            return "RunLength";
                        case 3:
                            return "LZW";
                        default:
                            return "Error_Index";
                    }
                case "Mono":
                    switch (method)
                    {
                        case 0:
                            return "Retain Existing";
                        case 1:
                            return "Jbig2";
                        case 2:
                            return "CCIT3";
                        case 3:
                            return "CCIT4";
                        case 4:
                            return "Zip";
                        case 5:
                            return "RunLength";
                        default:
                            return "Error_Index";
                    }
                default:
                    return "Error_index_inCompMethod";
            }
        }
    }
}