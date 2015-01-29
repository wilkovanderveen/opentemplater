using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using OpenTemplater.Elements;

namespace OpenTemplater
{
    public class ColorCollectionBuilder
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
                        switch (colortypeNode.LocalName)
                        {
                            case "CMYK":
                                colorSet.CMYK = BuildCMKColor(colortypeNode);
                                break;
                            case "RGB":
                                colorSet.RGB = BuildRGBColor(colortypeNode);
                                break;
                            case "PMS":
                                colorSet.PMS = BuildPMSColor(colortypeNode);
                                break;
                            default:
                                throw new NotSupportedException(string.Format("Colortype {0} not supported",
                                    colortypeNode.LocalName));
                        }
                    }
                    colors.Add(key, colorSet);
                }
            }

            return colors;
        }

        private PMSColor BuildPMSColor(XmlNode colortypeNode)
        {
            if (colortypeNode == null) throw new ArgumentNullException("colorTypeNode");
            if (colortypeNode.Attributes == null) throw new ArgumentNullException("colorTypeNode.Attributes");

            var xmlElement = colortypeNode.Attributes["name"];
            if (xmlElement != null)
            {
                string name = xmlElement.Value;

                return new PMSColor(name);
            }
            throw new ArgumentNullException("psmcolor.name");
        }


        private CMYKColor BuildCMKColor(XmlNode colorTypeNode)
        {
            if (colorTypeNode == null) throw new ArgumentNullException("colorTypeNode");
            if (colorTypeNode.Attributes == null) throw new ArgumentNullException("colorTypeNode.Attributes");

            Single cyan = Single.Parse(colorTypeNode.Attributes["cyan"].Value, CultureInfo.InvariantCulture);
            Single magenta = Single.Parse(colorTypeNode.Attributes["magenta"].Value, CultureInfo.InvariantCulture);
            Single yellow = Single.Parse(colorTypeNode.Attributes["yellow"].Value, CultureInfo.InvariantCulture);
            Single black = Single.Parse(colorTypeNode.Attributes["black"].Value, CultureInfo.InvariantCulture);

            return new CMYKColor(cyan, magenta, yellow, black);
        }

        private RGBColor BuildRGBColor(XmlNode colorTypeNode)
        {
            if (colorTypeNode == null) throw new ArgumentNullException("colorTypeNode");
            if (colorTypeNode.Attributes == null) throw new ArgumentNullException("colorTypeNode.Attributes");

            byte red = Byte.Parse(colorTypeNode.Attributes["red"].Value);
            byte green = Byte.Parse(colorTypeNode.Attributes["green"].Value);
            byte blue = Byte.Parse(colorTypeNode.Attributes["blue"].Value);


            return new RGBColor(red, green, blue);
        }
    }
}