namespace OpenTemplater.Services
{
    public class TextCreationInput : BaseElementCreationInput, IElementCreationInput
    {
        public TextCreationInput(string key) : base(key)
        {
        }


        public override string Name
        {
            get { return "Text"; }
        }

        public IElementLayoutCreationInput LayoutCreationInput { get; private set; }
    }
}