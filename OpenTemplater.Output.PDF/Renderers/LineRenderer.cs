using System;
using OpenTemplater.Elements;

namespace OpenTemplater.Output.PDF.Renderers
{
    public class LineRenderer : BaseRenderer<LineElement>
    {
        private readonly ColorFactory _colorFactory;

        public LineRenderer(LineElement lineElement, RenderContext renderContext, ColorFactory colorFactory) : base(lineElement, renderContext)
        {
            if (colorFactory == null) throw new ArgumentNullException("colorFactory");
            _colorFactory = colorFactory;
        }

        public override void Render()
        {
            RenderContext.Content.MoveTo(Element.XPosition, Element.YPosition);
            RenderContext.Content.SetColorStroke(_colorFactory.GetColor(Element.Color));
            RenderContext.Content.SetLineWidth(Element.LineWidth);
            RenderContext.Content.LineTo(Element.XPosition + Element.Width, Element.YPosition + Element.Height);
            RenderContext.Content.ClosePathStroke();
        }
    }
}