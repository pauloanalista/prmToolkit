using prmToolkit.Log;
using prmToolkit.Log.Enum;
using System;
using System.Threading;

namespace prmToolkit.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string mensagem = Faker.Name.FullName();

                LogManager.Save(mensagem, EnumMessageType.Error);

                Console.WriteLine(mensagem);

                Thread.Sleep(100);
            }
        }
    }
}
