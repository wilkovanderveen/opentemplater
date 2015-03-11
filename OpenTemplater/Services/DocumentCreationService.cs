using System;
using System.Collections.Generic;
using OpenTemplater.Elements;
using OpenTemplater.Elements.Modules;

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

            var resultPages = new List<PageElement>();

            foreach (PageTemplateProcessingResult input in pageTemplateProcessingResults)
            {
                resultPages.AddRange(_documentContext.PagingService.ExtractPagesFromTemplate(input.StaticContents,
                    input.DynamicContents,
                    input.Height,
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

            if (input.DynamicContent != null)
            {
                var layout = new ContentBoundaries
                {
                    Top = _unitConversionService.GetValue(input.DynamicContent.Y),
                    Height = _unitConversionService.GetValue(input.DynamicContent.Height),
                    PageHeight = _unitConversionService.GetValue(input.Height)
                };

                result.DynamicContentTopMargin = layout.PageHeight - layout.Top;
                result.DynamicContentBottomMargin = layout.PageHeight - (layout.Height - layout.Top);
                result.Height = layout.PageHeight;
            }

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

            IDictionary<string, IElementLayoutCreationInput> inputDictionary = new Dictionary<string, IElementLayoutCreationInput>();
            foreach (IElementLayoutCreationInput input in staticContent.Elements)
            {
                inputDictionary.Add(input.Key, input);   
            }
            LayoutService layoutService = new LayoutService(inputDictionary);
            IDictionary<string, Layout> layoutResults = layoutService.ProcesElements();

            IList<IPositionedElement> results = new List<IPositionedElement>();

            foreach (IElementCreationInput input in staticContent.Elements)
            {
               IPositionedElement element =  _elementCreationFactory.GetElement(input);
            }

            throw new NotImplementedException();
        }
    }
}