using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using OpenTemplater.Elements;

namespace OpenTemplater
{
    public class DocumentGenerator
    {
        public void GenerateDocument(string filename)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(filename);

            ValidateXml(xmlDocument);

           TemplateElement templateElement = CreateTemplate(xmlDocument.SelectSingleNode("/Template"));
        }

        private void ValidateXml(XmlDocument xmlDocument)
        {
            string filename = Path.Combine(Environment.CurrentDirectory, @"xml\OpenTemplater.xsd");

            XmlReaderSettings settings = new XmlReaderSettings {ValidationType = ValidationType.Schema};

            settings.ValidationEventHandler += ValidationCallBack;

            settings.Schemas.Add(null, filename);
          

            XmlReader xmlReader = XmlReader.Create(new StringReader(xmlDocument.InnerXml), settings);

            while (xmlReader.Read())
            {

            }
            
        }

        private void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            throw new NotImplementedException();
        }


        private TemplateElement CreateTemplate(XmlNode templateNode)
        {
            if (templateNode == null) throw new ArgumentNullException("templateNode");

            DocumentElement document = CreateDocument(templateNode.SelectSingleNode("Document"));

            string author = string.Empty;
            XmlNode authorNode = templateNode.SelectSingleNode("Author");
            if (authorNode != null)
            {
                author = authorNode.InnerText;
            }

           return new TemplateElement(document, author);
            
        }

        private DocumentElement CreateDocument(XmlNode documentNode)
        {
            if (documentNode == null) throw new ArgumentNullException("documentNode");
            return new DocumentElement();
        }
    }
}