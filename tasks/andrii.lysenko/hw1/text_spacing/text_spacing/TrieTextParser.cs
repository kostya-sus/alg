using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_spacing
{
    class TrieTextParser : ITextParser
    {
        private Trie _trie;

        public void ReadDictionary(string path)
        {
            SetDictionary(File.ReadAllLines(path));
        }

        public void SetDictionary(string[] dictionary)
        {
            _trie = new Trie();
            foreach (var word in dictionary)
            {
                _trie.Add(word);
            }
        }

        public IEnumerable<string> SplitText(string text)
        {
            var subtexts = new List<string>();
            var substrings = new List<string>();

            for (int i = 1; i <= text.Length; i++)
            {
                string key = text.Substring(0, i);
                var prefixExistance = _trie.Contains(key);
                if (prefixExistance == NodeExistance.IsWord)
                {
                    substrings.Add(key);
                }
                else if (prefixExistance == NodeExistance.NotExists)
                {
                    break;
                }
            }

            foreach (var substring in substrings)
            {
                if (substring.Length == text.Length)
                {
                    subtexts.Add(substring);
                }
                else
                {
                    string rest = text.Substring(substring.Length);
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