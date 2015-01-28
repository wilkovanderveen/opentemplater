using System.Runtime.InteropServices;
using NUnit.Framework;
using OpenTemplater.Elements.Modules;
using OpenTemplater.Elements.Utils;

namespace OpenTemplater.Elements.Test
{
    [TestFixture]
    public class PositionFactoryTest
    {
        [Test]
        public void GetVerticalOffset_XAxisInverted_ContainerIsEmpty()
        {
            LayoutFactory factory = new LayoutFactory();

            DocumentElement documentElement = new DocumentElement();
            documentElement.Pages.Add(new PageElement() { Key = "MyFirstPage", Height = UnitConverter.GetPoints(297), Width = UnitConverter.GetPoints(210) });
            
            Layout layout = factory.GetLayout(null, true, documentElement.Pages[0].Height, UnitConverter.GetPoints(10), UnitConverter.GetPoints(10), UnitConverter.GetPoints(200), UnitConverter.GetPoints(100));
            Assert.AreEqual(841.89, layout.YPosition, 0.01);
        }

        [Test]
        public void GetVerticalOffset_XAxisInverted_ContainerIsRectangle()
        {
            LayoutFactory factory = new LayoutFactory();

            DocumentElement documentElement = new DocumentElement();
            documentElement.Pages.Add(new PageElement() { Key = "MyFirstPage", Height = UnitConverter.GetPoints(297), Width = UnitConverter.GetPoints(210) });
            documentElement.Pages[0].Elements.Add(new RectangleElement() { Width = UnitConverter.GetPoints(100), Height = UnitConverter.GetPoints(100), XPosition = UnitConverter.GetPoints(50), YPosition = UnitConverter.GetPoints(25)});

            Layout layout = factory.GetLayout(documentElement.Pages[0], true, documentElement.Pages[0].Height, UnitConverter.GetPoints(10), UnitConverter.GetPoints(10), UnitConverter.GetPoints(200), UnitConverter.GetPoints(100));
            Assert.AreEqual(841.89, layout.YPosition, 0.01);
        }
    }
}