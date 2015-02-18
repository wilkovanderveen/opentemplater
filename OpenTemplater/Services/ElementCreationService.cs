using System;
using System.Collections.Generic;
using OpenTemplater.Elements;

namespace OpenTemplater.Services
{
    public class ElementCreationService : IElementCreationService
    {
        private readonly ElementCreationFactory _elementCreationFactory;
        private readonly IUnitConversionService _unitConversionService;

        public ElementCreationService(ElementCreationFactory elementCreationFactory,
            IUnitConversionService unitConversionService)
        {
            _elementCreationFactory = elementCreationFactory;
            _unitConversionService = unitConversionService;
        }

        public PageTemplateProcessingResult CreateElements(PageTemplateInput pageTemplateInput)
        {
            List<IPositionedElement> staticContents = ProcessStaticContent(pageTemplateInput.StaticContent);
            List<IPositionedElement> dynamicContents = ProcessDynamicContent(pageTemplateInput.DynamicContent);

            var result = new PageTemplateProcessingResult
            {
                BleedSpace = _unitConversionService.GetValue(pageTemplateInput.BleedSpace),
                SlugSpace = _unitConversionService.GetValue(pageTemplateInput.SlugSpace),
                DynamicContentTopMargin = _unitConversionService.GetValue(pageTemplateInput.DynamicContent.Y)
            };

            result.DynamicContentBottomMargin =
                _unitConversionService.GetValue(pageTemplateInput.DynamicContent.Height) +
                result.DynamicContentTopMargin;

            result.DynamicContents.AddRange(dynamicContents);
            result.StaticContents.AddRange(staticContents);

            return result;
        }

        private List<IPositionedElement> ProcessDynamicContent(DynamicContentInput dynamicContent)
        {
            throw new NotImplementedException();
        }

        private List<IPositionedElement> ProcessStaticContent(StaticContentInput staticContent)
        {
            throw new NotImplementedException();
        }
    }

    public class ProcessedElement
    {
        public float Left { get; set; }
        public float Top { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
    }

    public interface IElementCreationService
    {
        PageTemplateProcessingResult CreateElements(PageTemplateInput pageTemplateInput);
    }
}