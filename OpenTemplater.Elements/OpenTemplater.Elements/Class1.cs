using System.Collections.Generic;

namespace OpenTemplater.Elements
{
    public class Document
    {
        public Document()
        {
            Pages = new List<Page>();
        }

        public IList<Page> Pages { get; set; }
    }

    public class Page : IElement, IElementContainer
    {
        public Page()
        {
            Elements = new List<IPositionedElement>();
        }

        public string Key { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public IList<IPositionedElement> Elements { get; set; }
    }

    public class Rectangle : IColoredPositionedElement, IElementContainer
    {
        public Rectangle()
        {
            Elements = new List<IPositionedElement>();
        }

        public float BorderWidth { get; set; }
        public IColor BorderColor { get; set; }
        public string Key { get;  set; }
        public float XPosition { get; set; }
        public float YPosition { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public IColor Color { get; set; }
        public IList<IPositionedElement> Elements { get; private set; }
    }

    public class Line : IColoredPositionedElement
    {
        public float LineWidth { get; set; }
        public string Key { get; private set; }
        public float XPosition { get; set; }
        public float YPosition { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public IColor Color { get; set; }
    }

    public class Elipse : IColoredPositionedElement
    {
        public float BorderWidth { get; set; }
        public IColor BorderColor { get; set; }
        public string Key { get; private set; }
        public float XPosition { get; set; }
        public float YPosition { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public IColor Color { get; set; }
    }

    public class Image : IPositionedElement
    {
        public string Key { get; set; }
        public float XPosition { get; set; }
        public float YPosition { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
    }
}