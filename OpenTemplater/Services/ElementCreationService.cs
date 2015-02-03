using System;
using OpenTemplater.Elements;
using OpenTemplater.Services.CreationStrategies;

namespace OpenTemplater.Services
{
    public class ElementCreationService
    {
        private readonly IColorService _colorService;
        private readonly IUnitConversionService _valueConverter;

        public ElementCreationService(IColorService colorService, IUnitConversionService valueConverter)
        {
            _colorService = colorService;
            _valueConverter = valueConverter;
        }

        public IElementCreationStrategy GetStrategy(IElementCreationInput elementCreationInput)
        {
            switch (elementCreationInput.Name.ToLower())
            {
                case "rectangle":
                    return new RectangleCreationStrategy(_colorService, _valueConverter);
                case "elipse":
                    return new ElipseCreationStrategy();
                case "text":
                    return new TextCreationStrategy();
                case "image":
                    return new ImageCreationStrategy();
                case "line":
                    return new LineCreationStrategy();
                default:
                    throw new NotSupportedException(string.Format("Element type {0} is not supported",
                        elementCreationInput.Name.ToLower()));
            }
        }
    }

    public class LineCreationInput : IElementCreationInput
    {
        public string Key { get; private set; }
        public string Name { get; private set; }
        public IElementLayoutInput LayoutInput { get; private set; }
    }

    public class ImageCreationInput : IElementCreationInput
    {
        public string Key { get; private set; }
        public string Name { get; private set; }
        public IElementLayoutInput LayoutInput { get; private set; }
    }

    public class TextCreationInput : IElementCreationInput
    {
        public string Key { get; private set; }
        public string Name { get; private set; }
        public IElementLayoutInput LayoutInput { get; private set; }
    }

    public class ElipseCreationInput : IElementCreationInput
    {
        public string Key { get; private set; }
        public string Name { get; private set; }
        public IElementLayoutInput LayoutInput { get; private set; }
    }

    public interface IUnitConversionService
    {
        float GetValue(string unitValue);
    }

    public interface IColorService
    {
        IColor GetColor(string key);
    }

    public interface IElementCreationStrategy<in TInput, out TOutput> : IElementCreationStrategy where TInput : IElementCreationInput where TOutput : IElement
    {
        TOutput GetElement(TInput elementCreationInput);
    }

    public interface IElementCreationStrategy
    {
        
    }
}