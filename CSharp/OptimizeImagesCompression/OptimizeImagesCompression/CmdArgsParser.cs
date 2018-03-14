using System;
using OptimizeImagesCompression.Properties;

namespace OptimizeImagesCompression
{
	static class CmdArgsParser
	{
		public static string GetCmdArgForParam(string param)
		{
			string[] allargsparams = Environment.GetCommandLineArgs();
			return ParseCmdArgs(allargsparams, param);
		}

		private static string ParseCmdArgs(string[] allargsparams, string param)
		{
			for (int i = 0; i < allargsparams.Length; i++)
			{
				if (allargsparams[i] == param)
				{
					if (String.IsNullOrEmpty(allargsparams[i + 1]))
					{
						Console.WriteLine(Resources.CmdArgsParser_ParseCmdArgs_arg_is_null_for_parametr_ + param + Resources.CmdArgsParser_ParseCmdArgs__terminating___);
						System.Diagnostics.Debug.WriteLine(Resources.CmdArgsParser_ParseCmdArgs_arg_is_null_for_parametr_ + param + Resources.CmdArgsParser_ParseCmdArgs__terminating___);
						Environment.Exit(0);
					}
					else
					{
						return allargsparams[i + 1];
					}
				}
			}
			Console.WriteLine(Resources.CmdArgsParser_ParseCmdArgs_arg_is_not_found_for_ + param + Resources.CmdArgsParser_ParseCmdArgs__terminating___);
			System.Diagnostics.Debug.WriteLine(Resources.CmdArgsParser_ParseCmdArgs_arg_is_not_found_for_ + param + Resources.CmdArgsParser_ParseCmdArgs__terminating___);
			Environment.Exit(0);
			return "ArgNotFound";
		}
	}
}
