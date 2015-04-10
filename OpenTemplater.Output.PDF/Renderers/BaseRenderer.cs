using OpenTemplater.Elements;

namespace OpenTemplater.Output.PDF.Renderers
{
    public abstract class BaseRenderer<T> : IRenderer<T> where T : IElement
    {
        protected T Element { get; private set; }

        protected BaseRenderer(T element, RenderContext renderContext)
        {
            Element = element;
            RenderContext = renderContext;
        }


        protected RenderContext RenderContext { get; private set; }

        public abstract void Render();
    }
}