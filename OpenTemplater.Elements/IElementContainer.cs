using System.Collections.Generic;

namespace OpenTemplater.Elements
{
    /// <summary>
    /// Interface for container objects.
    /// </summary>
    public interface IElementContainer
    {
        IList<IPositionedElement> Elements { get; }
    }
}