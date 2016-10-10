using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OptimizeImagesCompression
{
    class StatisticInfo
    {
        public static string[] GetInfo(List<string> FileName, List<string> FileOptions, List<long> FileSizeList)
        {
            List<string> result = new List<string>();
            string[] FileNameArr = FileName.ToArray();
            string[] FileOptionsArr = FileOptions.ToArray();
            long[] FileSize = FileSizeList.ToArray();
            int i = 0;
            while (i < FileName.Count)
            {
                long[] arr = new long[28*FileName.Count];
                for (int j = i; j <= i + 13; j++)
                {
                    arr[j] = FileSize[j];
                }

                long temp = arr.Take(13+i).Min();
                for (int j = i; j < i + 13; j++)
                {
                    if (temp == arr[j])
                    {
                        result.Add("For File " + FileNameArr[j] + " best method for Color Compresion is " + FileOptionsArr[j]);
                        break;
                    }
                }

                for (int j = i + 14; j <= i + 17; j++)
                {
                    arr[j] = FileSize[j];
                }
                
                temp = arr.Skip(13+i).Take(4+i).Min();
                for (int j = i + 14; j < i + 17; j++)
                {
                    if (temp == arr[j])
                    {
                        result.Add("For File " + FileNameArr[j] + " best method for Grayscale Compresion is " + FileOptionsArr[j]);
                        break;
                    }
                }

                for (int j = i + 18; j <= i + 21; j++)
                {
                    arr[j] = FileSize[j];
                }
                temp = arr.Skip(17+i).Take(4+i).Min();
                for (int j = i + 18; j < i + 21; j++)
                {
                    if (temp == arr[j])
                    {
                        result.Add("For File " + FileNameArr[j] + " best method for Indexed Compresion is " + FileOptionsArr[j]);
                        break;
                    }
                }
                
                for (int j = i + 22; j <=i + 27; j++)
                {
                    arr[j] = FileSize[j];
                }
                temp = arr.Skip(21+i).Take(6+i).Min();
                for (int j = i + 22; j < i + 27; j++)
                {
                    if (temp == arr[j])
                    {
                        result.Add("For File " + FileNameArr[j] + " best method for Mono Compresion is " + FileOptionsArr[j]);
                        break;
                    }
                }

                i += 28;
            }
            return result.ToArray();

        }
    }
}
