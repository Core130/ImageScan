using iTextSharp.text;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;

namespace ImageScann.BLL
{
    public class ImageToPdf
    {        
        /// <summary>
        /// 图片转换为pdf
        /// </summary>
        /// <param name="imgFiles">要转换的图片完整路径</param>
        /// <param name="pdfPath">pdf存放的完整路径</param>
        public void ExportDataIntoPDF(List<string> imgFiles, string pdf)
        {
            Document document = new Document(PageSize.A4, 25, 25, 25, 25);
            try
            {
                iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream(pdf, FileMode.Create, FileAccess.ReadWrite));
                document.Open();
                Image image;
                foreach (var item in imgFiles)
                {
                    if (string.IsNullOrEmpty(item)) break;

                    image = Image.GetInstance(item);

                    if (image.Height > PageSize.A4.Height - 25)
                    {
                        image.ScaleToFit(PageSize.A4.Width - 25, PageSize.A4.Height - 25);
                    }
                    else if (image.Width > PageSize.A4.Width - 25)
                    {
                        image.ScaleToFit(PageSize.A4.Width - 25, PageSize.A4.Height - 25);
                    }
                    image.Alignment = Element.ALIGN_MIDDLE;
                    document.NewPage();
                    document.Add(image);
                    //Chunk c1 = new Chunk("Hello World");
                    //Phrase p1 = new Phrase();
                    //p1.Leading = 150;      //行间距
                    //document.Add(p1);
                }               
            }
            catch (Exception )
            {
                
            }
            document.Close();

        }


    }
}
