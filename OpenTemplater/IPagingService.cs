using System.Collections.Generic;
using System.Linq;
using OpenTemplater.Elements;
using OpenTemplater.Services;

namespace OpenTemplater
{
    public class PagingService : IPagingService
    {
        public IList<PageElement> ExtractPagesFromTemplate(IList<IPositionedElement> staticContent, IList<IPositionedElement> dynamicContentElements, float pageHeight, float maxHeight)
        {
            List<PageElement> pageElements = new List<PageElement>();

            PageElement currentPage = new PageElement();
            AddStaticContents(currentPage, staticContent);

            // Process all elements. If a element does not fit, move it to next page.
            if (dynamicContentElements.Any())
            {
                foreach (IPositionedElement positionedElement in dynamicContentElements)
                {
                    if ((positionedElement.YPosition - positionedElement.Height) > (pageHeight - maxHeight))
                    {
                        // Element Fits.
                        currentPage.Elements.Add(positionedElement);
                    }
                    else
                    {
                        pageElements.Add(currentPage);
                        currentPage = new PageElement();

                        AddStaticContents(currentPage, staticContent);
                        currentPage.Elements.Add(positionedElement);
                    }
                }
            }
            else
            {
                pageElements.Add(currentPage);
            }
            return pageElements;
        }

        private void AddStaticContents(PageElement currentPage, IList<IPositionedElement> staticContent)
        {
            currentPage.Elements = staticContent;
        }
    }

    public interface IPagingService
    {
        IList<PageElement> ExtractPagesFromTemplate(IList<IPositionedElement> staticContent,
            IList<IPositionedElement> dynamicContentElements, float pageHeight, float maxHeight);
    }
}