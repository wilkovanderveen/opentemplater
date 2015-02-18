using System.Collections.Generic;

namespace OpenTemplater.Services
{
    public class PageTemplateInput
    {
        public PageTemplateInput()
        {
        
        }

        public string Key { get; set; }

       
        public DynamicContentInput DynamicContent { get; set; }
        public StaticContentInput StaticContent { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string BleedSpace { get; set; }
        public string SlugSpace { get; set; }
    }
}