using System;

namespace OpenTemplater.Services
{
    public class RectangleCreationInput : BaseElementCreationInput, IElementLayoutCreationInput
    {
        public RectangleCreationInput(string key) : base(key)
        {
        }

        public string FillColor { get; set; }
        public string BorderColor { get; set; }
        public string BorderWidth { get; set; }

        public XLayoutInput XLayoutInput { get; set; }
        public YLayoutInput YLayoutInput { get; set; }
        public WidthInput WidthInput { get; set; }
        public HeightInput HeightInput { get; set; }

        public override string Name
        {
            get { return "Rectangle"; }
        }
    }

    public abstract class BaseElementCreationInput
    {
        public abstract string Name { get; }
       
        public string Key { get; private set; }
        public string ZOrder { get; set; }

        protected BaseElementCreationInput(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("key");

            Key = key;
        }
    }
}