using prmToolkit.Log;
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

                string mensagem = string.Concat(DateTime.Now, " - ", Faker.Name.FullName());
                LogManager.Save(mensagem);

                Console.WriteLine(mensagem);

                Thread.Sleep(10000);
            }
        }
    }
}
