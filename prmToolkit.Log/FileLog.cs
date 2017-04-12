using prmToolkit.EnumExtension;
using prmToolkit.Log.Enum;
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
        private static string _dataArquivo = string.Empty;
        private static DateTime? _dataUltimaCriacao;
        
        public FileLog(string folderPath, string applicationName)
        {
            _folderPath = folderPath;
            _applicationName = applicationName;
            _fileName = applicationName + ".log";
        }

        
        public void Save(string message, EnumMessageType enumMessageType = EnumMessageType.Information)
        {
            // Set Locked
            _readWriteLock.EnterWriteLock();
            try
            {
                if (!_dataUltimaCriacao.HasValue || DateTime.Now.Day != _dataUltimaCriacao.Value.Day)
                {
                    //Verifica se o arquivo existe
                    if (File.Exists(GetFilePath()))
                    {
                        //Renomeia o arquivo antigo
                        RenameOldFile();
                    }

                    _dataUltimaCriacao = DateTime.Now;
                }
                

                // Grava o arquivo
                using (StreamWriter sw = File.AppendText(GetFilePath()))
                {
                    message = $"{DateTime.Now} - {enumMessageType.GetDescription()} -> {message}";
                    
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

        public async Task SaveAsync(string message, EnumMessageType enumMessageType = EnumMessageType.Information)
        {
            await Task.Run(() => Save(message, enumMessageType));
        }

        

        private string GetFilePath()
        {
            return Path.Combine(_folderPath, _fileName);
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



