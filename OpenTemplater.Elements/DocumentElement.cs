using System.Collections.Generic;

namespace OpenTemplater.Elements
{
    public class DocumentElement 
    {
        public DocumentElement()
        {
            Pages = new List<PageElement>();
        }

        public IList<PageElement> Pages { get; set; }
        public string Author { get; set; }
    }
}