using System;
using OpenTemplater.Elements;

namespace OpenTemplater.Services.CreationStrategies
{
    public class ImageCreationStrategy : BaseElementCreationStrategy<ImageCreationInput, ImageElement>
    {
        public ImageCreationStrategy(DocumentContext documentContext, ImageCreationInput input) : base(documentContext, input)
        {
        }

        public override ImageElement GetElement()
        {
            throw new NotImplementedException();
        }
    }
}