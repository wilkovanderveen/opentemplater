using System;
using System.IO;
using NUnit.Framework;
using OpenTemplater.Elements;

namespace OpenTemplater.Test
{
    [TestFixture]
    public class XmlConversionTest
    {
        [Test]
        public void XmlConversionTest_DoSomething()
        {
            var generator = new TemplateGenerator();

            string filename = Path.Combine(Environment.CurrentDirectory, @"xml\TemplateTest.xml");

            Template template = generator.GenerateTemplate(filename);
        }
    }
}