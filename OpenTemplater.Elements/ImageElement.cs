namespace OpenTemplater.Elements
{
    public class ImageElement : IPositionedElement
    {
        public string Key { get; set; }
        public float XPosition { get; set; }
        public float YPosition { get; set; }
        public int ZOrder { get; private set; }
        public float Width { get; set; }
        public float Height { get; set; }
    }
}