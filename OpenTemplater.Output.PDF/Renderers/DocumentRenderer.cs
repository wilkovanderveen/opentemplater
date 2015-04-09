using System;
using iTextSharp.text;
using OpenTemplater.Elements;

namespace OpenTemplater.Output.PDF.Renderers
{
    public class DocumentRenderer : IRenderer
    {
        private readonly DocumentElement _documentElement;
        private readonly RenderContext _renderContext;

        public DocumentRenderer(DocumentElement documentElement, RenderContext renderContext)
        {
            if (documentElement == null) throw new ArgumentNullException("documentElement");
            if (renderContext == null) throw new ArgumentNullException("renderContext");

            _documentElement = documentElement;
            _renderContext = renderContext;
        }

        public void Render()
        {
            _renderContext.Document.AddAuthor(_documentElement.Author);
        }
    }
}