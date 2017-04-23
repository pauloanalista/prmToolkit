using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace prmToolkit.Log.Api.Controllers
{
    [RoutePrefix("api/teste")]
    public class TesteController : ApiController
    {
        [Route("status")]
        [HttpGet]
        public Task<HttpResponseMessage> Status()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            var resultado = new { Nome = "Paulo Rogerio", Idade = 35 };

            response = Request.CreateResponse(HttpStatusCode.OK, resultado);

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

     
    }
}
