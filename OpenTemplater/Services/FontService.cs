using System;
using System.Collections.Generic;
using OpenTemplater.Elements;
using OpenTemplater.Services.CreationStrategies;

namespace OpenTemplater.Services
{
    public class FontService : IFontService
    {
        private readonly IDictionary<string, FontSet> _fontDictionary;

        public FontService(IDictionary<string, FontSet> fontDictionary)
        {
            _fontDictionary = fontDictionary;
        }

        public string GetFontStylePath(string fontKey, FontStyle fontStyle)
        {
            if (fontKey == null) throw new ArgumentNullException("fontKey");

            if (_fontDictionary.ContainsKey(fontKey))
            {
                FontSet fontSet = _fontDictionary[fontKey];

                return fontSet.GetFontPath(fontStyle);
            }
            throw new KeyNotFoundException(string.Format("Cannot find font with key {0}", fontKey));
        }
    }
}