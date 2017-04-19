using Microsoft.Owin.Security.OAuth;
using SimpleInjector;
using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace prmToolkit.Log.Api.Seguranca
{
    public class AuthorizationApi : OAuthAuthorizationServerProvider
    {
        private readonly Container _container;

        public AuthorizationApi(Container container)
        {
            _container = container;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

                Validation.ArgumentsValidator.RaiseExceptionOfInvalidArguments("Dados de autenticação invalidos",
                        Validation.RaiseException.IfTrue(context.UserName !="paulo"),
                        Validation.RaiseException.IfTrue(context.Password != "123")
                );


                var usuarioLogado = new { Id = 26, Nome = "Paulo" };

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                //Definindo as Claims
                identity.AddClaim(new Claim("Funcionario", Newtonsoft.Json.JsonConvert.SerializeObject(usuarioLogado)));

                GenericPrincipal principal = new GenericPrincipal(identity, new string[] { });

                Thread.CurrentPrincipal = principal;

                context.Validated(identity);
            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", ex.Message);
                return;
            }
        }


    }
}