using System.Threading.Tasks;

namespace prmToolkit.Log.Interfaces
{
    public interface ILog 
    {
        void Save(string message);

        Task SaveAsync(string message);
    }
}
