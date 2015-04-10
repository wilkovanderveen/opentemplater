using System;
using iTextSharp.text;
using OpenTemplater.Elements;


namespace OpenTemplater.Output.PDF.Renderers
{
    public class ColorFactory
    {
        public Color GetColor(IColor color)
        {
            if (color is CMYKColor)
            {
                CMYKColor cmykColor = color as CMYKColor;

                return new iTextSharp.text.pdf.CMYKColor(cmykColor.Cyan, cmykColor.Magenta, cmykColor.Yellow,
                    cmykColor.Black);
            }

            throw new NotSupportedException("Cannot use color of type {0}");
        }
    }
}