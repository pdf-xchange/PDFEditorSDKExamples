using System;
using System.Collections.Generic;



namespace OptimizeImagesCompression
{
    class StatisticFunctions
    {
        public List<OperationParameters> GetFilesWithError(List<OperationParameters> operationTask)
        {
            List<OperationParameters> problemFiles = new List<OperationParameters>();
            foreach (var operation in operationTask)
            {
                if (operation.ErrCodes != String.Empty)
                {
                    problemFiles.Add(operation);
                }
            }
            return problemFiles;
        }
    }
}
