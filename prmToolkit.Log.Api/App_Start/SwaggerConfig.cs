using System.Web.Http;
using WebActivatorEx;
using prmToolkit.Log.Api;
using Swashbuckle.Application;

//[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace prmToolkit.Log.Api
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "prmToolkit")
                    .License(l =>
                    {
                        l.Name("MIT");
                        l.Url("http://ilovecode.com.br");
                    })
                    .Contact(ct =>
                    {
                        ct.Name("Desenvolvido por Paulo");
                        ct.Email("paulo.analista@outlook.com");
                        ct.Url("http://ilovecode.com.br");
                    })
                    .Description("Api responsável por gerenciar logs")
                    .TermsOfService("Nenhum");
            })
                .EnableSwaggerUi(c =>
                {

                });
        }
    }
}
