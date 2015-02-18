namespace OpenTemplater.Services
{
    public class RectangleLayoutCreationInput : IElementLayoutCreationInput, IElementCreationInput 
    {
        public XLayoutInput XLayoutInput { get; set; }
        public YLayoutInput YLayoutInput { get; set; }
        public WidthInput WidthInput { get; set; }
        public HeightInput HeightInput { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string ZOrder { get; set; }
    }
}