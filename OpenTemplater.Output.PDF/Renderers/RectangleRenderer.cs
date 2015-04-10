using System;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OpenTemplater.Elements;
using OpenTemplater.Output.PDF.Layout;
using CMYKColor = iTextSharp.text.pdf.CMYKColor;

namespace OpenTemplater.Output.PDF.Renderers
{
    public class RectangleRenderer : BaseRenderer<RectangleElement>
    {
        private readonly ColorFactory _colorFactory;

        public RectangleRenderer(RectangleElement rectangleElement, RenderContext renderContext, ColorFactory colorFactory)
            : base(rectangleElement, renderContext)
        {
            if (colorFactory == null) throw new ArgumentNullException("colorFactory");
            _colorFactory = colorFactory;
        }

        public override void Render()
        {
            TransformedLayout layout = RenderContext.PDFLayoutTransformer.GetLayout(Element.XPosition,
                Element.YPosition, Element.Width, Element.Height);

            var rectangle = new Rectangle(layout.LowerLeftX, layout.LowerLeftY, layout.UpperRightX, layout.UpperRightY);

            
            rectangle.BorderColor = _colorFactory.GetColor(Element.BorderColor);
            rectangle.BorderWidth = Element.BorderWidth;
            rectangle.BackgroundColor = _colorFactory.GetColor(Element.Color);

            RenderContext.Document.Add(rectangle);
            
        }
    }
}