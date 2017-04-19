using prmToolkit.Log.Application.Interfaces;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace prmToolkit.Log.Api.Controllers
{
    [RoutePrefix("api/log")]
    public class LogController : ApiController
    {
        private readonly ILogMessageApplication _logMessageApplication;
        public LogController(ILogMessageApplication logMessageApplication)
        {
            _logMessageApplication = logMessageApplication;
        }

        [Authorize]
        [Route("listarLog")]
        [HttpGet]
        public Task<HttpResponseMessage> ListarLog()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            var resultado = _logMessageApplication.ObterLogs();

            response = Request.CreateResponse(HttpStatusCode.OK, resultado);

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
    }
}
