using System;
using OpenTemplater.Elements;

namespace OpenTemplater.Output.PDF.Renderers
{
    public class ElementRendererFactory
    {
        private readonly RenderContext _renderContext;

        public ElementRendererFactory(RenderContext renderContext)
        {
            if (renderContext == null) throw new ArgumentNullException("renderContext");
            _renderContext = renderContext;
        }

        public IRenderer GetRenderer(IElement element)
        {
            switch (element.GetType().Name)
            {
                case "RectangleElement":
                    return new RectangleRenderer(element as RectangleElement, _renderContext, new ColorFactory());

                case "LineElement":
                    return new LineRenderer(element as LineElement, _renderContext, new ColorFactory());
            }
            throw new NotSupportedException(string.Format("Element of type {0} is not supported.",
                element.GetType().Name));
        }
    }
}