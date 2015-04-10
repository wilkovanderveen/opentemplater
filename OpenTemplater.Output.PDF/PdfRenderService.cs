using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OpenTemplater.Elements;
using OpenTemplater.Output.PDF.Layout;
using OpenTemplater.Output.PDF.Renderers;

namespace OpenTemplater.Output.PDF
{
    public class PdfRenderService
    {
        public void Render(DocumentElement documentElement)
        {
            var pdfDocument = new Document(PageSize.A4, 50, 50, 25, 25);

            // Create a new PdfWriter object, specifying the output stream
            var output = new FileStream(("MyFirstPDF.pdf"), FileMode.Create);
            var writer = PdfWriter.GetInstance(pdfDocument, output);

            pdfDocument.Open();

            RenderContext renderContext = new RenderContext(pdfDocument, writer.DirectContent, new PDFLayoutTransformer());

            DocumentRenderer documentRenderer = new DocumentRenderer(documentElement, renderContext);
            
            documentRenderer.Render();

            renderContext.Document.Close();

            writer.Close();
        }
    }
}