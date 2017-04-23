using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using prmToolkit.Log.Api.Seguranca;
using prmToolkit.Log.IoC;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Web.Http;

namespace prmToolkit.Log.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Classe responsavel por configuar a webapi
            HttpConfiguration config = new HttpConfiguration();

            //Configura a documentação automatica atraves do Swagger
            SwaggerConfig.Register(config);

            //Container de inversao de controle
            var container = new Container();

            //Configura a inversao controle
            ConfigureDependencyInjection(config, container);

            ConfigureWebApi(config);
            ConfigureOAuth(app, container);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        private void ConfigureOAuth(IAppBuilder app, Container container)
        {
            OAuthAuthorizationServerOptions oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(30),
                Provider = new AuthorizationApi(container)
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        private void ConfigureWebApi(HttpConfiguration config)
        {

            //config.MessageHandlers.Add(new LogApiHandler());


            //Remove suporte ao xml
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            var jsonSettings = config.Formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            jsonSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            config.MapHttpAttributeRoutes();
        }

        private void ConfigureDependencyInjection(HttpConfiguration config, Container container)
        {
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            BootStrapper.RegisterWebApi(container);
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

        }
    }
}