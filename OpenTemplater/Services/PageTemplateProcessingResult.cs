using System.Collections.Generic;
using OpenTemplater.Elements;

namespace OpenTemplater.Services
{
    public class PageTemplateProcessingResult
    {
        public PageTemplateProcessingResult()
        {
            StaticContents = new List<IPositionedElement>();
            DynamicContents = new List<IPositionedElement>();
        }

        public string Key { get; set; }
        public List<IPositionedElement> StaticContents { get; private set; }
        public List<IPositionedElement> DynamicContents { get; private set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float BleedSpace { get; set; }
        public float SlugSpace { get; set; }
        public float DynamicContentTopMargin { get; set; }
        public float DynamicContentBottomMargin { get; set; }
    }
}