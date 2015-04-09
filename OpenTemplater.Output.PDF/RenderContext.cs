using iTextSharp.text;

namespace OpenTemplater.Output.PDF
{
    public class RenderContext
    {
        public RenderContext(Document document, PDFLayoutTransformer pdfLayoutTransformer)
        {
            Document = document;
            PDFLayoutTransformer = pdfLayoutTransformer;
        }

        public PDFLayoutTransformer PDFLayoutTransformer { get; private set; }

        public Document Document { get; private set; }
    }
}