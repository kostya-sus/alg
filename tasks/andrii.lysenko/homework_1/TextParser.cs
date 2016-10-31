using System.Collections.Generic;
using System.IO;

namespace text_spacing
{
    public abstract class TextParser
    {
        public void ReadDictionary(string path)
        {
            SetDictionary(File.ReadAllLines(path));
        }

        public abstract void SetDictionary(string[] dictionary);

        public virtual IEnumerable<string> SplitText(string textWithoutSpaces)
        {
            var validPrefixesList = GetValidPrefixesList(textWithoutSpaces);

            return GetSplittedSequences(textWithoutSpaces, validPrefixesList);
        }

        protected abstract List<string> GetValidPrefixesList(string textWithoutSpaces);

        protected IEnumerable<string> GetSplittedSequences(string textWithoutSpaces,
            IEnumerable<string> validPrefixesList)
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

        protected void ConcatPrefixWithSubsequences(string prefix, string suffix, IList<string> validWordsList)
        {
            var validWordsSequencesForSuffix = SplitText(suffix);
            foreach (var wordsSequence in validWordsSequencesForSuffix)
            {
                validWordsList.Add(string.Format("{0} {1}", prefix, wordsSequence));
            }
        }
    }
}