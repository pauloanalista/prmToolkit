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
                LogManager.Save("Gravando log em " + DateTime.Now);

                Console.Write("Gravando" + DateTime.Now);

                Thread.Sleep(20000);
            }
        }
    }
}
