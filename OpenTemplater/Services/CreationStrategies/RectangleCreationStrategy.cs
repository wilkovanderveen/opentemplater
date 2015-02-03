using System;
using OpenTemplater.Elements;

namespace OpenTemplater.Services.CreationStrategies
{
    public class RectangleCreationStrategy : IElementCreationStrategy<RectangleCreationInput, RectangleElement>
    {
        private readonly IColorService _colorService;
        private readonly IUnitConversionService _unitConversionService;

        public RectangleCreationStrategy(IColorService colorService, IUnitConversionService unitConversionService)
        {
            _colorService = colorService;
            _unitConversionService = unitConversionService;
        }

        public RectangleElement GetElement(RectangleCreationInput elementCreationInput)
        {
            var rectangle = new RectangleElement
            {
                Key = elementCreationInput.Key,
                BorderColor = _colorService.GetColor(elementCreationInput.BorderColor),
                BorderWidth = _unitConversionService.GetValue(elementCreationInput.BorderWidth),
                Color = _colorService.GetColor(elementCreationInput.FillColor),
                ZOrder = Byte.Parse(elementCreationInput.ZOrder)
            };

            return rectangle;
        }
    }
}