namespace OpenTemplater.Elements
{
    public class Template
    {
        public string Author { get; private set; }
        
        public DocumentElement Document { get; private set; }

        public Template(DocumentElement document, string author) : this(document)
        {
            Author = author;
        }

        public Template(DocumentElement document)
        {
            Document = document;
        }
    }
}