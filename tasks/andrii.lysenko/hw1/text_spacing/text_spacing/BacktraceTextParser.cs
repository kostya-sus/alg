using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_spacing
{
    public class BacktraceTextParser : ITextParser
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

            string prefix = text.Substring(0, 1);

            List<string> wordsWithPrefix = GetAllWordsWithPrefix(prefix, _dictionary);
            int len = 2;

            var substrings = new List<string>();
            while (wordsWithPrefix.Any())
            {
                foreach (var word in wordsWithPrefix)
                {
                    if (prefix.Length == word.Length)
                    {
                        substrings.Add(prefix);
                        break;
                    }
                }
                if (len == text.Length + 1) break;

                prefix = text.Substring(0, len++);

                wordsWithPrefix = GetAllWordsWithPrefix(prefix, wordsWithPrefix);
            }

            foreach (var substring in substrings)
            {
                len = substring.Length;
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

        private List<string> GetAllWordsWithPrefix(string prefix, IEnumerable<string> dictionary)
        {
            var wordsWithGivenPrefix = new List<string>();

            foreach (var word in dictionary)
            {
                if (word.StartsWith(prefix))
                {
                    wordsWithGivenPrefix.Add(word);
                }
            }

            return wordsWithGivenPrefix;
        }
    }
}