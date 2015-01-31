namespace OpenTemplater.Services
{
    public interface IElementLayoutInput
    {
        XLayoutInput XLayoutInput { get; }
        YLayoutInput YLayoutInput { get; set; }
        WidthInput WidthInput { get; set; }
        HeightInput HeightInput { get; set; }
        string Key { get; set; }
    }
}