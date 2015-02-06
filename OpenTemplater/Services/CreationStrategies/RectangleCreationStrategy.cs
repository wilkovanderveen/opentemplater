using System;
using OpenTemplater.Elements;

namespace OpenTemplater.Services.CreationStrategies
{
    public class RectangleCreationStrategy : BaseElementCreationStrategy<RectangleCreationInput, RectangleElement>
    {
        private readonly IUnitConversionService _unitConversionService;

        public RectangleCreationStrategy(DocumentContext documentContext, IUnitConversionService unitConversionService, RectangleCreationInput input) : base(documentContext, input)
        {
            _unitConversionService = unitConversionService;
        }

        public override RectangleElement GetElement()
        {
            var rectangle = new RectangleElement
            {
                Key = Input.Key,
                BorderColor = DocumentContext.ColorService.GetColor(Input.BorderColor),
                BorderWidth = _unitConversionService.GetValue(Input.BorderWidth),
                Color = DocumentContext.ColorService.GetColor(Input.FillColor),
                ZOrder = Byte.Parse(Input.ZOrder)
            };

            return rectangle;
        }
    }
}