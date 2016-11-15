using System;
using System.Collections.Generic;
using System.Linq;

namespace HW1_ALG
{
    class WordDivider
    {
        private string _inputString;
        private string[] _dictionary;

        private List<string> words = new List<string>();

        private void GetStrings(string inputStr, string resultStr)
        {
            if (inputStr.Length == 0)
            {
                Console.WriteLine(resultStr);
                return;
            }

            int size = inputStr.Length,
                i = 0;
            string word= string.Empty;

            while (i < size)
            {
                word += inputStr[i];
                if (_dictionary.Contains(word))
                {
                    GetStrings(inputStr.Substring(i + 1), resultStr + " " + word);
                }
                i++;
            }
        }

        public WordDivider(string s, string[] dict)
        {
            _inputString = s;
            _dictionary = dict;
        }

        public void WordsEmpty()
        {
            GetStrings(_inputString, string.Empty);
        }

       
    }
}
