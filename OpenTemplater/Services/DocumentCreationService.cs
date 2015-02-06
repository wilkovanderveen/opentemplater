using System.Collections.Generic;
using OpenTemplater.Services.CreationStrategies;

namespace OpenTemplater.Services
{
    public class DocumentCreationService
    {
        private readonly DocumentContext _documentContext;
        private readonly ElementCreationService _elementCreationService;

        public DocumentCreationService(DocumentContext documentContext, ElementCreationService elementCreationService)
        {
            _documentContext = documentContext;
            _elementCreationService = elementCreationService;
        }

        public void CreateDocument(IEnumerable<PageInput> pageInputs)
        {
            foreach (PageInput input in pageInputs)
            {
                if (input.DynamicContent != null)
                {
                    _documentContext.PagingService.ExtractPages(input.DynamicContent);
                }
            }
        }
    }

    public class PageInput
    {
        public string Key { get; set; }
        public DynamicContentInput DynamicContent { get; set; }
        public StaticContentInput StaticContent { get; set; }
    }

    public class DynamicContentInput : StaticContentInput
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public string OverflowTemplate { get; set; }
    }

    public class StaticContentInput
    {
        public IList<IElementCreationInput> Elements { get; set; }
    }
}