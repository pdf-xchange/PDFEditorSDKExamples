using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizeImagesCompression
{
    class Logger
    {
     

      
       

        public void StartLogging( string path ,out FileStream log)
        {

            log = File.Open(path, FileMode.Append);
            WriteDelimitrToLog(log);
            WriteUnicodeStringToLog(log, DateTime.Now.ToString("h:mm:ss tt")+ "Start logger"+"\n");
            byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
            log.Write(newline, 0, newline.Length);

        }
        public void EndLogging(FileStream log)
        {
            log.Close();
          
        }

        public void WriteUnicodeStringToLog(FileStream log,string info)
        {
            info = info + "\n";
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
        }
       





    }
}
