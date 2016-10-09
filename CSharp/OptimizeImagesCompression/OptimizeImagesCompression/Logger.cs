using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public static void EndLogging(FileStream log)
        {
            log.Close();
          
        }

        public void WriteUnicodeString(FileStream log,string info)
        {
            Console.WriteLine(info);
            byte[] info_b = new UTF8Encoding(true).GetBytes(info);
            log.Write(info_b, 0, info_b.Length);    
            byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
            log.Write(newline, 0, newline.Length);

        }

       public void WriteDelimitrToLog(FileStream log)
        {
            byte[] info_b = new UTF8Encoding(true).GetBytes("===================================================================="+"\n");
            log.Write(info_b, 0, info_b.Length);
            byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
            log.Write(newline, 0, newline.Length);
            Console.WriteLine(newline.ToString());
        }
       





    }
}
