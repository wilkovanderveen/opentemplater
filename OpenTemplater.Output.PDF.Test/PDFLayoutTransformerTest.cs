using NUnit.Framework;
using OpenTemplater.Output.PDF.Layout;

namespace OpenTemplater.Output.PDF.Test
{
    [TestFixture]
    public class PDFLayoutTransformerTest
    {
        [Test]
        public void GetLayout_ResultIsOkay()
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