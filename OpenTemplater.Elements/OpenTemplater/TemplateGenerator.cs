using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using OpenTemplater.Elements;

namespace OpenTemplater
{
    public class TemplateGenerator
    {
        public void GenerateTemplate(string filename)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(filename);

            ValidateXml(xmlDocument);

            Template template = CreateTemplate(xmlDocument.SelectSingleNode("/Template"));
        }

        private void ValidateXml(XmlDocument xmlDocument)
        {
            string filename = Path.Combine(Environment.CurrentDirectory, @"xml\OpenTemplater.xsd");

            var settings = new XmlReaderSettings {ValidationType = ValidationType.Schema};

            settings.ValidationEventHandler += ValidationCallBack;

            settings.Schemas.Add("http://tempuri.org/OpenTemplater.xsd", filename);


            XmlReader xmlReader = XmlReader.Create(new StringReader(xmlDocument.InnerXml), settings);

            while (xmlReader.Read())
            {
            }
        }

        private void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            throw new NotImplementedException();
        }


        private Template CreateTemplate(XmlNode templateNode)
        {
            if (templateNode == null) throw new ArgumentNullException("templateNode");

            XmlNodeList colorNodeList = templateNode.SelectNodes("Colors/Color");

            IDictionary<string, ColorSet> colorDictionary = CreateColors(colorNodeList);


            DocumentElement document = CreateDocument(templateNode.SelectSingleNode("Document"));

            string author = string.Empty;
            XmlNode authorNode = templateNode.SelectSingleNode("Author");
            if (authorNode != null)
            {
                author = authorNode.InnerText;
            }

            return new Template(document, author);
        }

        private IDictionary<string, ColorSet> CreateColors(XmlNodeList colorNodeList)
        {
            ColorCollectionBuilder colorCollectionBuilder = new ColorCollectionBuilder(colorNodeList);

            return colorCollectionBuilder.Build();
        }

        private DocumentElement CreateDocument(XmlNode documentNode)
        {
            if (documentNode == null) throw new ArgumentNullException("documentNode");
            return new DocumentElement();
        }
    }

    internal class ColorSet
    {
        public CMYKColor CMYK { get; set; }
        public RGBColor RGB { get; set; }
        public PMSColor PMS { get; set; }
    }
}