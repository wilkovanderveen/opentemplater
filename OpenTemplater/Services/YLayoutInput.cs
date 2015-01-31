namespace OpenTemplater.Services
{
    public class YLayoutInput
    {
        public float Value { get; set; }
        public string OtherElementKey { get; set; }
        public YSide OtherElementSide { get; set; }
        public bool XAxisInverted { get; set; }
        public float PageHeight { get; set; }
    }
}