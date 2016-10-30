using System.Collections.Generic;

namespace text_spacing
{
    public interface ITextParser
    {
        void ReadDictionary(string path);
        void SetDictionary(string[] dictionary);
        IEnumerable<string> SplitText(string text);
    }
}