namespace OpenTemplater.Output.PDF
{
    public class PDFLayoutTransformer
    {
        public TransformedLayout GetLayout(float xPosition, float yPosition, float width, float height)
        {
            return new TransformedLayout(xPosition, yPosition, xPosition + width, yPosition + height);
        }
    }
}