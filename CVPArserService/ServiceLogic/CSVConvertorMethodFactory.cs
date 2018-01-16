using DocumentFormat.OpenXml.Packaging;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.IO;
using System.Text;

namespace CVPArserService.ServiceLogic
{
    public class CSVConvertorMethodFactory
    {
        #region Public Methods.
        public static Func<FileInfo, String> CreateConversionMethod(String fileName)
        {
            if (fileName.ToLower().EndsWith(".docx"))
            {
                return ConvertFromDOCX;
            }
            else if (fileName.ToLower().EndsWith(".pdf"))
            {
                return ConvertFromPDF;
            }
            else
            {
                return ConvertFromConventionalText;
            }
        }
        #endregion

        #region Private Methods
        private static String ConvertFromPDF(FileInfo file)
        {
            StringBuilder pdfText = new StringBuilder();
            using (PdfReader reader = new PdfReader(file.FullName))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    pdfText.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }
            }
            return pdfText.ToString();
        }

        private static String ConvertFromDOCX(FileInfo file)
        {
            String text;
            using (WordprocessingDocument wordDocx = WordprocessingDocument.Open(file.FullName, false))
            {
                text = EnhanceDocxText(wordDocx.MainDocumentPart.Document.InnerText);
            }
            return text.ToString();
        }

        private static String ConvertFromConventionalText(FileInfo file)
        {
            return File.ReadAllText(file.FullName, Encoding.Default);
        }

        private static string EnhanceDocxText(string text)
        {
            text = text.Replace("44458890", "");
            return text;
        }
        #endregion

    }
}
}