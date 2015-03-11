namespace OpenTemplater.Services
{
    public class ElipseCreationInput : BaseElementCreationInput, IElementCreationInput
    {
        public ElipseCreationInput(string key)
            : base(key)
        {
        }

        public override string Name
        {
            get { return "Elipse"; }
        }

        public byte? ZOrder { get; set; }
    }
}