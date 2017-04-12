using prmToolkit.Log.Enum;
using System.Threading.Tasks;

namespace prmToolkit.Log.Interfaces
{
    public interface ILog 
    {
        void Save(string message, EnumMessageType enumMessageType);

        Task SaveAsync(string message, EnumMessageType enumMessageType);
    }
}
