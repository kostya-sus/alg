using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordDelimeter
{
    public static class Dictionary
    {
        public static HashSet<String> Load(string fullPath)
        {
            if(!File.Exists(fullPath))
            {
                throw new FileNotFoundException();
            }

            HashSet<String> _dictionary = new HashSet<String>();

            using (FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.None))
            { 
                using (StreamReader sr = new StreamReader(fs))
                {
                    string word = sr.ReadLine();
                    while(word != null)
                    {
                        _dictionary.Add(word);
                        word = sr.ReadLine();
                    }
                }
            }
            return _dictionary;
        }
    }
}
