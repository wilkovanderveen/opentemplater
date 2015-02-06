using OpenTemplater.Elements;
using OpenTemplater.Services.CreationStrategies;

namespace OpenTemplater.Services
{
    public abstract class BaseElementCreationStrategy<TInput, TOutput> :
        IElementCreationStrategy<TInput, TOutput> where TInput : IElementCreationInput where TOutput : IElement, new()
    {
        protected DocumentContext DocumentContext { get; private set; }
        protected TInput Input { get; private set; }

        protected BaseElementCreationStrategy(DocumentContext documentContext,  TInput input)
        {
            DocumentContext = documentContext;
            Input = input;
        }

        public virtual void SetLayout()
        {
           
        }

        public abstract TOutput GetElement();
    }
}