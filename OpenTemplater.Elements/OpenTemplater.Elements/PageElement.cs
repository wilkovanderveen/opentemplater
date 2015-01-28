using System.Collections.Generic;

namespace OpenTemplater.Elements
{
    public class PageElement : IElement, IElementContainer
    {
        public PageElement()
        {
            Elements = new List<IPositionedElement>();
        }

        public string Key { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public IList<IPositionedElement> Elements { get; set; }
    }
}