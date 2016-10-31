using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_spacing
{
    public class BruteForceTextParser : ITextParser
    {
        private string[] _dictionary;

        public void ReadDictionary(string path)
        {
            SetDictionary(File.ReadAllLines(path));
        }

        public void SetDictionary(string[] dictionary)
        {
            _dictionary = dictionary;
        }

        public IEnumerable<string> SplitText(string text)
        {
            if (string.IsNullOrEmpty(text)) return new List<string> {""};
            var subtexts = new List<string>();

            var substrings = new List<string>();
            for (int i = 1; i <= text.Length; i++)
            {
                string prefix = text.Substring(0, i);
                if (_dictionary.Contains(prefix))
                {
                    substrings.Add(prefix);
                }
            }

            foreach (var substring in substrings)
            {
                int len = substring.Length;
                string rest = text.Substring(len);
                if (len == text.Length)
                {
                    subtexts.Add(substring);
                }
                else
                {
                    var nextSubtexts = SplitText(rest);
                    foreach (var nextSubtext in nextSubtexts)
                    {
                        subtexts.Add(string.Format("{0} {1}", substring, nextSubtext));
                    }
                }
            }

            return subtexts;
        }
    }
}