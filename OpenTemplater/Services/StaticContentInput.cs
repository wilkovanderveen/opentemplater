using System.Collections.Generic;

namespace OpenTemplater.Services
{
    public class StaticContentInput
    {
        public StaticContentInput()
        {
            Elements = new List<IElementCreationInput>();
        }

        public IList<IElementCreationInput> Elements { get; private set; }
    }
}