using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using OpenTemplater.Elements;

namespace OpenTemplater.Builders
{
    public class FontCollectionBuilder
    {
        private readonly string _fontBasePath;
        private readonly XmlNodeList _fontNodeList;

        public FontCollectionBuilder(XmlNodeList fontNodeList, string fontBasePath)
        {
            _fontNodeList = fontNodeList;
            _fontBasePath = fontBasePath;
        }

        public IDictionary<string, FontSet> Build()
        {
            IDictionary<string, FontSet> fontDictionary = new Dictionary<string, FontSet>();

            foreach (XmlNode fontNode in  _fontNodeList)
            {
                
                if (fontNode.Attributes != null)
                {
                    string key = fontNode.Attributes["key"].Value;
                    var fontSet = new FontSet();

                    foreach (XmlNode fontStyleNode in fontNode)
                    {
                        if (fontStyleNode.Attributes != null)
                        {
                            var fontStyle =
                                (FontStyle) (Enum.Parse(typeof (FontStyle), fontStyleNode.Attributes["style"].Value));
                            string fontPath = fontStyleNode.Attributes["file"].Value;
                            fontSet.AddFont(fontStyle, Path.Combine(_fontBasePath, fontPath));
                        }
                    }
                    fontDictionary.Add(key, fontSet);
                }
            }
            return fontDictionary;
        }
    }
}