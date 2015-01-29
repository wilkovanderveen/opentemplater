using System;
using NUnit.Framework;

namespace OpenTemplater.Elements.Test
{
    [TestFixture]
    public class ColorTest
    {
        [Test]
        public void PMSColor_EnptyKey_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new PMSColor(string.Empty));
        }

        [Test]
        public void CMYKColor_CyanOutOfRange_Throws_ArgumentOutOfRangeExecption()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new CMYKColor(3f, 0.1f, 0.2f, 0.3f), "cyan");
        }

        [Test]
        public void CMYKColor_MagentaOutOfRange_Throws_ArgumentOutOfRangeExecption()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new CMYKColor(0.2f,3, 0.2f, 0.3f), "magenta");
        }

        [Test]
        public void CMYKColor_YellowOutOfRange_Throws_ArgumentOutOfRangeExecption()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new CMYKColor(0.2f,0.4f, 3, 0.3f), "yellow");
        }

        [Test]
        public void CMYKColor_BlackOutOfRange_Throws_ArgumentOutOfRangeExecption()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new CMYKColor(0.2f, 0.4f, 0.3f, 4), "black");
        }
    }
}