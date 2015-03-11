namespace OpenTemplater.Services
{
    public interface IElementCreationService
    {
        PageTemplateProcessingResult CreateElements(PageTemplateInput pageTemplateInput);
    }
}