using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordDelimeter
{
    public static class DictionaryFiller
    {
        public static List<String> FillDictionary(string fullPath, char targetChar)
        {
            if(!File.Exists(fullPath))
            {
                throw new FileNotFoundException();
            }

            List<String> _dictionaryByChar = new List<String>();

            using (FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.None))
            { 
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (true)
                    {
                        string word = sr.ReadLine();
                        if((word == null))
                        {
                            return _dictionaryByChar;
                        }
                        else if((word == String.Empty) || (word[0] != targetChar))
                        {
                            continue;
                        }
                        _dictionaryByChar.Add(word);
                    }
                }
            }
        }


    }
}
