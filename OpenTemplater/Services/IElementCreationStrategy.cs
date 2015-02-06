using OpenTemplater.Elements;

namespace OpenTemplater.Services
{
    public interface IElementCreationStrategy
    {
        
    }

    public interface IElementCreationStrategy<in TInput, out TOutput> : IElementCreationStrategy where TInput : IElementCreationInput where TOutput : IElement, new()
    {
        TOutput GetElement();
    }
}