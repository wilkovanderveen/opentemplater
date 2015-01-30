using System;

namespace OpenTemplater.Elements
{
    public class PMSColor
    {
        public PMSColor(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");

            Name = name;
        }

        public string Name { get; private set; }
    }
}