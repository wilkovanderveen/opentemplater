using System.Collections.Generic;

namespace OpenTemplater.Elements
{
    public class RectangleElement : IColoredPositionedElement, IElementContainer
    {
        public RectangleElement()
        {
            Elements = new List<IPositionedElement>();
        }

        public float BorderWidth { get; set; }
        public IColor BorderColor { get; set; }
        public string Key { get;  set; }
        public float XPosition { get; set; }
        public float YPosition { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public IColor Color { get; set; }
        public IList<IPositionedElement> Elements { get; private set; }
    }
}