using System.IO;


namespace OptimizeImagesCompression
{
    class GetTestFiles

    {
        public string FolderWithTestFilesPath { get; set; }

        public string[] GetAllFilesInFolder()
        {
            string[] filePaths;
           return  filePaths = Directory.GetFiles(FolderWithTestFilesPath);

        }

        public string[] GetSavedFileNames(string[] InputFilesList,string SaveFolder)
        {
            string[] OutputFilePaths;
            OutputFilePaths =new string[InputFilesList.Length];
            InputFilesList.CopyTo(OutputFilePaths,0);
            for (int i =0; i< OutputFilePaths.Length;i++)
            {
              
                
                OutputFilePaths[i] = SaveFolder + "\\" + Path.GetFileName(InputFilesList[i]);
            }
            return OutputFilePaths;
        }
    }
}
