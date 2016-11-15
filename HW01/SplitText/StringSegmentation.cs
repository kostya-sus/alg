using System.Collections.Generic;
using System.IO;

namespace SplitText
{
    public class StringSegmentation
    {
        private List<string> _partitioningOptions;

        private HashSet<string> _dictionary;

        public void SetDictionary(HashSet<string> dictionary)
        {
            _dictionary = dictionary;
        }

        public void SetDictionaryFromFile(string filepath)
        {
            if (File.Exists(filepath))
            {
                _dictionary = new HashSet<string>();

                using (StreamReader reader = new StreamReader(filepath))
                {
                    while (!reader.EndOfStream)
                    {
                        _dictionary.Add(reader.ReadLine());
                    }
                }
            }
        }

        public List<string> Segmentation(string text, char separator = ' ')
        {
            _partitioningOptions = new List<string>();

            if (_dictionary.Count != 0)
            {
                SplitString(text, string.Empty);
            }

            return _partitioningOptions;
        }

        private void SplitString(string text, string result)
        {
            string prefix;
            string suffix;

            bool isFindSegmentation = false;

            for (int i = 0; i < text.Length; i++)
            {
                prefix = text.Substring(0, i + 1);

                if (isFindSegmentation = _dictionary.Contains(prefix))
                {
                    suffix = text.Substring(i + 1);

                    if (suffix != string.Empty)
                    {
                        SplitString(suffix, result + prefix + " ");
                    }
                    else
                    {
                        result += prefix;
                    }
                }
            }

            if (isFindSegmentation)
            {
                _partitioningOptions.Add(result);
            }

        }
    }
}
