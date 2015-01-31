namespace OpenTemplater.Elements
{
    public class TextElement : IPositionedElement
    {
        public string Key { get; private set; }
        public float Width { get; private set; }
        public float Height { get; private set; }
        public float XPosition { get; private set; }
        public float YPosition { get; private set; }
        public byte ZOrder { get; private set; }
    }
}