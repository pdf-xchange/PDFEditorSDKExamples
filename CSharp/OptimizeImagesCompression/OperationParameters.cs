using System.IO;

namespace OptimizeImagesCompression
{
	class OperationParameters
	{
		public string FilePath;
		public string OutputFilePath;
		public string CompMode;
		public int Method;
		public int Quality;
		public string ErrCodes = "";
		public long Time = 0;
		public long OptimazedFileSize = 0;
		public long OriginalFileSize = 0;
	}
}
