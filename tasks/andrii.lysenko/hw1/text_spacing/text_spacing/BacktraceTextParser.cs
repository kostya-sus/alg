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
        private struct PrefixFilterResults
        {
            public bool IsWord { get; set; }
            public List<string> Prefixes { get; set; }
        }

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

            var prefixFiltered = FilterByPrefix(prefix, _dictionary);
            int len = 2;

            var substrings = new List<string>();
            while (prefixFiltered.Prefixes.Any())
            {
                if (prefixFiltered.IsWord)
                {
                    substrings.Add(prefix);
                }

                if (len == text.Length + 1) break;

                prefix = text.Substring(0, len++);

                prefixFiltered = FilterByPrefix(prefix, prefixFiltered.Prefixes);
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

        private PrefixFilterResults FilterByPrefix(string prefix, IEnumerable<string> dictionary)
        {
            var result = new PrefixFilterResults {Prefixes = new List<string>()};

            foreach (var word in dictionary)
            {
                if (word.StartsWith(prefix))
                {
                    if (word.Length == prefix.Length)
                    {
                        result.IsWord = true;
                    }
                    else
                    {
                        result.Prefixes.Add(word);
                    }
                }
            }

            return result;
        }
    }
}