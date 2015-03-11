using System.Collections.Generic;
using OpenTemplater.Elements;
using OpenTemplater.Services;

namespace OpenTemplater
{
    public interface IPagingService
    {
        /// <summary>
        /// Extracts one or more pages from <see cref="PageTemplateInput" />.
        /// </summary>
        /// <param name="staticContent"></param>
        /// <param name="dynamicContentElements"></param>
        /// <param name="pageHeight"></param>
        /// <param name="maxHeight"></param>
        /// <returns></returns>
        IList<PageElement> ExtractPagesFromTemplate(IList<IPositionedElement> staticContent,
            IList<IPositionedElement> dynamicContentElements, float pageHeight, float maxHeight);
    }
}