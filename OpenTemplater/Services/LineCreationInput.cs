namespace OpenTemplater.Services
{
    public class LineCreationInput : BaseElementCreationInput, IElementCreationInput
    {
        public LineCreationInput(string key) : base(key)
        {
        }

        public override string Name
        {
            get { return "Line"; }
        }
    }
}