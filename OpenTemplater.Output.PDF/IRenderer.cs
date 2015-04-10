namespace OpenTemplater.Output.PDF
{
    public interface IRenderer<T> : IRenderer
    {
        
    }

    public interface IRenderer
    {
        void Render();
    }
}