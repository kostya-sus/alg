using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordDelimeter
{
    class Program
    {
        private const string DefaultDictPath = "dict_en.txt";
        //private const string DefaultCheckString = "iamace";
        private const string DefaultCheckString = "helloworld";
        //private const string DefaultCheckString = "catsanddog";
        //private const string DefaultCheckString = "goodluck";
        //private const string DefaultCheckString = "seesunweather";
        //private const string DefaultCheckString = "tellmethetruth";
        private const int FillerStartAlphabet = 97;
        private const int FillerStopAlphabet = 122;
        private const int FillerStartNumbers = 48;
        private const int FillerStopNumbers = 57;

        private static List<Char> _dictionariesByChar;
        private static List<String>[] _listByChar;
        private static Dictionary<String, Boolean> _memo;

        static void Main(string[] args)
        {
            _dictionariesByChar = new List<Char>();
            FillCharArray();
            _listByChar = new List<String>[_dictionariesByChar.Count];
            _memo = new Dictionary<String, Boolean>();
            FillListByChar();
            Deli(DefaultCheckString.ToLower());
        }

        static void Deli(string input)
        {
            //If whole word is in dictionary
            if (IsInDictionary(input))
            {
                Console.WriteLine(input);
                return;
            }

            Console.WriteLine("Input string : {0}", input);
            Console.WriteLine("Dictionary : {0}", DefaultDictPath);
            Console.WriteLine("Possible words are:");
            Stopwatch measure = new Stopwatch();
            measure.Start();
            Deli(input, input.Length, "");
            measure.Stop();
            Console.WriteLine("\n{0} ms elapsed. ", measure.ElapsedMilliseconds);
        }

        static void Deli(string input, int length, string output)
        {
            for (int i = 1; i <= length; i++)
            {
                string target = input.Substring(0, i);

                if(!_memo.ContainsKey(target) && IsInDictionary(target))
                {
                    _memo.Add(target, true);
                }

                if (target.Length == 0)
                {
                    continue;
                }

                if (_memo.ContainsKey(target))
                {
                    if (i == length)
                    {
                        output += target;
                        Console.WriteLine("{0}", output);
                        return;
                    }
                    Deli(input.Substring(i, length - i), length - i, output + target + " ");
                }
            }
        }


        static bool IsInMemo(string search)
        {
            return _memo.ContainsKey(search);
        }

        static bool IsInDictionary(string search)
        {
            return _listByChar[_dictionariesByChar.IndexOf(search[0])].IndexOf(search) == -1 ? false : true;
        }

        static void FillListByChar()
        {
            for (int i = 0; i < _listByChar.Length; i++)
            {
                _listByChar[i] = DictionaryFiller.FillDictionary(DefaultDictPath, _dictionariesByChar[i]);
            }
        }

        static void FillCharArray()
        {
            int rangeOne = FillerStopAlphabet - FillerStartAlphabet;
            int rangeTwo = rangeOne + (FillerStopNumbers - FillerStartNumbers) + 1;

            int index = 0;
            for (int i = 0; i <= rangeOne; i++)
            {
                _dictionariesByChar.Add((char)(FillerStartAlphabet + index));
                index++;
            }

            index = 0;
            for (int i = rangeOne + 1; i <= rangeTwo; i++)
            {
                _dictionariesByChar.Add((char)(FillerStartNumbers + index));
                index++;
            }

            _dictionariesByChar.Add('&');
            _dictionariesByChar.Add('\'');
        }
    }
}
