namespace OpenTemplater.Elements
{
    /// <summary>
    /// Interface for elements.
    /// </summary>
    public interface IPositionedElement : IElement 
    {
    
        float XPosition { get; }
        float YPosition { get; }
    }
}