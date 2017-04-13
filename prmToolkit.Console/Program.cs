using prmToolkit.Log;
using prmToolkit.Log.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace prmToolkit.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Jogando 3000000 itens no array....");
            List<string> mensagens = new List<string>();
            for (int i = 0; i < 1000000; i++)
            {
                
                string mensagem = $" {i.ToString()} --> {Faker.Name.GetFullName()}";
                mensagens.Add(mensagem);

                Console.WriteLine(mensagem);
            }

            Console.WriteLine("Gravando log....");

            mensagens.AsParallel().ForAll(x =>
            {
                LogManager.Save(x, EnumMessageType.Error);
                Console.WriteLine(x);
            });

            Console.WriteLine("..........FIM..........");
            Console.ReadKey();
        }
    }
}
