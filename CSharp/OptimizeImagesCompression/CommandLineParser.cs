using System;


namespace OptimizeImagesCompression
{
    public class CommandLineParser
    {




        private static string ParseArguments(string[] allcmdargs, string param)
        {
            for (int i = 0; i < allcmdargs.Length; i++)
            {
                if (allcmdargs[i] == param)
                {
                    if (String.IsNullOrEmpty(allcmdargs[i + 1]))
                    {
                        Console.WriteLine("Empty arg for option " + param);
                        Environment.Exit(0);//якщо параметр порожній завершаємо програму.
                    }
                    else
                    {
                        return allcmdargs[i + 1];
                    }
                }

            }
            Console.WriteLine("Parametr  not found " + param);
            Environment.Exit(0);//якщо параметр порожній завершаємо програму.
            return "Parametr not found";
        }

        public string GetCmdArgForParam(string param)
        {
            string[] allcmdargs = Environment.GetCommandLineArgs();
            return ParseArguments(allcmdargs, param);
        }
    }
}

