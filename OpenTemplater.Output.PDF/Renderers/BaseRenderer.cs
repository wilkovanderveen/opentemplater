using OpenTemplater.Elements;

namespace OpenTemplater.Output.PDF.Renderers
{
    public abstract class BaseRenderer<T> : IRenderer where T : IElement
    {
        protected BaseRenderer(T element, RenderContext renderContext)
        {
            Element = element;
            RenderContext = renderContext;
        }

        protected T Element { get; private set; }
        protected RenderContext RenderContext { get; private set; }

        public abstract void Render();
    }
}