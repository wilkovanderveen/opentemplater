using System;

namespace OpenTemplater.Elements
{
    public class PMSColor : IColor
    {
        public PMSColor(string key, string name)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("key");
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");

            Key = key;
            Name = name;
        }

        public string Name { get; private set; }
        public string Key { get; private set; }
    }
}