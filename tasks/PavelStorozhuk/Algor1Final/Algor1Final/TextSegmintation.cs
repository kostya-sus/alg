using System;

namespace Algor1Final
{
    public static class TextSegmintation
    {
        public static string WordSegmintaion(string text, MyDictionary dictionary)
        {
            var result = String.Empty;
            var buf = string.Empty;
            for (int i = 0; i < text.Length; i++)
            {
                buf += text[i];

                {
                    if (dictionary.Contains(buf))
                    {
                     
                        {
                            result += buf + " ";
                            buf = string.Empty;
                        }
                    }
                }
            }
            return result;
        }
    }
}