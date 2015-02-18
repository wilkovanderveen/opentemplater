using System;
using System.Collections.Generic;
using OpenTemplater.Elements.Modules;

namespace OpenTemplater.Services
{
    public class LayoutService
    {
        private readonly IDictionary<string, IElementLayoutCreationInput> _layoutInputs;
        private readonly IDictionary<string, Layout> _processedLayouts;

        public LayoutService(IDictionary<string, IElementLayoutCreationInput> layoutInputs)
        {
            _processedLayouts = new Dictionary<string, Layout>();
            _layoutInputs = layoutInputs;
        }

        public IDictionary<string, Layout> ProcesElements()
        {
            foreach (IElementLayoutCreationInput layoutInput in _layoutInputs.Values)
            {
                if (!_processedLayouts.ContainsKey(layoutInput.Key))
                {
                    _processedLayouts.Add(layoutInput.Key, GetPositions(layoutInput));
                }
            }

            return _processedLayouts;
        }

        private Layout GetPositions(IElementLayoutCreationInput layoutCreationInput)
        {
            float xPosition = GetXPosition(layoutCreationInput.XLayoutInput.OtherElementKey, layoutCreationInput.XLayoutInput.Value,
                layoutCreationInput.XLayoutInput.OtherElementSide);

            float yPosition = GetYPosition(layoutCreationInput.YLayoutInput.OtherElementKey, layoutCreationInput.YLayoutInput.Value,
                layoutCreationInput.YLayoutInput.OtherElementSide, layoutCreationInput.YLayoutInput.XAxisInverted,
                layoutCreationInput.YLayoutInput.PageHeight);

            float width = GetWidth(layoutCreationInput.WidthInput.OtherElementKey, layoutCreationInput.WidthInput.Value);
            float height = GetHeight(layoutCreationInput.HeightInput.OtherElementKey, layoutCreationInput.HeightInput.Value, layoutCreationInput.HeightInput.MaxHeight);

            return new Layout(xPosition, yPosition, width, height);
        }

        private float GetHeight(string otherElementKey, float value, float maxHeight)
        {
            if (!string.IsNullOrEmpty(otherElementKey))
            {
                IElementLayoutCreationInput otherElement;
                if (_layoutInputs.TryGetValue(otherElementKey, out otherElement))
                {
                    // First check if refered layout is already been processed, if so get the calculated values.
                    if (_processedLayouts.ContainsKey(otherElementKey))
                    {
                        Layout processedLayout = _processedLayouts[otherElementKey];

                        return Math.Min(processedLayout.Height + value, maxHeight);
                    }
                    //  Process the related element so the position can be calculated.
                    _processedLayouts.Add(otherElementKey, GetPositions(otherElement));
                    return GetHeight(otherElementKey, value, maxHeight);
                }
                throw new KeyNotFoundException(string.Format("Other element with key {0} not found.", otherElementKey));
            }
            return value;
        }

        private float GetWidth(string otherElementKey, float value)
        {
            if (!string.IsNullOrEmpty(otherElementKey))
            {
                IElementLayoutCreationInput otherElement;
                if (_layoutInputs.TryGetValue(otherElementKey, out otherElement))
                {
                    // First check if refered layout is already been processed, if so get the calculated values.
                    if (_processedLayouts.ContainsKey(otherElementKey))
                    {
                        Layout processedLayout = _processedLayouts[otherElementKey];

                        return processedLayout.Width + value;
                    }
                    //  Process the related element so the position can be calculated.
                    _processedLayouts.Add(otherElementKey, GetPositions(otherElement));
                    return GetWidth(otherElementKey, value);
                }
                throw new KeyNotFoundException(string.Format("Other element with key {0} not found.", otherElementKey));
            }
            return value;
        }

        private float GetYPosition(string otherElementKey, float value, YSide? otherElementSide, bool xAxisInverted,
            float pageHeight)
        {
            if (!string.IsNullOrEmpty(otherElementKey))
            {
                IElementLayoutCreationInput otherElement;
                if (_layoutInputs.TryGetValue(otherElementKey, out otherElement))
                {
                    // First check if refered layout is already been processed, if so get the calculated values.
                    if (_processedLayouts.ContainsKey(otherElementKey))
                    {
                        Layout processedLayout = _processedLayouts[otherElementKey];

                        return otherElementSide == YSide.Top
                            ? GetYValue(xAxisInverted, value + (xAxisInverted ? pageHeight - processedLayout.YPosition : processedLayout.YPosition), pageHeight)
                            : GetYValue(xAxisInverted, value + (xAxisInverted ? pageHeight - processedLayout.YPosition : processedLayout.YPosition) + processedLayout.Height,
                                pageHeight);
                    }
                    //  Process the related element so the position can be calculated.
                    _processedLayouts.Add(otherElementKey, GetPositions(otherElement));
                    return GetYPosition(otherElementKey, value, otherElementSide, xAxisInverted, pageHeight);
                }
                throw new KeyNotFoundException(string.Format("Other element with key {0} not found.", otherElementKey));
            }
            return GetYValue(xAxisInverted, value, pageHeight);
        }

        private float GetYValue(bool xAxisInverted, float y, float pageHeight)
        {
            return xAxisInverted ? pageHeight - y : y;
        }

        private float GetXPosition(string otherElementKey, float value, XSide? side)
        {
            if (!string.IsNullOrEmpty(otherElementKey))
            {
                IElementLayoutCreationInput otherElement;
                if (_layoutInputs.TryGetValue(otherElementKey, out otherElement))
                {
                    // First check if refered layout is already been processed, if so get the calculated values.
                    if (_processedLayouts.ContainsKey(otherElementKey))
                    {
                        Layout processedLayout = _processedLayouts[otherElementKey];

                        return side == XSide.Left
                            ? value + processedLayout.XPosition
                            : value + processedLayout.XPosition + processedLayout.Width;
                    }
                    //  Process the related element so the position can be calculated.
                    _processedLayouts.Add(otherElementKey, GetPositions(otherElement));
                    return GetXPosition(otherElementKey, value, side);
                }
                throw new KeyNotFoundException(string.Format("Other element with key {0} not found.", otherElementKey));
            }
            return value;
        }
    }

    public class ElementProcessingFactory
    {
        
    }
}