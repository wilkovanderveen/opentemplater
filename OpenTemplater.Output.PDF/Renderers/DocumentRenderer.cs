using System;
using iTextSharp.text;
using OpenTemplater.Elements;

namespace OpenTemplater.Output.PDF.Renderers
{
    public class DocumentRenderer : IRenderer<DocumentElement>
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
            _renderContext.Document.AddCreationDate();

            if (!string.IsNullOrEmpty(_documentElement.Author))
            {
                _renderContext.Document.AddAuthor(_documentElement.Author);
            }

            if (!string.IsNullOrEmpty(_documentElement.Subject))
            {
                _renderContext.Document.AddSubject(_documentElement.Subject);
            }

            RenderChildren(_documentElement);
        }

        private void RenderChildren(DocumentElement documentElement)
        {
            foreach (PageElement pageElement in documentElement.Pages)
            {
                PageRenderer pageRenderer = new PageRenderer(pageElement, _renderContext, new ElementRendererFactory(_renderContext));
                pageRenderer.Render();
            }
        }
    }
}