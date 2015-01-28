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
             TemplateGenerator generator = new TemplateGenerator();

            string filename = Path.Combine(Environment.CurrentDirectory, @"xml\TemplateTest.xml");

            generator.GenerateTemplate(filename);
        }
    }
}