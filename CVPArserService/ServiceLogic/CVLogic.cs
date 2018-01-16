using System.IO;
using System.Web;

namespace CVPArserService.ServiceLogic
{
    public class CVLogic
    {
        public void saveFile(HttpPostedFile file)
        {
            file.SaveAs(System.Web.Hosting.HostingEnvironment.MapPath("~/Data/CVRawFiles") + file.FileName);
        }

        private FileStream getTextVersionFromUploadedFile(HttpPostedFile file)
        {
            return File.Create(System.Web.Hosting.HostingEnvironment.MapPath("~/Data/CVTextFiles") + file.FileName);
        }
    }
}