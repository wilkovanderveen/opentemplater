using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using OpenTemplater.Builders;
using OpenTemplater.Elements;

namespace OpenTemplater
{
    public class TemplateGenerator
    {
        private readonly XmlDocument _templateXml;
        private readonly XmlNamespaceManager _xmlNamespaceManager;

        public TemplateGenerator()
        {
            _templateXml = new XmlDocument();
            _xmlNamespaceManager = new XmlNamespaceManager(_templateXml.NameTable);
            _xmlNamespaceManager.AddNamespace("OpenTemplater", "http://tempuri.org/OpenTemplater.xsd");
        }

        public Template GenerateTemplate(string filename)
        {
            _templateXml.Load(filename);

            ValidateXml(_templateXml);

            Template tempate = CreateTemplate(_templateXml.SelectSingleNode("/OpenTemplater:Template", _xmlNamespaceManager));



            return tempate;
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
            Trace.Write(e);
        }


        private Template CreateTemplate(XmlNode templateNode)
        {
            if (templateNode == null)
            {
                throw new ArgumentNullException("templateNode");
            }

            XmlNodeList colorNodeList = templateNode.SelectNodes("OpenTemplater:Colors/OpenTemplater:Color", _xmlNamespaceManager);
            IDictionary<string, ColorSet> colorDictionary = CreateColors(colorNodeList);

            XmlNodeList fontNodeList = templateNode.SelectNodes("OpenTemplater:Fonts/OpenTemplater:Font", _xmlNamespaceManager);
            XmlNode fontsCollectionNode = templateNode.SelectSingleNode("OpenTemplater:Fonts", _xmlNamespaceManager);
            if (fontsCollectionNode != null)
            {
                if (fontsCollectionNode.Attributes != null)
                {
                    string basePath = fontsCollectionNode.Attributes["basePath"].Value;
                    IDictionary<string, FontSet> fontDictionary = CreateFonts(fontNodeList, basePath);

                    DocumentElement document = CreateDocument(templateNode.SelectSingleNode("OpenTemplater:Document", _xmlNamespaceManager));

                    string author = string.Empty;
                    XmlNode authorNode = templateNode.SelectSingleNode("OpenTemplater:Author", _xmlNamespaceManager);
                    if (authorNode != null)
                    {
                        author = authorNode.InnerText;
                    }

                    return new Template(document, author, colorDictionary, fontDictionary);
                }
            }
            throw new NullReferenceException("Cannot find fonts in template");
        }

        private IDictionary<string, FontSet> CreateFonts(XmlNodeList fontNode, string basePath)
        {
            var fontCollection = new FontCollectionBuilder(fontNode, basePath);
            return fontCollection.Build();
        }

        private IDictionary<string, ColorSet> CreateColors(XmlNodeList colorNodeList)
        {
            var colorCollectionBuilder = new ColorCollectionBuilder(colorNodeList);

            return colorCollectionBuilder.Build();
        }

        private DocumentElement CreateDocument(XmlNode documentNode)
        {
            if (documentNode == null) throw new ArgumentNullException("documentNode");
            return new DocumentElement();
        }
    }
}