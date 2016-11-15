
using System.Collections.Generic;
using System.IO;


namespace HW1_ALG
{
    class Dictionary
    {
        public string[] ParseDictionary()
        {
            string wordpull = ReadFile();
            string temp = string.Empty;
            List<string> dictionary = new List<string>();
            

            int i = 0,
                size = wordpull.Length;

            while (i < size)
            {
                if (wordpull[i] == '\'' || char.IsLetter(wordpull[i]) || char.IsDigit(wordpull[i]))
                {
                    temp += wordpull[i];
                }
                else if (temp.Length != 0)
                {
                    dictionary.Add(temp);
                    temp = string.Empty;
                }
                i++;
            }

            if (temp.Length != 0)
                dictionary.Add(temp);

            return dictionary.ToArray();
        }


        public string ReadFile()
        {
            StreamReader pull = File.OpenText("dict_en.txt");
            return pull.ReadToEnd();
        }
    }
}
