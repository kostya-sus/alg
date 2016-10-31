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

        public IEnumerable<string> SplitText(string textWithoutSpaces)
        {
            var validPrefixesList = GetValidPrefixesList(textWithoutSpaces);

            return GetSplittedSequenes(textWithoutSpaces,validPrefixesList);
        }

        private IEnumerable<string> GetSplittedSequenes(string textWithoutSpaces, IEnumerable<string> validPrefixesList)
        {
            var splittedSequences = new List<string>();
            foreach (var prefix in validPrefixesList)
            {
                int len = prefix.Length;
                string suffix = textWithoutSpaces.Substring(len);
                if (len == textWithoutSpaces.Length)
                {
                    splittedSequences.Add(prefix);
                }
                else
                {
                    ConcatPrefixWithSubsequences(prefix, suffix, splittedSequences);
                }
            }

            return splittedSequences;
        }
        private void ConcatPrefixWithSubsequences(string prefix, string suffix, IList<string> validWordsList)
        {
            var validWordsSequencesForSuffix = SplitText(suffix);
            foreach (var wordsSequence in validWordsSequencesForSuffix)
            {
                validWordsList.Add(string.Format("{0} {1}", prefix, wordsSequence));
            }
        }

        private List<string> GetValidPrefixesList(string text)
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