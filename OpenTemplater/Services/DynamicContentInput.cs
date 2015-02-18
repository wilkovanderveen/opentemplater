namespace OpenTemplater.Services
{
    public class DynamicContentInput : StaticContentInput
    {
        public string X { get; set; }
        public string Y { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string OverflowTemplate { get; set; }
    }
}