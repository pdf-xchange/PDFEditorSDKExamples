using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Globalization;

namespace OptimizeImagesCompression
{
    class Logger
    {
        public  void StartLogging( string path ,out FileStream log)
        {
            log = File.Open(path, FileMode.Append);
            WriteDelimitrToLog(log);
            WriteUnicodeString(log, DateTime.Now.ToString("h:mm:ss tt", CultureInfo.CurrentCulture) + " Start logger"+"\n");
            byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
            log.Write(newline, 0, newline.Length);
        }
        public  void EndLogging(FileStream log)
        {
            log.Close();
        }
        public void WriteUnicodeString(FileStream log,string info)
        {
            Console.WriteLine(info);
            byte[] infoB = new UTF8Encoding(true).GetBytes(info);
            log.Write(infoB, 0, infoB.Length);    
            byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
            log.Write(newline, 0, newline.Length);
        }

       public void WriteDelimitrToLog(FileStream log)
        {
            byte[] infoB = new UTF8Encoding(true).GetBytes("===================================================================="+"\n");
            log.Write(infoB, 0, infoB.Length);
            byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
            log.Write(newline, 0, newline.Length);
            Console.WriteLine(newline.ToString());
        }

        public void WriteObjectListToLog(FileStream log,List<OperationParameters> objectCollection )
        {

            foreach (var operation in objectCollection)
            {
               WriteUnicodeString(log,"Original file path          = " + operation.FilePath);
               WriteUnicodeString(log,"Params and output file name = "+operation.OutputFilePath);
               WriteUnicodeString(log,"Error code                  = " + operation.ErrCodes);
            }
            
        }
       





    }
}
