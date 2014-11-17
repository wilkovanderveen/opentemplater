namespace OpenTemplater.Elements.Modules
{
    public class Layout
    {
        public Layout(float xPosition, float yPosition, float width, float height)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            Width = width;
            Height = height;
        }

        public float XPosition { get; set; }
        public float YPosition { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
    }
}