using iTextSharp.text;
using OpenTemplater.Elements;

namespace OpenTemplater.Output.PDF.Renderers
{
    public class RectangleRenderer : BaseRenderer<RectangleElement>
    {
        public RectangleRenderer(RectangleElement rectangleElement, RenderContext renderContext)
            : base(rectangleElement, renderContext)
        {
        }

        public override void Render()
        {
            TransformedLayout layout = RenderContext.PDFLayoutTransformer.GetLayout(Element.XPosition,
                Element.YPosition, Element.Width, Element.Height);

            var rectangle = new Rectangle(layout.LowerLeftX, layout.LowerLeftY, layout.UpperRightX, layout.UpperRightY);

            RenderContext.Document.Add(rectangle);
        }
    }
}