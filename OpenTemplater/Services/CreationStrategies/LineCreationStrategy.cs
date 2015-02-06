using System;
using OpenTemplater.Elements;

namespace OpenTemplater.Services.CreationStrategies
{
    public class LineCreationStrategy : BaseElementCreationStrategy<LineCreationInput, LineElement>
    {
        public LineCreationStrategy(DocumentContext documentContext, LineCreationInput input) : base(documentContext, input)
        {
        }

        public override LineElement GetElement()
        {
            throw new NotImplementedException();
        }
    }
}