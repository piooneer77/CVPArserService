using CVPArserService.ServiceLogic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CVPArserService.Controllers
{
    public class FileController : ApiController
    {
        [HttpPost]
        [Route("upload")]
        public HttpResponseMessage upload(HttpPostedFile file)
        {
            CVLogic logic = new CVLogic();
            logic.saveFile(file);
            return Request.CreateResponse(HttpStatusCode.Created, file);
        }
    }
}