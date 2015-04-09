using OpenTemplater.Elements;

namespace OpenTemplater.Output.PDF.Renderers
{
    public class PageRenderer : BaseRenderer<PageElement>
    {
        public PageRenderer(PageElement pageElement, RenderContext renderContext) : base(pageElement, renderContext)
        {
        }

        public override void Render()
        {
            RenderContext.Document.NewPage();

            // TODO : Render child elements.
        }
    }
}