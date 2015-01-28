using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Reflection;
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

            XmlReaderSettings settings = new XmlReaderSettings {ValidationType = ValidationType.Schema};

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

            IDictionary<string, IColor> colorDictionary = CreateColors(colorNodeList);


            DocumentElement document = CreateDocument(templateNode.SelectSingleNode("Document"));

            string author = string.Empty;
            XmlNode authorNode = templateNode.SelectSingleNode("Author");
            if (authorNode != null)
            {
                author = authorNode.InnerText;
            }

           return new Template(document, author);
            
        }

        private IDictionary<string, IColor> CreateColors(XmlNodeList colorNodeList)
        {
            if (colorNodeList == null) throw new ArgumentNullException("colorsNode");

            foreach (XmlNode colorNode in colorNodeList)
            {
                
            }

            throw new NotImplementedException();
        }

        private DocumentElement CreateDocument(XmlNode documentNode)
        {
            if (documentNode == null) throw new ArgumentNullException("documentNode");
            return new DocumentElement();
        }
    }
}