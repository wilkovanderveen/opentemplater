namespace OpenTemplater.Services
{
    public class ImageCreationInput : BaseElementCreationInput, IElementCreationInput
    {
        public ImageCreationInput(string key) : base(key)
        {
        }
        
        public string FileName { get; set; }
        public string Dpi { get; set; }

        public override string Name
        {
            get { return "Image"; }
        }
    }
}