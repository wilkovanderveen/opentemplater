using System;

namespace OpenTemplater.Elements
{
    public class CMYKColor : IColor
    {
        public CMYKColor(string key, Single cyan, Single magenta, Single yellow, Single black)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("key");

            if (cyan < 0 || cyan > 1)
            {
                throw new ArgumentOutOfRangeException("cyan");
            }

            if (magenta < 0 || magenta > 1)
            {
                throw new ArgumentOutOfRangeException("magenta");
            }

            if (yellow < 0 || yellow > 1)
            {
                throw new ArgumentOutOfRangeException("yellow");
            }

            if (black < 0 || black > 1)
            {
                throw new ArgumentOutOfRangeException("black");
            }

            Key = key;
            Cyan = cyan;
            Magenta = magenta;
            Yellow = yellow;
            Black = black;
        }

        public string Key { get; private set; }
        public Single Cyan { get; private set; }
        public Single Magenta { get; private set; }
        public Single Yellow { get; private set; }
        public Single Black { get; private set; }
    }
}