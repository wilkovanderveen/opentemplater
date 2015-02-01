namespace OpenTemplater.Services
{
    public class YLayoutInput
    {
        public float Value { get; set; }
        public string OtherElementKey { get; set; }
        public YSide? OtherElementSide { get; set; }

        /// <summary>
        /// Is the X-axis inverted. Normally the X-Axis starts with 0 on the bottom of the page, if the X-axis is inverted the axis starts with 0 on the page top.
        /// </summary>
        public bool XAxisInverted { get; set; }

        /// <summary>
        /// Pageheight in pica points.
        /// </summary>
        public float PageHeight { get; set; }
    }
}