using CVPArserService.ServiceLogic;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CVPArserService.Models
{
    public class CvFile
    {
        #region Properties
        public string FileText { get; set; }
        public string[] fileWords { set; get; }
        #endregion

        #region Constructors
        public CvFile(FileInfo file)
        {
            this.FileText = getFileText(file);
            this.fileWords = splitFileTextToWords(this.FileText);
        }
        #endregion

        #region Public Methods.

        #endregion

        #region Private Methods
        private String getFileText(FileInfo file)
        {
            Task<String> task = new Task<String>(() => CSVConvertorMethodFactory.CreateConversionMethod(file.Name).Invoke(file));
            task.Start();
            return task.Result;
        }
        private String[] splitFileTextToWords(String text)
        {
            char delimeter = Convert.ToChar(" ");
            Task<String[]> task = new Task<String[]>(() => text.Split(delimeter));
            task.Start();
            return task.Result;
        }
        #endregion
    }
}