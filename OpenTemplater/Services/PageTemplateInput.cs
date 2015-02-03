using System.Collections.Generic;

namespace OpenTemplater.Services
{
    public class PageTemplateInput
    {
        public PageTemplateInput()
        {
            StaticElementInputs = new List<IElementCreationInput>();
            DynamicElementInputs = new List<IElementCreationInput>();
        }
        
        public string Key { get; set; }

        public IList<IElementCreationInput> StaticElementInputs { get; private set; }
        public IList<IElementCreationInput> DynamicElementInputs { get; private set; }
    }
}