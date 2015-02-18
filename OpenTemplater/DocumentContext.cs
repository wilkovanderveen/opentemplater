using System;
using System.Collections.Generic;
using OpenTemplater.Elements;
using OpenTemplater.Services;
using OpenTemplater.Services.CreationStrategies;

namespace OpenTemplater
{
    public class DocumentContext
    {
        private readonly IPagingService _pagingService;
        private readonly IDictionary<string, IDictionary<string, IElement>> _pageInputs;

        public DocumentContext(IColorService colorService, IFontService fontService, IPagingService pagingService)
        {
            if (colorService == null) throw new ArgumentNullException("colorService");
            if (fontService == null) throw new ArgumentNullException("fontService");
            if (pagingService == null) throw new ArgumentNullException("pagingService");

            PagingService = pagingService;
            ColorService = colorService;
            FontService = fontService;
            _pageInputs = new Dictionary<string, IDictionary<string, IElement>>();
        }

        public IColorService ColorService { get; private set; }

        public IFontService FontService { get; private set; }
        public IPagingService PagingService { get; private set; }

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
}