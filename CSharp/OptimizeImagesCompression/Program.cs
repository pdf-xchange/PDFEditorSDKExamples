using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using OptimizeImagesCompression.Properties;

namespace OptimizeImagesCompression
{
	internal class Program
	{
		private static readonly string[] CompMode = { "Color", "Grayscale", "Indexed", "Mono" };

		public static void Main()
		{
			ShowHelp();
			var folderWithTestFilesPath = CmdArgsParser.GetCmdArgForParam("-f");
			var logPath = CmdArgsParser.GetCmdArgForParam("-l");
			var foderToSaveFiles = CmdArgsParser.GetCmdArgForParam("-s");
			GetTestFiles.FolderWithTestFilesPath = folderWithTestFilesPath;
			var inputFilePaths = GetTestFiles.GetAllFilesInFolder();
			var operationTask = GenerateTaskList(inputFilePaths, foderToSaveFiles);
			var editor = new Pdfxedit();
			var logger = new Logger();
			logger.Path = logPath;
			editor.InitPdfControl();
			foreach (var operation in operationTask)
			{
				var watch = System.Diagnostics.Stopwatch.StartNew();
				editor.OptimizeDocument(operation);
				watch.Stop();
				operation.Time = watch.ElapsedMilliseconds;
				if (File.Exists(operation.OutputFilePath))
				{
					var rezFile = new FileInfo(operation.OutputFilePath);
					operation.OptimazedFileSize = rezFile.Length;
				}
				var originFile = new FileInfo(operation.FilePath);
				operation.OriginalFileSize = originFile.Length;
				logger.StartLogging();
				logger.WriteOperationToLog(operation);
				logger.EndLogging();
				GC.Collect();
				GC.WaitForPendingFinalizers();
			}
			editor.MInst.Shutdown();
			editor.MInst = null;
			GC.Collect();
			GC.WaitForPendingFinalizers();
		}


		private static List<OperationParameters> GenerateTaskList(string[] inputFilePaths, string foderToSaveFiles)
		{
			var operationTaskParams = new List<OperationParameters>();
			foreach (var fileName in inputFilePaths)
				foreach (var compMode in CompMode)
				{
					var methodsCount = GetValidCountMethodsForCompMode(compMode);
					for (var methodsNumber = 0; methodsNumber < methodsCount; methodsNumber++) //Type of compression
					{
						var maxQuality = 0;
						if ((compMode == "Grayscale") || (compMode == "Color"))
						{
							if (methodsNumber == 1)
								maxQuality = 5;
							else if (methodsNumber == 2)
								maxQuality = 4;
						}
						for (var quality = 0; quality <= maxQuality; quality++)
						{
							var opParams = "_" + compMode + "_" + TransformMethodToUserFriendly(compMode, methodsNumber) +
										   "_"
										   + quality.ToString(CultureInfo.CurrentCulture);
							var outputFilePath = TransformFileName(fileName, foderToSaveFiles, opParams);
							if (!File.Exists(outputFilePath))
							{
								var operationParameters = new OperationParameters
								{
									FilePath = fileName,
									CompMode = compMode,
									Method = methodsNumber,
									Quality = quality,
									OutputFilePath = outputFilePath
								};
								operationTaskParams.Add(operationParameters);
							}
						}
					}
				}
			return operationTaskParams;
		}

		private static void ShowHelp()
		{
			Console.WriteLine(Resources.Program_ShowHelp_OptimizeImageCompression_ver_0_0_3);
			Console.WriteLine(
				Resources
					.Program_ShowHelp_For_correct_work_plugin_PDFOptimizer_pvp_must_be_in_the_same_directory_that_executable_project);
			Console.WriteLine(Resources.Program_ShowHelp_Supported_arguments);
			Console.WriteLine(Resources.Program_ShowHelp__f_path_to_folder_with_test_files);
			Console.WriteLine(Resources.Program_ShowHelp__s_path_to_folder_in_which_files_will_be_saved);
			Console.WriteLine(Resources.Program_ShowHelp__l_path_to_log_file_in_which_log_will_be_written);
			Console.WriteLine(Resources.Program_ShowHelp_);
			Console.WriteLine(Resources.Program_ShowHelp_Limitations_);
			Console.WriteLine(Resources.Program_ShowHelp_In_input__folder_must_be_only_pdf_files);
			Console.WriteLine(Resources.Program_ShowHelp_Output_folder_must_be_empty_if_you_want_to_see_corect_statistic);
		}

		private static int GetValidCountMethodsForCompMode(string compMode)
		{
			switch (compMode)
			{
				case "Color":
				case "Grayscale":
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
			var temp = Path.GetFileNameWithoutExtension(inputFile);
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