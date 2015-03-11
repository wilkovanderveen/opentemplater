using System;
using System.Xml;

namespace OpenTemplater.Services
{
    public class ElementInputFactory
    {
        private readonly IValueConverter _valueConverter;
        private readonly XmlNamespaceManager _xmlNamespaceManager;

        public ElementInputFactory(IValueConverter valueConverter, XmlNamespaceManager xmlNamespaceManager)
        {
            if (valueConverter == null) throw new ArgumentNullException("valueConverter");
            if (xmlNamespaceManager == null) throw new ArgumentNullException("xmlNamespaceManager");

            _valueConverter = valueConverter;
            _xmlNamespaceManager = xmlNamespaceManager;
        }

        public RectangleCreationInput GetRectangleCreationInput(XmlNode rectangleElementNode)
        {
            if (rectangleElementNode == null) throw new ArgumentNullException("rectangleElementNode");

            if (rectangleElementNode.Attributes != null)
            {
                string key = rectangleElementNode.Attributes["key"].Value;
                byte zOrder;

                if (rectangleElementNode.Attributes["zOrder"] != null)
                {
                    if (!byte.TryParse(rectangleElementNode.Attributes["zOrder"].Value, out zOrder))
                    {
                        throw new Exception(string.Format("{0} is not a valid ZOrder value."));
                    }
                }

                var rectangleCreationInput = new RectangleCreationInput(key)
                {
                  
                    FillColor = rectangleElementNode.Attributes["fillColor"].Value,
                    BorderColor = rectangleElementNode.Attributes["borderColor"].Value
                };

                // Complex Layout
                 SetLayout(rectangleCreationInput,
                    rectangleElementNode.SelectSingleNode("Layout", _xmlNamespaceManager));

          
                return rectangleCreationInput;
            }
            throw new ArgumentNullException("rectangleElementNode.Attributes");
        }

        private void SetLayout(RectangleCreationInput creationInput, XmlNode layoutNode)
        {
            if (layoutNode == null) throw new ArgumentNullException("layoutNode");

            creationInput.HeightInput = GetHeightInput(layoutNode.SelectSingleNode("Height", _xmlNamespaceManager));
            creationInput.WidthInput = GetWidthInput(layoutNode.SelectSingleNode("Width", _xmlNamespaceManager));
            creationInput.XLayoutInput = GetXLayoutInput(layoutNode.SelectSingleNode("X", _xmlNamespaceManager));
            creationInput.YLayoutInput = GetYLayoutInput(layoutNode.SelectSingleNode("Y", _xmlNamespaceManager));
        }

        private XLayoutInput GetXLayoutInput(XmlNode xPositionNode)
        {
            if (xPositionNode == null) throw new ArgumentNullException("xPositionNode");
            var xLayoutInput = new XLayoutInput();
            if (xPositionNode.Attributes != null)
            {
                xLayoutInput.Value = _valueConverter.GetValue(xPositionNode.Attributes["value"].Value);
                XmlNode selectSingleNode = xPositionNode.SelectSingleNode("Relation");
                if (selectSingleNode != null)
                {
                    if (selectSingleNode.Attributes != null)
                    {
                        xLayoutInput.OtherElementKey = selectSingleNode.Attributes["element"].Value;
                        xLayoutInput.OtherElementSide = ConvertXSide(selectSingleNode.Attributes["side"]);
                    }
                }
                return xLayoutInput;
            }
            throw new ArgumentNullException("XNode.Attributes");
        }

        private YLayoutInput GetYLayoutInput(XmlNode yPositionNode)
        {
            if (yPositionNode == null) throw new ArgumentNullException("xPositionNode");
            var yLayoutInput = new YLayoutInput();
            if (yPositionNode.Attributes != null)
            {
                yLayoutInput.Value = _valueConverter.GetValue(yPositionNode.Attributes["value"].Value);
                XmlNode selectSingleNode = yPositionNode.SelectSingleNode("Relation");
                if (selectSingleNode != null)
                {
                    if (selectSingleNode.Attributes != null)
                    {
                        yLayoutInput.OtherElementKey = selectSingleNode.Attributes["element"].Value;
                        yLayoutInput.OtherElementSide = ConvertYSide(selectSingleNode.Attributes["side"]);
                    }
                }
                return yLayoutInput;
            }
            throw new ArgumentNullException("YNode.Attributes");
        }

        private YSide? ConvertYSide(XmlAttribute xmlAttribute)
        {
            if (xmlAttribute == null) return null;

            return (YSide) Enum.Parse(typeof (YSide), xmlAttribute.Value);
        }

        private XSide? ConvertXSide(XmlAttribute xmlAttribute)
        {
            if (xmlAttribute == null) return null;

            return (XSide) Enum.Parse(typeof (XSide), xmlAttribute.Value);
        }

        private HeightInput GetHeightInput(XmlNode heightNode)
        {
            if (heightNode == null) throw new ArgumentNullException("heightNode");

            var heightInput = new HeightInput();
            if (heightNode.Attributes != null)
            {
                heightInput.Value = _valueConverter.GetValue(heightNode.Attributes["value"].Value);
                XmlNode selectSingleNode = heightNode.SelectSingleNode("Relation");
                if (selectSingleNode != null)
                {
                    if (selectSingleNode.Attributes != null)
                    {
                        heightInput.OtherElementKey = selectSingleNode.Attributes["element"].Value;
                    }
                }
                return heightInput;
            }
            throw new ArgumentNullException("heightNode.Attributes");
        }

        private WidthInput GetWidthInput(XmlNode widthNode)
        {
            if (widthNode == null) throw new ArgumentNullException("widthNode");

            var widthInput = new WidthInput();
            if (widthNode.Attributes != null)
            {
                widthInput.Value = _valueConverter.GetValue(widthNode.Attributes["value"].Value);
                XmlNode selectSingleNode = widthNode.SelectSingleNode("Relation");
                if (selectSingleNode != null)
                {
                    if (selectSingleNode.Attributes != null)
                    {
                        widthInput.OtherElementKey = selectSingleNode.Attributes["element"].Value;
                    }
                }
                return widthInput;
            }
            throw new ArgumentNullException("WidthNode.Attributes");
        }
    }

    public interface IValueConverter
    {
        float GetValue(string input);
    }
}