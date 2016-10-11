using System.IO;


namespace OptimizeImagesCompression
{
    class GetTestFiles

    {
        public static string FolderWithTestFilesPath { get; set; }

        public static string[] GetAllFilesInFolder()
        {
            
            return  Directory.GetFiles(FolderWithTestFilesPath);

        }


    }
}
