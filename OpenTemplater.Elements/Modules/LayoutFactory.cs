﻿using System;

namespace OpenTemplater.Elements.Modules
{
    public class LayoutFactory
    {
        public Layout GetLayout(IElementContainer container, bool xAxisInverted, float pageHeight, float x, float y, float width, float height)
        {
            float horizontalOffset = (container == null || container is PageElement) ? 0 :  (container as IPositionedElement).XPosition;
            float verticalOffset = (container == null || container is PageElement) ? 0 : (container as IPositionedElement).YPosition;

            return new Layout(horizontalOffset, GetVerticalPosition(xAxisInverted, verticalOffset, pageHeight), width, height);
        }

        float GetVerticalPosition(bool xAxisInverted, float y, float pageHeight)
        {
            return xAxisInverted ? pageHeight - y : y;
        }
    }
}