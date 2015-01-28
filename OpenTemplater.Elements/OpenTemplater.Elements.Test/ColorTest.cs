using System;
using NUnit.Framework;

namespace OpenTemplater.Elements.Test
{
    [TestFixture]
    public class ColorTest
    {
        [Test]
        public void RGBColor_NoKey_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new RGBColor(null, 3, 39, 2));
        }

        [Test]
        public void RGBColor_EnptyKey_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new RGBColor(string.Empty, 3, 39, 2));
        }

        [Test]
        public void CMYKColor_NoKey_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new CMYKColor(null, 3, 39, 2,3));
        }

        [Test]
        public void CMYKColor_EnptyKey_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new CMYKColor(string.Empty, 3, 39, 2,3));
        }

        [Test]
        public void PMSColor_NoKey_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new PMSColor(null, "PMS302"));
        }

        [Test]
        public void PMSColor_EnptyKey_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new PMSColor(string.Empty, "PMS302"));
        }

        [Test]
        public void CMYKColor_CyanOutOfRange_Throws_ArgumentOutOfRangeExecption()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new CMYKColor("Red", 3f, 0.1f, 0.2f, 0.3f), "cyan");
        }

        [Test]
        public void CMYKColor_MagentaOutOfRange_Throws_ArgumentOutOfRangeExecption()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new CMYKColor("Red", 0.2f,3, 0.2f, 0.3f), "magenta");
        }

        [Test]
        public void CMYKColor_YellowOutOfRange_Throws_ArgumentOutOfRangeExecption()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new CMYKColor("Red", 0.2f,0.4f, 3, 0.3f), "yellow");
        }

        [Test]
        public void CMYKColor_BlackOutOfRange_Throws_ArgumentOutOfRangeExecption()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new CMYKColor("Red", 0.2f, 0.4f, 0.3f, 4), "black");
        }
    }
}