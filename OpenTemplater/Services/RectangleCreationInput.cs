namespace OpenTemplater.Services
{
    public class RectangleCreationInput : IElementCreationInput, IElementLayoutCreationInput
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

        public XLayoutInput XLayoutInput { get; set; }
        public YLayoutInput YLayoutInput { get; set; }
        public WidthInput WidthInput { get; set; }
        public HeightInput HeightInput { get; set; }
    }
}