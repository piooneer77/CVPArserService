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
        public static Func<String, String> CreateConversionMethod(String fileName)
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
        private static String ConvertFromPDF(String file)
        {
            StringBuilder pdfText = new StringBuilder();
            using (PdfReader reader = new PdfReader(file))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    pdfText.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }
            }
            return pdfText.ToString();
        }

        private static String ConvertFromDOCX(String file)
        {
            String text;
            using (WordprocessingDocument wordDocx = WordprocessingDocument.Open(file, false))
            {
                text = EnhanceDocxText(wordDocx.MainDocumentPart.Document.InnerText);
            }
            return text.ToString();
        }

        private static String ConvertFromConventionalText(String file)
        {
            return File.ReadAllText(file, Encoding.Default);
        }

        private static String EnhanceDocxText(String text)
        {
            text = text.Replace("44458890", "");
            return text;
        }
        #endregion

    }
}
