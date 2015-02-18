using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using NUnit.Framework;
using OpenTemplater.Elements;
using OpenTemplater.Services;
using OpenTemplater.Services.CreationStrategies;
using Rhino.Mocks;

namespace OpenTemplater.Test.Services
{
    [TestFixture]
    public class DocumentCreationServiceTest
    {
        [Test]
        public void Simple_StaticContent_1ElementFits_Returns_1Page()
        {
            var mockRepository = new MockRepository();
            var mockColorService = mockRepository.Stub<IColorService>();
            mockColorService.Stub(mcs => mcs.GetColor("red")).Return(new RGBColor(1, 1, 1));
            mockColorService.Stub(mcs => mcs.GetColor("green")).Return(new RGBColor(1, 1, 1));


            var mockFontService = mockRepository.Stub<IFontService>();
            var mockUnitConverter = new UnitConversionService();

            var context = new DocumentContext(mockColorService, mockFontService, new PagingService());
            ElementCreationFactory elementCreationFactory = new ElementCreationFactory(mockUnitConverter, context);
            var elementCreationService = new ElementCreationService(elementCreationFactory, mockUnitConverter);

            var staticContents = new StaticContentInput();

            var rectangleInput = new RectangleCreationInput()
            {
                BorderColor = "red",
                BorderWidth = "1pt",
                FillColor = "green",
                Key = "MyFirstRectangle",
                HeightInput = new HeightInput() { Value = 150f},
                WidthInput = new WidthInput() { Value = 100f},
                XLayoutInput = new XLayoutInput() { Value = 100f},
                YLayoutInput = new YLayoutInput() { Value = 100f}
            };
            staticContents.Elements.Add(rectangleInput);

            var pageInput = new PageTemplateInput
            {
                Key = "MyFirstPage",
                Width = "210mm",
                Height = "297mm",
                BleedSpace = "3mm",
                SlugSpace = "3mm",

                StaticContent = staticContents

            };

            IList<PageTemplateInput> templateInputs = new List<PageTemplateInput>();
            templateInputs.Add(pageInput);

            var documentCreationService = new DocumentCreationService(context, mockUnitConverter, elementCreationFactory);
            mockRepository.ReplayAll();

            DocumentElement resultDocument = documentCreationService.CreateDocument(templateInputs);

            Assert.That(resultDocument.Pages.Count, Is.EqualTo(1));
        }
    }
}