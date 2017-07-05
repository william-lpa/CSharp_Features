using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncronousReadWrite
{
    class FileOperation
    {
        public string FileName { get; }
        public string DirectoryPathName { get; }
        public string FullFileName { get; }
        public FileOperation(string fileName, string directoryPathName)
        {
            if (!Directory.Exists(directoryPathName))
                DirectoryPathName = Directory.CreateDirectory(directoryPathName).Name;
            if (!File.Exists(fileName))
            {
                FullFileName = Path.Combine(directoryPathName, fileName);
                File.Create(FullFileName);
                FileName = fileName;
            }
        }

        internal void WriteDownloadedFileToDisk(byte[] fileData)
        {
            using (var file = new FileStream(FullFileName, FileMode.Open))
            {
                file.Write(fileData, 0, fileData.Length);
            }
            RenameFile();
        }

        internal void WriteDownloadedFileToDiskOldAsync(byte[] fileData)
        {
            var result = new Action(() =>
          {
              using (var file = new FileStream(FullFileName, FileMode.Open))
              {
                  file.Write(fileData, 0, fileData.Length);
              }
          });
            result.BeginInvoke(new AsyncCallback(RenameFile), null);
        }

        private void RenameFile(IAsyncResult result)
        {
            File.Move(FullFileName, FullFileName.Replace(FileName, "processed.zip"));
        }

        internal async Task WriteDownloadedFileToDiskAsync(byte[] fileData)
        {
            using (var file = new FileStream(FullFileName, FileMode.Open))
            {
                await file.WriteAsync(fileData, 0, fileData.Length);
            }
            RenameFile();
        }
        private void RenameFile()
        {
            File.Move(FullFileName, FullFileName.Replace(FileName, "processed.zip"));
        }
    }
}
