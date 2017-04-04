using prmToolkit.Log.Interfaces;
using prmToolkit.Validation;
using System.Threading.Tasks;

namespace prmToolkit.Log
{
    public sealed class FileLog : ILog
    {
        private readonly string _filePath;
        public FileLog(string filePath)
        {
            _filePath = filePath;
        }

        public void Save(string message)
        {
            RaiseException.IfNullOrEmpty(message, "O argumento message é obrigatório", true);
        }

        public async Task SaveAsync(string message)
        {
            await Task.Run(() => Save(message));
        }
    }
}
