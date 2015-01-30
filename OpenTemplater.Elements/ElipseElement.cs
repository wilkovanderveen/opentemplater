namespace OpenTemplater.Elements
{
    public class ElipseElement : IColoredPositionedElement
    {
        public float BorderWidth { get; set; }
        public IColor BorderColor { get; set; }
        public string Key { get; private set; }
        public float XPosition { get; set; }
        public float YPosition { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public IColor Color { get; set; }
    }
}