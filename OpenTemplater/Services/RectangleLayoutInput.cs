namespace OpenTemplater.Services
{
    public class RectangleLayoutInput : IElementLayoutInput
    {
        public XLayoutInput XLayoutInput { get; set; }
        public YLayoutInput YLayoutInput { get; set; }
        public WidthInput WidthInput { get; set; }
        public HeightInput HeightInput { get; set; }
        public string Key { get; set; }
    }
}