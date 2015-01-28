using System;
using System.IO;
using System.Reflection;
using System.Xml;
using NUnit.Framework;

namespace OpenTemplater.Test
{
    [TestFixture]
    public class XmlConversionTest
    {
        [Test]
        public void XmlConversionTest_DoSomething()
        {
             DocumentGenerator generator = new DocumentGenerator();

            string filename = Path.Combine(Environment.CurrentDirectory, @"xml\TemplateTest.xml");

            generator.GenerateDocument(filename);
        }
    }
}