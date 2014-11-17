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
        public void DoSomeThing()
        {
            LayoutFactory factory = new LayoutFactory();

            Document document = new Document();
            document.Pages.Add(new Page() { Key = "MyFirstPage", Height = UnitConverter.GetPoints(297), Width = UnitConverter.GetPoints(210) });
            document.Pages[0].Elements.Add(new Rectangle() {});

            factory.GetLayout(document.Pages[0], true, document.Pages[0].Height,);
        }
    }
}