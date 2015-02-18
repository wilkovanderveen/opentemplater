namespace OpenTemplater.Services
{
    public interface IElementLayoutCreationInput : IElementCreationInput 
    {
        XLayoutInput XLayoutInput { get; }
        YLayoutInput YLayoutInput { get; set; }
        WidthInput WidthInput { get; set; }
        HeightInput HeightInput { get; set; }
        
    }
}