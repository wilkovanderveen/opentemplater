using NUnit.Framework;

namespace OpenTemplater.Output.PDF.Test
{
    [TestFixture]
    public class PDFLayoutTransformerTest
    {
        [Test]
        public void DoSomething()
        {
            var test = new PDFLayoutTransformer();
            TransformedLayout result = test.GetLayout(20, 40, 100, 100);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.LowerLeftX, Is.EqualTo(20));
            Assert.That(result.LowerLeftY, Is.EqualTo(40));
            Assert.That(result.UpperRightX, Is.EqualTo(120));
            Assert.That(result.UpperRightY, Is.EqualTo(140));
        }
    }
}