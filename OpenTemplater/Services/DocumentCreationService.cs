using System;
using System.Collections.Generic;
using OpenTemplater.Elements;

namespace OpenTemplater.Services
{
    public class DocumentCreationService
    {
        private readonly DocumentContext _documentContext;
        private readonly ElementCreationFactory _elementCreationFactory;
        private readonly IUnitConversionService _unitConversionService;

        public DocumentCreationService(DocumentContext documentContext, IUnitConversionService unitConversionService,
            ElementCreationFactory elementCreationFactory)
        {
            _documentContext = documentContext;
            _unitConversionService = unitConversionService;
            _elementCreationFactory = elementCreationFactory;
        }

        public DocumentElement CreateDocument(IEnumerable<PageTemplateInput> pageTemplateInputs)
        {
            var resultDocument = new DocumentElement();

            IEnumerable<PageTemplateProcessingResult> pageTemplateProcessingResults =
                ProcessTemplates(pageTemplateInputs);

            List<PageElement> resultPages = new List<PageElement>();

            foreach (PageTemplateProcessingResult input in pageTemplateProcessingResults)
            {
                resultPages.AddRange(_documentContext.PagingService.ExtractPagesFromTemplate(input.StaticContents,
                    input.DynamicContents,
                    input.DynamicContentTopMargin,
                    input.DynamicContentBottomMargin));
            }

            resultDocument.Pages = resultPages;

            return resultDocument;
        }

        private IEnumerable<PageTemplateProcessingResult> ProcessTemplates(
            IEnumerable<PageTemplateInput> pageTemplateInputs)
        {
            IList<PageTemplateProcessingResult> pageTemplateProcessingResults = new List<PageTemplateProcessingResult>();

            foreach (PageTemplateInput input in pageTemplateInputs)
            {
                pageTemplateProcessingResults.Add(CreatePage(input));
            }

            return pageTemplateProcessingResults;
        }

        private PageTemplateProcessingResult CreatePage(PageTemplateInput input)
        {
            var result = new PageTemplateProcessingResult
            {
                BleedSpace = _unitConversionService.GetValue(input.BleedSpace),
                SlugSpace = _unitConversionService.GetValue(input.SlugSpace),
            };

            result.StaticContents.AddRange(GetStaticElements(input.StaticContent));
            result.DynamicContents.AddRange(GetDynamicElements(input.DynamicContent));

            return result;
        }

        private IEnumerable<IPositionedElement> GetDynamicElements(DynamicContentInput dynamicContent)
        {
            IList<IPositionedElement> resultList = new List<IPositionedElement>();

            if (dynamicContent == null)
            {
                 resultList = new List<IPositionedElement>();
            }
            else
            {
                foreach (IElementLayoutCreationInput input in dynamicContent.Elements)
                {
                    resultList.Add(_elementCreationFactory.GetElement(input));
                }
            }
            return resultList;
        }

        private IEnumerable<IPositionedElement> GetStaticElements(StaticContentInput staticContent)
        {
            if (staticContent == null) throw new ArgumentNullException("staticContent");

            foreach (IElementLayoutCreationInput input in staticContent.Elements)
            {
                yield return _elementCreationFactory.GetElement(input);
            }
        }
    }

    public class PageTemplateProcessingResult
    {
        public PageTemplateProcessingResult()
        {
            StaticContents = new List<IPositionedElement>();
            DynamicContents = new List<IPositionedElement>();
        }

        public string Key { get; set; }
        public List<IPositionedElement> StaticContents { get; private set; }
        public List<IPositionedElement> DynamicContents { get; private set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float BleedSpace { get; set; }
        public float SlugSpace { get; set; }
        public float DynamicContentTopMargin { get; set; }
        public float DynamicContentBottomMargin { get; set; }
    }
}