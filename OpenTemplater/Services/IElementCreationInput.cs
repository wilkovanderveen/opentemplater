namespace OpenTemplater.Services
{
    public interface IElementCreationInput
    {
        string Key { get; }
        string Name { get; }
        string ZOrder { get; }
        IElementLayoutInput LayoutInput { get; }
    }
}