using System;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OpenTemplater.Output.PDF.Layout;

namespace OpenTemplater.Output.PDF
{
    public class RenderContext
    {
        public RenderContext(Document document, PdfContentByte pdfContentByte, PDFLayoutTransformer pdfLayoutTransformer)
        {
            if (document == null) throw new ArgumentNullException("document");
            if (pdfContentByte == null) throw new ArgumentNullException("pdfContentByte");
            if (pdfLayoutTransformer == null) throw new ArgumentNullException("pdfLayoutTransformer");

            Document = document;
            PDFLayoutTransformer = pdfLayoutTransformer;
            Content = pdfContentByte;
        }

        public PDFLayoutTransformer PDFLayoutTransformer { get; private set; }
        public Document Document { get; private set; }
        public PdfContentByte Content { get; private set; }
    }
}