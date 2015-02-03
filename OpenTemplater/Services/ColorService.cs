using System;
using System.Collections.Generic;
using OpenTemplater.Elements;

namespace OpenTemplater.Services
{
    public class ColorService : IColorService
    {
        private readonly IDictionary<string, ColorSet> _colorSets;
        private readonly ColorType _colorType;

        public ColorService(ColorType colorType, IDictionary<string, ColorSet> colorSets)
        {
            if (colorSets == null) throw new ArgumentNullException("colorSets");
            _colorType = colorType;
            _colorSets = colorSets;
        }

        public IColor GetColor(string key)
        {
            if (_colorSets.ContainsKey(key))
            {
                switch (_colorType)
                {
                    case ColorType.CMYK:
                        return _colorSets[key].CMYK;

                    case ColorType.RGB:
                        return _colorSets[key].RGB;

                    case ColorType.PMS:
                        return _colorSets[key].PMS;

                    default:
                        throw new NotSupportedException(string.Format("Colortype {0} not supported", _colorType));
                }
            }
            throw new KeyNotFoundException(string.Format("Color with key '{0}' not found", key));
        }
    }
}