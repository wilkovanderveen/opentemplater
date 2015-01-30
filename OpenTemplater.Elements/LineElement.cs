namespace OpenTemplater.Elements
{
    public class LineElement : IColoredPositionedElement
    {
        public float LineWidth { get; set; }
        public string Key { get; private set; }
        public float XPosition { get; set; }
        public float YPosition { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public IColor Color { get; set; }
    }
}