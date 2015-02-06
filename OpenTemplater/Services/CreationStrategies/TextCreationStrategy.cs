using System;
using OpenTemplater.Elements;

namespace OpenTemplater.Services.CreationStrategies
{
    public class TextCreationStrategy : BaseElementCreationStrategy<TextCreationInput, TextElement>
    {
        public TextCreationStrategy(DocumentContext documentContext, TextCreationInput input) : base(documentContext, input)
        {
        }

        public override TextElement GetElement()
        {
            throw new NotImplementedException();
        }
    }
}