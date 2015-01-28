namespace OpenTemplater.Elements
{
    public class TemplateElement
    {
        public string Author { get; private set; }

        public DocumentElement Document { get; private set; }

        public TemplateElement(DocumentElement document, string author) : this(document)
        {
            Author = author;
        }

        public TemplateElement(DocumentElement document)
        {
            Document = document;
        }
    }
}