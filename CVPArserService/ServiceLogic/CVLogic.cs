using System.IO;
using System.Web;;

namespace CVPArserService.ServiceLogic
{
    public class CVLogic
    {
        public void saveFile(HttpPostedFile postedFile)
        {
            postedFile.SaveAs(System.Web.Hosting.HostingEnvironment.MapPath("~/Data/CVRawFiles") + postedFile.FileName);
        }

        public FileInfo getTextVersionFromUploadedFile(string file)
        {
            string fileName = file.Split('.')[0];
            fileName = file.Split('/')[file.Split('/').Length - 1];
            FileInfo fileInfo = new FileInfo(System.Web.Hosting.HostingEnvironment.MapPath("~/Data/CVRawFiles") + fileName + ".txt");
            FileStream fileStream = fileInfo.Create();
            StreamWriter streamWriter = new StreamWriter(file, true);
            streamWriter.Write(CSVConvertorMethodFactory.CreateConversionMethod(file).Invoke(file));
            fileStream.Close();
            return fileInfo;
        }
    }
}