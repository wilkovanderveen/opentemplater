using System;
using OpenTemplater.Elements;

namespace OpenTemplater.Output.PDF.Renderers
{
    public class PageRenderer : BaseRenderer<PageElement>
    {
        private readonly ElementRendererFactory _elementRendererFactory;

        public PageRenderer(PageElement pageElement, RenderContext renderContext, ElementRendererFactory elementRendererFactory) : base(pageElement, renderContext)
        {
            if (elementRendererFactory == null) throw new ArgumentNullException("elementRendererFactory");
            _elementRendererFactory = elementRendererFactory;
        }

        public override void Render()
        {
            RenderContext.Document.NewPage();

            foreach (IPositionedElement childElement in Element.Elements)
            {
               IRenderer renderer =  _elementRendererFactory.GetRenderer(childElement);
               renderer.Render();
            }
        }
    }
}