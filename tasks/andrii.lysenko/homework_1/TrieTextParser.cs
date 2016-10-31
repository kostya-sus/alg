using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_spacing
{
    class TrieTextParser : TextParser
    {
        private Trie _trie;

        public override void SetDictionary(string[] dictionary)
        {
            _trie = new Trie();
            foreach (var word in dictionary)
            {
                _trie.Add(word);
            }
        }

        protected override List<string> GetValidPrefixesList(string text)
        {
            var validPrefixesList = new List<string>();

            for (int i = 1; i <= text.Length; i++)
            {
                string key = text.Substring(0, i);
                var prefixExistance = _trie.Contains(key);
                if (prefixExistance == NodeExistance.IsWord)
                {
                    validPrefixesList.Add(key);
                }
                else if (prefixExistance == NodeExistance.NotExists)
                {
                    break;
                }
            }

            return validPrefixesList;
        }
    }
}