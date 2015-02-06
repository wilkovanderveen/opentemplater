using System;
using System.Collections.Generic;
using OpenTemplater.Elements;
using OpenTemplater.Services;
using OpenTemplater.Services.CreationStrategies;

namespace OpenTemplater
{
    public class DocumentContext
    {
        private readonly IDictionary<string, IDictionary<string, IElement>> _pageInputs;

        public DocumentContext(IColorService colorService, IFontService fontService)
        {
            ColorService = colorService;
            FontService = fontService;
            _pageInputs = new Dictionary<string, IDictionary<string, IElement>>();
        }

        public IColorService ColorService { get; private set; }

        public IFontService FontService { get; private set; }
        public IPagingService PagingService { get; set; }

        public void AddPage(string key)
        {
            if (!_pageInputs.ContainsKey(key))
            {
                _pageInputs.Add(key, new Dictionary<string, IElement>());
            }
            throw new NotSupportedException("Cannot add item with same key more than once.");
        }

        public void AddElement(string pageKey, IElement element)
        {
            IDictionary<string, IElement> currentPage = _pageInputs[pageKey];
            currentPage.Add(element.Key, element);
        }
    }

    public interface IPagingService
    {
        IList<PageElement> ExtractPages(DynamicContentInput dynamicContentInput);
    }
}