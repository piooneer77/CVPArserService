using CVPArserService.ServiceLogic;
using System.Web;
using System.Web.Http;

namespace CVPArserService.Controllers
{
    public class FileController : ApiController
    {
        [HttpPost]
        [Route("upload")]
        public IHttpActionResult upload()
        {
            HttpRequest request = HttpContext.Current.Request;
            CVLogic logic = new CVLogic();
            if(request.Files.Count >= 1)
            {
                return Content(System.Net.HttpStatusCode.BadRequest, "One File Allowed");
            } 
            else
            {
                logic.saveFile(request.Files[0]);
                return Ok(request.Files);
            }
        }
    }
}