using System;
using System.Collections.Generic;
using System.IO;

namespace WordDelimeter
{
    public class Dictionary
    {
        private HashSet<string> _wordSet;

        public HashSet<string> WordSet
        {
            get { return _wordSet; }
        }

        public Dictionary(string sourcePath)
        {
            _wordSet = LoadDictionary(sourcePath);
            if(_wordSet.Count == 0)
            {
                throw new Exception("Dictionary can't be empty!");
            }
        }

        public bool Contains(string value)
        {
            return _wordSet.Contains(value);
        }

        private HashSet<string> LoadDictionary(string fullPath)
        {
            var dictionary = new HashSet<string>();

            using (FileStream fs = new FileStream(fullPath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string word = sr.ReadLine();
                    while (word != null)
                    {
                        dictionary.Add(word);
                        word = sr.ReadLine();
                    }
                }
            }
            return dictionary;
        }
    }
}
