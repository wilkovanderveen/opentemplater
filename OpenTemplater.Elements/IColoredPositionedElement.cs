namespace OpenTemplater.Elements
{
    /// <summary>
    /// Interface for elements which have color.
    /// </summary>
    public interface IColoredPositionedElement : IPositionedElement
    {
        IColor Color { get; }
    }
}