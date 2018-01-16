using System.IO;
using System.Web;

namespace CVPArserService.ServiceLogic
{
    public class CVLogic
    {
        public void saveFile(HttpPostedFile postedFile)
        {
            postedFile.SaveAs(System.Web.Hosting.HostingEnvironment.MapPath("~/Data/CVRawFiles") + postedFile.FileName);
        }

        //private FileStream getTextVersionFromUploadedFile(HttpPostedFile file)
        //{
        //    return File.WriteAllBytes(System.Web.Hosting.HostingEnvironment.MapPath("~/Data/CVTextFiles") + file.FileName);
        //}
    }
}