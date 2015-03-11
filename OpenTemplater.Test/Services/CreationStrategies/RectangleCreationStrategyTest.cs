using System.Collections.Generic;
using NUnit.Framework;
using OpenTemplater.Elements;
using OpenTemplater.Services;
using OpenTemplater.Services.CreationStrategies;

namespace OpenTemplater.Test.Services.CreationStrategies
{
    [TestFixture]
    public class RectangleCreationStrategyTest
    {
        [Test]
        public void CreateSimpleRectangle_CMYK()
        {
            var blueColor = new CMYKColor(0.04f, 0.02f, 0.06f, 0.08f);
            var redColor = new CMYKColor(0.04f, 0.06f, 0.06f, 0.08f);

            IDictionary<string, ColorSet> colorSets = new Dictionary<string, ColorSet>();
            colorSets.Add("blue", new ColorSet {CMYK = blueColor});
            colorSets.Add("red", new ColorSet {CMYK = redColor});

            var colorService = new ColorService(ColorType.CMYK, colorSets);
            var unitConversionService = new UnitConversionService();

            IDictionary<string, FontSet> fontDictionary = new Dictionary<string, FontSet>();
            fontDictionary.Add("myfont", new FontSet());

            IFontService fontService = new FontService(fontDictionary);
            var documentContext = new DocumentContext(colorService, fontService, new PagingService());

            var rectangleCreationInput = new RectangleCreationInput("Rectangle")
            {
                BorderColor = "blue",
                BorderWidth = "2pt",
                FillColor = "red",
                ZOrder = "1"
            };

            var rectangleCreationStrategy = new RectangleCreationStrategy(documentContext, unitConversionService,
                rectangleCreationInput);
            RectangleElement result = rectangleCreationStrategy.GetElement();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.BorderColor, Is.EqualTo(blueColor));
            Assert.That(result.Color, Is.EqualTo(redColor));
            Assert.That(result.BorderWidth, Is.EqualTo(2));
            Assert.That(result.Key, Is.EqualTo(rectangleCreationInput.Key));
        }
    }
}