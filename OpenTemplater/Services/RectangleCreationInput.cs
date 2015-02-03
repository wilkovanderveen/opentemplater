namespace OpenTemplater.Services
{
    public class RectangleCreationInput : IElementCreationInput
    {
        public string FillColor { get; set; }
        public string BorderColor { get; set; }
        public string BorderWidth { get; set; }
        public string ZOrder { get; set; }

        public string Name
        {
            get { return "Rectangle"; }
        }

        public string Key { get; set; }

        public IElementLayoutInput LayoutInput { get; set; }
    }
}