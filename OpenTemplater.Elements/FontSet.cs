using System.Collections.Generic;

namespace OpenTemplater.Elements
{
    public class FontSet
    {
        private readonly IDictionary<FontStyle, string> _fontsDictionary;

        public FontSet()
        {
            _fontsDictionary = new Dictionary<FontStyle, string>();
        }

        public void AddFont(FontStyle fontStyle, string fontPath)
        {
            _fontsDictionary.Add(fontStyle,fontPath);
        }
    }
}