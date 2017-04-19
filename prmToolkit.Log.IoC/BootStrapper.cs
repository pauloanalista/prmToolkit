using prmToolkit.Log.Application.Interfaces;
using prmToolkit.Log.Application.Services;
using prmToolkit.Log.Domain.Interfaces.Repositories;
using prmToolkit.Log.Domain.Interfaces.Services;
using prmToolkit.Log.Domain.Services;
using prmToolkit.Log.Infra.Persistencia.AdoNet;
using SimpleInjector;


namespace prmToolkit.Log.IoC
{
    public class BootStrapper
    {
        // Lifestyle.Transient => Uma instancia para cada solicitacao;
        // Lifestyle.Singleton => Uma instancia unica para a classe;
        // Lifestyle.Scoped => Uma instancia unica para o request;

        public static void RegisterWebApi(Container container)
        {

            //Serviços de aplicação
            container.Register<ILogMessageApplication, LogMessageApplication>(Lifestyle.Scoped);

            //Serviços de domínio
            container.Register<ILogMessageService, LogMessageService>(Lifestyle.Scoped);

            //Infra Repositórios
            container.Register<ILogMessageRepository, LogMessageRepository>(Lifestyle.Scoped);

        }
    }
}
