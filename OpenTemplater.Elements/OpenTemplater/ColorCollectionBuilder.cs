using System;
using System.Collections.Generic;
using System.Xml;
using OpenTemplater.Elements;

namespace OpenTemplater
{
    internal class ColorCollectionBuilder
    {
        private readonly XmlNodeList _colorNodeList;

        public ColorCollectionBuilder(XmlNodeList colorNodeList)
        {
            _colorNodeList = colorNodeList;
        }

        public IDictionary<string, ColorSet> Build()
        {
            if (_colorNodeList == null)
            {
                throw new ArgumentNullException("colorNodeList");
            }

            IDictionary<string, ColorSet> colors = new Dictionary<string, ColorSet>();

            foreach (XmlNode colorNode in _colorNodeList)
            {
                if (colorNode.Attributes != null)
                {
                    string key = colorNode.Attributes["key"].Value;
                    var colorSet = new ColorSet();

                    foreach (XmlNode colortypeNode in colorNode)
                    {
                        XmlNode cmykColorNode = colortypeNode.SelectSingleNode("CMYK");
                        XmlNode rgbColorNode = colortypeNode.SelectSingleNode("RGB");
                        XmlNode pmsColorNode = colortypeNode.SelectSingleNode("PMS");

                        if (pmsColorNode != null)
                        {
                            if (cmykColorNode == null && rgbColorNode == null)
                            {
                                throw new NotSupportedException(
                                    "When defining PMS colors, a cmyk or a rgb color must be present.");
                            }

                            var xmlElement = pmsColorNode["name"];
                            if (xmlElement != null)
                            {
                                string name = xmlElement.Value;
                                colorSet.PMS = new PMSColor(name);
                            }
                        }
                    }
                    colors.Add(key, colorSet);
                }
            }

            return colors;
        }
    }
}