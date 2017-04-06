using prmToolkit.Log.Interfaces;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace prmToolkit.Log
{
    public sealed class FileLog : ILog
    {
        private static ReaderWriterLockSlim _readWriteLock = new ReaderWriterLockSlim();
        private readonly string _folderPath;
        private readonly string _applicationName;
        private readonly string _fileName;
        private string _caminhoArquivo;
        private static string _dataArquivo = string.Empty;
        public FileLog(string folderPath, string applicationName)
        {
            _folderPath = folderPath;
            _applicationName = applicationName;
            _fileName = applicationName + ".log";
        }

        public void Save(string message)
        {
            // Set Locked
            _readWriteLock.EnterWriteLock();
            try
            {
                //Verifica se o arquivo existe
                if (File.Exists(GetFilePath()))
                {
                    //Renomeia o arquivo antigo
                    RenameOldFile();
                }

                // Grava o arquivo
                using (StreamWriter sw = File.AppendText(GetFilePath()))
                {
                    sw.WriteLine(message);
                    sw.Close();
                }
            }
            finally
            {
                // Release lock
                _readWriteLock.ExitWriteLock();
            }
        }

        public async Task SaveAsync(string message)
        {
            await Task.Run(() => Save(message));
        }

        

        private string GetFilePath()
        {
            return Path.Combine(_folderPath, _applicationName) + ".txt";
        }

        private void RenameOldFile()
        {
            var fileOld = Path.Combine(_folderPath, _fileName.Replace(_fileName,
                $"{DateTime.Now.ToString("yyyyMMdd_HHmmss")}_{_fileName}"));
            try
            {
                File.Move(GetFilePath(), fileOld);
            }
            catch
            {
                // ignored
            }
        }

        
    }
}



