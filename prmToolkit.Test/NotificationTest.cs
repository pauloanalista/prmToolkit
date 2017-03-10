using Microsoft.VisualStudio.TestTools.UnitTesting;
using prmToolkit.Notification;

namespace prmToolkit.Test
{
    [TestClass]
    public class NotificationTest
    {
        [TestMethod]
        public void ValidateCondition_Valida_Argumento_Nome()
        {
            //Iniciar o monitoramento das mensagens, normalmente ficara em um base da controller da api
            NotificationManager.Start();

            //Validacoes que irao ocorrer em várias camadas do sistema
            string nome = string.Empty;
            int idade = 35;

            //Camada de serviços de aplicacao
            AddNotification.IfEmpty(nome, "Nome é obrigatório", "Metodo personalizado que chamou");

            //Camada de serviços (Dominio)
            AddNotification.IfNotGreaterThan(idade, 100, "Valor dever se maior que o segundo valor");

            //Camada de infra
            TesteNomeDoMetodoQueFezSolicitacao();

            //Verifica se todas as validações estão de válidas
            bool valid = NotificationManager.IsValid();

            //Obtém a lista de mensagens para apresentar para o usuário
            var lista = NotificationManager.GetNotifications();

            //Limpa lista de notificações
            NotificationManager.End();


            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(valid, "O argumento nao é verdadeiro");
        }

        private void TesteNomeDoMetodoQueFezSolicitacao()
        {
            string variavel = "123455";

            AddNotification.IfNotGuid(variavel, "Nao é um guid valido");

        }
    }
}
