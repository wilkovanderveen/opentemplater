using System.Collections.Generic;
using NUnit.Framework;
using OpenTemplater.Elements.Modules;
using OpenTemplater.Services;

namespace OpenTemplater.Test.Services
{
    [TestFixture]
    public class LayoutServiceTest
    {
        [Test]
        public void ComplexLayoutConversion_OtherElementIsRelatedToBottom()
        {
            IDictionary<string, IElementLayoutCreationInput> layoutInputs = new Dictionary<string, IElementLayoutCreationInput>();

            var firstRectangleInput = new RectangleLayoutCreationInput
            {
                Key = "MyFirstRectangle",
                XLayoutInput = new XLayoutInput {Value = 20},
                YLayoutInput = new YLayoutInput {Value = 20, XAxisInverted = true, PageHeight = 200},
                WidthInput = new WidthInput {Value = 20},
                HeightInput = new HeightInput {Value = 20}
            };

            var secondRectangleInput = new RectangleLayoutCreationInput
            {
                Key = "MySecondRectangle",
                XLayoutInput = new XLayoutInput {Value = 20},
                YLayoutInput =
                    new YLayoutInput
                    {
                        XAxisInverted = true,
                        PageHeight = 200,
                        OtherElementKey = "MyFirstRectangle",
                        OtherElementSide = YSide.Bottom,
                        Value = 20
                    },
                WidthInput = new WidthInput {Value = 20},
                HeightInput = new HeightInput {Value = 20}
            };

            layoutInputs.Add(firstRectangleInput.Key, firstRectangleInput);
            layoutInputs.Add(secondRectangleInput.Key, secondRectangleInput);

            var layoutService = new LayoutService(layoutInputs);

            IDictionary<string, Layout> result = layoutService.ProcesElements();

            Assert.That(result, Is.Not.Null);

            Layout layout = result["MySecondRectangle"];

            Assert.That(layout.Height, Is.EqualTo(20));
            Assert.That(layout.Width, Is.EqualTo(20));
            Assert.That(layout.XPosition, Is.EqualTo(20));
            Assert.That(layout.YPosition, Is.EqualTo(140));
        }

        [Test]
        public void ComplexLayoutConversion_OtherElementIsRelatedToLeft()
        {
            IDictionary<string, IElementLayoutCreationInput> layoutInputs = new Dictionary<string, IElementLayoutCreationInput>();

            var firstRectangleInput = new RectangleLayoutCreationInput
            {
                Key = "MyFirstRectangle",
                XLayoutInput = new XLayoutInput {Value = 20},
                YLayoutInput = new YLayoutInput {Value = 20, XAxisInverted = true, PageHeight = 200},
                WidthInput = new WidthInput {Value = 20},
                HeightInput = new HeightInput {Value = 20}
            };

            var secondRectangleInput = new RectangleLayoutCreationInput
            {
                Key = "MySecondRectangle",
                XLayoutInput =
                    new XLayoutInput {Value = 20, OtherElementKey = "MyFirstRectangle", OtherElementSide = XSide.Left},
                YLayoutInput = new YLayoutInput {Value = 20, XAxisInverted = true, PageHeight = 200},
                WidthInput = new WidthInput {Value = 20},
                HeightInput = new HeightInput {Value = 20}
            };

            layoutInputs.Add(firstRectangleInput.Key, firstRectangleInput);
            layoutInputs.Add(secondRectangleInput.Key, secondRectangleInput);

            var layoutService = new LayoutService(layoutInputs);

            IDictionary<string, Layout> result = layoutService.ProcesElements();

            Assert.That(result, Is.Not.Null);

            Layout layout = result["MySecondRectangle"];

            Assert.That(layout.Height, Is.EqualTo(20));
            Assert.That(layout.Width, Is.EqualTo(20));
            Assert.That(layout.XPosition, Is.EqualTo(40));
            Assert.That(layout.YPosition, Is.EqualTo(180));
        }

        [Test]
        public void ComplexLayoutConversion_OtherElementIsRelatedToRight()
        {
            IDictionary<string, IElementLayoutCreationInput> layoutInputs = new Dictionary<string, IElementLayoutCreationInput>();

            var firstRectangleInput = new RectangleLayoutCreationInput
            {
                Key = "MyFirstRectangle",
                XLayoutInput = new XLayoutInput {Value = 20},
                YLayoutInput = new YLayoutInput {Value = 20, XAxisInverted = true, PageHeight = 200},
                WidthInput = new WidthInput {Value = 20},
                HeightInput = new HeightInput {Value = 20}
            };

            var secondRectangleInput = new RectangleLayoutCreationInput
            {
                Key = "MySecondRectangle",
                XLayoutInput =
                    new XLayoutInput {Value = 20, OtherElementKey = "MyFirstRectangle", OtherElementSide = XSide.Right},
                YLayoutInput = new YLayoutInput {Value = 20, XAxisInverted = true, PageHeight = 200},
                WidthInput = new WidthInput {Value = 20},
                HeightInput = new HeightInput {Value = 20}
            };

            layoutInputs.Add(firstRectangleInput.Key, firstRectangleInput);
            layoutInputs.Add(secondRectangleInput.Key, secondRectangleInput);

            var layoutService = new LayoutService(layoutInputs);

            IDictionary<string, Layout> result = layoutService.ProcesElements();

            Assert.That(result, Is.Not.Null);

            Layout layout = result["MySecondRectangle"];

            Assert.That(layout.Height, Is.EqualTo(20));
            Assert.That(layout.Width, Is.EqualTo(20));
            Assert.That(layout.XPosition, Is.EqualTo(60));
            Assert.That(layout.YPosition, Is.EqualTo(180));
        }

        [Test]
        public void ComplexLayoutConversion_OtherElementIsRelatedToTop()
        {
            IDictionary<string, IElementLayoutCreationInput> layoutInputs = new Dictionary<string, IElementLayoutCreationInput>();

            var firstRectangleInput = new RectangleLayoutCreationInput
            {
                Key = "MyFirstRectangle",
                XLayoutInput = new XLayoutInput {Value = 20},
                YLayoutInput = new YLayoutInput {Value = 20, XAxisInverted = true, PageHeight = 200},
                WidthInput = new WidthInput {Value = 20},
                HeightInput = new HeightInput {Value = 20}
            };

            var secondRectangleInput = new RectangleLayoutCreationInput
            {
                Key = "MySecondRectangle",
                XLayoutInput = new XLayoutInput {Value = 20},
                YLayoutInput =
                    new YLayoutInput
                    {
                        XAxisInverted = true,
                        PageHeight = 200,
                        OtherElementKey = "MyFirstRectangle",
                        OtherElementSide = YSide.Top,
                        Value = 20
                    },
                WidthInput = new WidthInput {Value = 20},
                HeightInput = new HeightInput {Value = 20}
            };

            layoutInputs.Add(firstRectangleInput.Key, firstRectangleInput);
            layoutInputs.Add(secondRectangleInput.Key, secondRectangleInput);

            var layoutService = new LayoutService(layoutInputs);

            IDictionary<string, Layout> result = layoutService.ProcesElements();

            Assert.That(result, Is.Not.Null);

            Layout layout = result["MySecondRectangle"];

            Assert.That(layout.Height, Is.EqualTo(20));
            Assert.That(layout.Width, Is.EqualTo(20));
            Assert.That(layout.XPosition, Is.EqualTo(20));
            Assert.That(layout.YPosition, Is.EqualTo(160));
        }

        [Test]
        public void SimpleLayoutConversion_X20_Y20_W20_H20_XaxisInverted_Result_X20_Y180_W20_H20()
        {
            IDictionary<string, IElementLayoutCreationInput> layoutInputs = new Dictionary<string, IElementLayoutCreationInput>();

            var rectangleLayout = new RectangleLayoutCreationInput
            {
                Key = "MyFirstRectangle",
                XLayoutInput = new XLayoutInput {Value = 20},
                YLayoutInput = new YLayoutInput {Value = 20, XAxisInverted = true, PageHeight = 200},
                WidthInput = new WidthInput {Value = 20},
                HeightInput = new HeightInput {Value = 20}
            };

            layoutInputs.Add(rectangleLayout.Key, rectangleLayout);

            var layoutService = new LayoutService(layoutInputs);

            IDictionary<string, Layout> result = layoutService.ProcesElements();

            Assert.That(result, Is.Not.Null);

            Layout layout = result["MyFirstRectangle"];

            Assert.That(layout.Height, Is.EqualTo(20));
            Assert.That(layout.Width, Is.EqualTo(20));
            Assert.That(layout.XPosition, Is.EqualTo(20));
            Assert.That(layout.YPosition, Is.EqualTo(180));
        }
    }
}