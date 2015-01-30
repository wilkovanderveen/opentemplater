using System.Collections;
using System.Collections.Generic;

namespace OpenTemplater.Elements
{
    public class Template
    {
        public string Author { get; private set; }
        public IDictionary<string, ColorSet> Colors { get; private set; }
        public IDictionary<string, FontSet> Fonts { get; private set; }

        public DocumentElement Document { get; private set; }

        public Template(DocumentElement document, string author, IDictionary<string, ColorSet> colors, IDictionary<string, FontSet> fonts) : this(document)
        {
            Author = author;
            Colors = colors;
            Fonts = fonts;
        }

        public Template(DocumentElement document)
        {
            Document = document;
        }
    }
}