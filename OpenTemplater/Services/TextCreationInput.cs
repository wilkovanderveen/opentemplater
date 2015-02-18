namespace OpenTemplater.Services
{
    public class TextCreationInput : IElementCreationInput
    {
        public string Key { get; private set; }
        public string Name { get; private set; }
        public string ZOrder { get; private set; }
        public IElementLayoutCreationInput LayoutCreationInput { get; private set; }
    }
}