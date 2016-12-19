using System.Collections.Generic;
using System.Linq;

namespace OptimizeImagesCompression
{
    class StatisticInfo
    {
        public static string[] GetInfo(List<string> fileName, List<string> fileOptions, List<long> fileSizeList)
        {
            List<string> result = new List<string>();
            string[] fileNameArr = fileName.ToArray();
            string[] fileOptionsArr = fileOptions.ToArray();
            long[] fileSize = fileSizeList.ToArray();
            int i = 0;
            while (i < fileName.Count)
            {
                long[] arr = new long[28*fileName.Count];
                for (int j = i; j <= i + 13; j++)
                {
                    arr[j] = fileSize[j];
                }
                long temp = arr.Take(13+i).Min();
                for (int j = i; j < i + 13; j++)
                {
                    if (temp == arr[j])
                    {
                        result.Add("For File " + fileNameArr[j] + " best method for Color Compresion is " + fileOptionsArr[j]);
                        break;
                    }
                }

                for (int j = i + 14; j <= i + 17; j++)
                {
                    arr[j] = fileSize[j];
                }
                
                temp = arr.Skip(13+i).Take(4+i).Min();
                for (int j = i + 14; j < i + 17; j++)
                {
                    if (temp == arr[j])
                    {
                        result.Add("For File " + fileNameArr[j] + " best method for Grayscale Compresion is " + fileOptionsArr[j]);
                        break;
                    }
                }

                for (int j = i + 18; j <= i + 21; j++)
                {
                    arr[j] = fileSize[j];
                }
                temp = arr.Skip(17+i).Take(4+i).Min();
                for (int j = i + 18; j < i + 21; j++)
                {
                    if (temp == arr[j])
                    {
                        result.Add("For File " + fileNameArr[j] + " best method for Indexed Compresion is " + fileOptionsArr[j]);
                        break;
                    }
                }
                
                for (int j = i + 22; j <=i + 27; j++)
                {
                    arr[j] = fileSize[j];
                }
                temp = arr.Skip(21+i).Take(6+i).Min();
                for (int j = i + 22; j < i + 27; j++)
                {
                    if (temp == arr[j])
                    {
                        result.Add("For File " + fileNameArr[j] + " best method for Mono Compresion is " + fileOptionsArr[j]);
                        break;
                    }
                }
                i += 28;
            }
            return result.ToArray();

        }
    }
}
