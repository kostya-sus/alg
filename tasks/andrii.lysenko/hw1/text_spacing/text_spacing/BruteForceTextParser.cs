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

        public IEnumerable<string> SplitText(string textWithoutSpaces)
        {
            var validPrefixesList = GetValidPrefixesList(textWithoutSpaces);

            return GetSplittedSequences(textWithoutSpaces, validPrefixesList);
        }

        private IEnumerable<string> GetSplittedSequences(string textWithoutSpaces, IEnumerable<string> validPrefixesList)
        {
            var splittedSequences = new List<string>();
            foreach (var prefix in validPrefixesList)
            {
                int len = prefix.Length;
                if (len == textWithoutSpaces.Length)
                {
                    splittedSequences.Add(prefix);
                }
                else
                {
                    string suffix = textWithoutSpaces.Substring(len);
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

        private List<string> GetValidPrefixesList(string textWithoutSpaces)
        {
            var validPrefixesList = new List<string>();
            for (int i = 1; i <= textWithoutSpaces.Length; i++)
            {
                string prefix = textWithoutSpaces.Substring(0, i);
                if (_dictionary.Contains(prefix))
                {
                    validPrefixesList.Add(prefix);
                }
            }
            return validPrefixesList;
        }
    }
}