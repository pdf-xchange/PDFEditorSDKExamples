using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace OptimizeImagesCompression
{
    internal class Logger
    {
        public string Path;
        public FileStream Log;

        public void StartLogging()
        {
            Log = File.Open(Path, FileMode.Append);
            WriteDelimitrToLog(Log);
            WriteUnicodeString(DateTime.Now.ToString("h:mm:ss tt", CultureInfo.CurrentCulture) + " Start logger" + "\n");
            var newline = Encoding.ASCII.GetBytes(Environment.NewLine);
            Log.Write(newline, 0, newline.Length);
        }

        public void EndLogging()
        {
            Log.Close();
        }

        public void WriteUnicodeString(string info)
        {
            Console.WriteLine(info);
            var infoB = new UTF8Encoding(true).GetBytes(info);
            Log.Write(infoB, 0, infoB.Length);
            var newline = Encoding.ASCII.GetBytes(Environment.NewLine);
            Log.Write(newline, 0, newline.Length);
        }

        public void WriteDelimitrToLog(FileStream log)
        {
            var infoB =
                new UTF8Encoding(true).GetBytes("====================================================================" +
                                                "\n");
            log.Write(infoB, 0, infoB.Length);
            var newline = Encoding.ASCII.GetBytes(Environment.NewLine);
            log.Write(newline, 0, newline.Length);
            Console.WriteLine(newline.ToString());
        }

        public void WriteOperationToLog(OperationParameters operation)
        {
            WriteUnicodeString("Original file path          = " + operation.FilePath);
            WriteUnicodeString("Params and output file name = " + operation.OutputFilePath);
            if (operation.ErrCodes == string.Empty)
                WriteUnicodeString("Error code                  = None");
            else
                WriteUnicodeString("Error code                  = " + operation.ErrCodes);
            WriteUnicodeString("Time of convertation        = " + operation.Time);
            WriteUnicodeString("Params and output file name = " + operation.OutputFilePath);
        }
    }
}
