using System;

namespace OpenTemplater.Elements
{
    public class RGBColor : IColor
    {
        public RGBColor(string key, byte red, byte green, byte blue)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("key");
            Key = key;
            Red = red;
            Green = green;
            Blue = blue;
        }

        public byte Red { get; private set; }
        public byte Green { get; private set; }
        public byte Blue { get; private set; }
        public string Key { get; set; }
    }
}