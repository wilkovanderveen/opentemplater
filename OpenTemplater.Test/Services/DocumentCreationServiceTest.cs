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
            var elementCreationFactory = new ElementCreationFactory(mockUnitConverter, context);
           
            var staticContents = new StaticContentInput();

            var rectangleInput = new RectangleCreationInput("MyFirstRectangle")
            {
                BorderColor = "red",
                BorderWidth = "1pt",
                FillColor = "green",
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

        [Test]
        public void Simple_Dynamic_Content_4ElementDoNotFit_Returns_2Pages()
        {
            var mockRepository = new MockRepository();
            var mockColorService = mockRepository.Stub<IColorService>();
            mockColorService.Stub(mcs => mcs.GetColor("red")).Return(new RGBColor(1, 1, 1));
            mockColorService.Stub(mcs => mcs.GetColor("green")).Return(new RGBColor(1, 1, 1));

            var mockFontService = mockRepository.Stub<IFontService>();
            var mockUnitConverter = new UnitConversionService();

            var context = new DocumentContext(mockColorService, mockFontService, new PagingService());
            ElementCreationFactory elementCreationFactory = new ElementCreationFactory(mockUnitConverter, context);
          
            var staticContents = new StaticContentInput();

            var rectangleInput = new RectangleCreationInput("MyFirstRectangle")
            {
                BorderColor = "red",
                BorderWidth = "1pt",
                FillColor = "green",
                HeightInput = new HeightInput() { Value = 150f },
                WidthInput = new WidthInput() { Value = 100f },
                XLayoutInput = new XLayoutInput() { Value = 100f },
                YLayoutInput = new YLayoutInput() { Value = 100f }
            };

            var rectangleTwoInput = new RectangleCreationInput("MySecondRectangle")
            {
                BorderColor = "red",
                BorderWidth = "1pt",
                FillColor = "green",
                HeightInput = new HeightInput() { Value = 150f },
                WidthInput = new WidthInput() { Value = 100f },
                XLayoutInput = new XLayoutInput() { Value = 100f },
                YLayoutInput = new YLayoutInput() { Value = 300f }
            };

            var rectangleThreeInput = new RectangleCreationInput("MyThrirdRectangle")
            {
                BorderColor = "red",
                BorderWidth = "1pt",
                FillColor = "green",
                HeightInput = new HeightInput() { Value = 150f },
                WidthInput = new WidthInput() { Value = 100f },
                XLayoutInput = new XLayoutInput() { Value = 100f },
                YLayoutInput = new YLayoutInput() { Value = 500f }
            };

            var rectangleFourInput = new RectangleCreationInput("MyFourthRectangle")
            {
                BorderColor = "red",
                BorderWidth = "1pt",
                FillColor = "green",
                HeightInput = new HeightInput() { Value = 150f },
                WidthInput = new WidthInput() { Value = 100f },
                XLayoutInput = new XLayoutInput() { Value = 100f },
                YLayoutInput = new YLayoutInput() { Value = 700f }
            };

            staticContents.Elements.Add(rectangleInput);

            DynamicContentInput dynamicContentInput = new DynamicContentInput
            {
                X = "20mm",
                Y = "20mm",
                Width = "170mm",
                Height = "257mm"
            };


            dynamicContentInput.Elements.Add(rectangleTwoInput);
            dynamicContentInput.Elements.Add(rectangleThreeInput);
            dynamicContentInput.Elements.Add(rectangleFourInput);

            
            var pageInput = new PageTemplateInput
            {
                Key = "MyFirstPage",
                Width = "210mm",
                Height = "297mm",
                BleedSpace = "3mm",
                SlugSpace = "3mm",

                StaticContent = staticContents,
                DynamicContent = dynamicContentInput

            };

            IList<PageTemplateInput> templateInputs = new List<PageTemplateInput>();
            templateInputs.Add(pageInput);

            var documentCreationService = new DocumentCreationService(context, mockUnitConverter, elementCreationFactory);
            mockRepository.ReplayAll();

            DocumentElement resultDocument = documentCreationService.CreateDocument(templateInputs);

            Assert.That(resultDocument.Pages.Count, Is.EqualTo(2));
        }
    }
}