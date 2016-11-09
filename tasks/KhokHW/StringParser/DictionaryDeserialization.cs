using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringParser
{
    class DictionaryDeserialization
    {
        public string[] GetWords()
        {
            string str = ReadFromFile();
            List<string> dictionary = new List<string>();
            string temp = string.Empty;

            int i = 0;
            int size = str.Length;
            while(i < size)
            {
                if (str[i] == '\'' || char.IsLetter(str[i]) || char.IsDigit(str[i]))
                {
                    temp += str[i];
                }
                else if(temp.Length != 0)
                {
                    dictionary.Add(temp);
                    temp = string.Empty;
                }
                ++i;
            }

            if (temp.Length != 0)
                dictionary.Add(temp);

            return dictionary.ToArray();
        }

        public string ReadFromFile()
        {
            StreamReader sr = File.OpenText("dict_en.txt");
            return sr.ReadToEnd();
        }
    }
}
