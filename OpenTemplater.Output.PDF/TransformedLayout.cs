namespace OpenTemplater.Output.PDF
{
    public class TransformedLayout
    {
        public TransformedLayout(float lowerLeftX, float lowerLeftY, float upperRightX, float upperRightY)
        {
            LowerLeftX = lowerLeftX;
            LowerLeftY = lowerLeftY;
            UpperRightX = upperRightX;
            UpperRightY = upperRightY;
        }

        public float LowerLeftX { get; private set; }
        public float LowerLeftY { get; private set; }
        public float UpperRightX { get; private set; }
        public float UpperRightY { get; private set; }
    }
}