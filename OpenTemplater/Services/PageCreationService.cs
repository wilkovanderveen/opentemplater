﻿using System;
using System.Collections.Generic;
using System.Linq;
using OpenTemplater.Elements;

namespace OpenTemplater.Services
{
    public class PageCreationService
    {
        private readonly ElementCreationService _elementCreationService;

        public PageCreationService(ElementCreationService elementCreationService)
        {
            _elementCreationService = elementCreationService;
        }

        public IEnumerable<PageElement> CreatePagesFromInput(IEnumerable<PageTemplateInput> pageTemplateInputList)
        {
            IList<PageElement> generatedPages = new List<PageElement>();

            foreach (PageTemplateInput pageTemplateInput in pageTemplateInputList)
            {
                generatedPages.Add(CreatePageElement(pageTemplateInput));
            }
            return generatedPages;
        }

        private PageElement CreatePageElement(PageTemplateInput pageTemplateInput)
        {
            PageElement page = new PageElement
            {
                Elements = GetStaticContents(pageTemplateInput.Key, pageTemplateInput.StaticElementInputs).ToList()
            };

            return page;

        }

        private IEnumerable<IPositionedElement> GetStaticContents(string pageKey, IList<IElementCreationInput> staticElementInputs)
        {
            List<IPositionedElement> positionedElements = new List<IPositionedElement>();


            if (staticElementInputs == null) throw new ArgumentNullException("staticElementInputs");

            foreach (IElementCreationInput elementCreationInput in staticElementInputs)
            {
                _elementCreationService.GetStrategy(elementCreationInput);
            }

            return positionedElements;
        }
    }
}