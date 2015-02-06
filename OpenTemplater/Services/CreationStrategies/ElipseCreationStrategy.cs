using System;
using OpenTemplater.Elements;

namespace OpenTemplater.Services.CreationStrategies
{
    public class ElipseCreationStrategy : BaseElementCreationStrategy<ElipseCreationInput, ElipseElement>
    {
        public ElipseCreationStrategy(DocumentContext documentContext, ElipseCreationInput input) : base(documentContext, input)
        {
        }

        public override ElipseElement GetElement()
        {
            throw new NotImplementedException();
        }
    }
}