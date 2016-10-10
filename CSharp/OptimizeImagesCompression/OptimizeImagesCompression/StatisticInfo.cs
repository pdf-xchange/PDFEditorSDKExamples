using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OptimizeImagesCompression
{
    class StatisticInfo
    {

        /*  public List<string> GetInfo(List<string> FileName, List<string> FileOptions, List<long> FileSize)
         {
            List<string> result = new List<string>();
             string[] FileNameArr = FileName.ToArray();
             string[] FileOptionsArr = FileOptions.ToArray();
             int i = 0;
             while (i < FileName.Count)
             {
                 long[] arr = new long[14];
                 for (int j = i; j < i + 14; j++)
                 {
                     arr[j] = FileSize[j];
                 }

                 long temp = arr.Min();
                 for (int j = i; j < i + 14; j++)
                 {
                     if (temp == arr[j])
                     {
                         result.Add("For File " + FileNameArr[j] + " best method for Color Compresion is" + FileOptionsArr[j]);
                         break;
                     }
                 }

                 i += 28;


             }


       }*/

    }
}
