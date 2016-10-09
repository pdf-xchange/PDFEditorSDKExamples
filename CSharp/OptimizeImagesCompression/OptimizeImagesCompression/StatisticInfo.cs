using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OptimizeImagesCompression
{
    class StatisticInfo
    {
        public  string FolderWithOriginalFiles { get; set; }
        public  string FolderWithOptimizedFiles { get; set; }

        private  string[] GetAllFilesInFolder(string Folder)
        {

            return Directory.GetFiles(Folder);

        }
        public string[] GetInfo()
        {
            //Under constrution need full rewrite becouse idea is very bed
            string[] original = GetAllFilesInFolder(FolderWithOriginalFiles);
            string[] optimized = GetAllFilesInFolder(FolderWithOptimizedFiles);
            string[] best_params = new string[original.Length * 4];
            Array.Sort(optimized);
            Array.Sort(original);
            for (int file_number = 0;file_number<original.Length;file_number++)
            {
                string temp;
                int op_file_number = file_number * 28;//becouse for each original file will be generated 28 opt files

                temp = original[file_number];

                temp += " Best params for color ";
                int temp_number=0;
                FileInfo[] fi = new FileInfo[28];
                    for (int color=0 ; color < 14; color++)
                {
                   fi[color] = new FileInfo(optimized[file_number+color]);
                }
                for (int color = 0; color <13; color++)
                {
                    if (fi[color].Length>=fi[color+1].Length)
                    {
                        temp_number = color + 1;
                    }
                }
                temp += " " + Path.GetFileNameWithoutExtension(fi[temp_number].FullName);
                best_params[file_number] = temp;
                temp = String.Empty;
                temp = original[file_number];
                temp += "Best params for Grayscale";
                for (int color = 14; color < 18; color++)
                {
                    fi[color] = new FileInfo(optimized[file_number + color]);
                }
                temp += Path.GetFileNameWithoutExtension(fi[temp_number].FullName);
                for (int color =14; color < 17; color++)
                {
                    if (fi[color].Length >= fi[color + 1].Length)
                    {
                        temp_number = color + 1;
                    }
                }
                temp +=" "+ Path.GetFileNameWithoutExtension(fi[temp_number].FullName);
                best_params[file_number+1] = temp;
                temp = String.Empty;
                temp = original[file_number];
                temp += "Best params for Indexed";
                for (int color = 18; color < 22; color++)
                {
                    fi[color] = new FileInfo(optimized[file_number + color]);
                }
                temp += Path.GetFileNameWithoutExtension(fi[temp_number].FullName);
                for (int color = 18; color < 21; color++)
                {
                    if (fi[color].Length >= fi[color + 1].Length)
                    {
                        temp_number = color + 1;
                    }
                }
                temp += Path.GetFileNameWithoutExtension(fi[temp_number].FullName);
                best_params[file_number + 2] = temp;
                temp=String.Empty;
                temp = original[file_number];
                temp += "Best params for Mono";
                for (int color =22; color < 28; color++)
                {
                    fi[color] = new FileInfo(optimized[file_number + color]);
                }
                temp += Path.GetFileNameWithoutExtension(fi[temp_number].FullName);
                for (int color = 22; color < 27; color++)
                {
                    if (fi[color].Length >= fi[color + 1].Length)
                    {
                        temp_number = color + 1;
                    }
                }
                temp += Path.GetFileNameWithoutExtension(fi[temp_number].FullName);
                best_params[file_number + 3] = temp;

            }
            return best_params;
        }
        
    }
}
