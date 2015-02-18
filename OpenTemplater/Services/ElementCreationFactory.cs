using System;
using OpenTemplater.Elements;
using OpenTemplater.Services.CreationStrategies;

namespace OpenTemplater.Services
{
    public class ElementCreationFactory
    {
        private readonly IUnitConversionService _valueConverter;
        private readonly DocumentContext _documentContext;

        public ElementCreationFactory(IUnitConversionService valueConverter, DocumentContext documentContext)
        {
            _valueConverter = valueConverter;
            _documentContext = documentContext;
        }

        public IPositionedElement GetElement(IElementCreationInput elementCreationInput)
        {
            switch (elementCreationInput.Name.ToLower())
            {
                case "rectangle":
                    RectangleCreationInput rectangleCreationInput = elementCreationInput as RectangleCreationInput;
                    return new RectangleCreationStrategy(_documentContext, _valueConverter, rectangleCreationInput).GetElement();
                case "elipse":
                    ElipseCreationInput elipseCreationInput = elementCreationInput as ElipseCreationInput;
                    return new ElipseCreationStrategy(_documentContext, elipseCreationInput).GetElement();
                case "text":
                    TextCreationInput textCreationInput  = elementCreationInput as TextCreationInput;
                    return new TextCreationStrategy(_documentContext, textCreationInput).GetElement();
                case "image":
                    ImageCreationInput imageCreationInput = elementCreationInput as ImageCreationInput;
                    return new ImageCreationStrategy(_documentContext, imageCreationInput).GetElement();
                case "line":
                    LineCreationInput lineCreationInput = elementCreationInput as LineCreationInput;
                    return new LineCreationStrategy(_documentContext, lineCreationInput).GetElement();
                default:
                    throw new NotSupportedException(string.Format("Element type {0} is not supported",
                        elementCreationInput.Name.ToLower()));
            }
        }
    }
}