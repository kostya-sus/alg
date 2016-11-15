using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Alg_Task1
{
    enum Alphabet : byte
    {
        A = 0,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        N,
        O,
        P,
        Q,
        R
        ,
        S,
        T,
        U,
        V,
        W,
        X,
        Y,
        Z
    }

    class Dictionary
    {
        private FileStream _stream;
        private StreamReader _reader;
        private Letter[] _letters = new Letter[26];
        private string _text;

        public Dictionary(string path, string text)
        {

            _stream = File.OpenRead(path);
            _reader = new StreamReader(_stream);
            _text = text;
            for (int i = 0; i < _letters.Length; i++)
            {
                _letters[i] = new Letter();
            }

        }

        public string GetResult()
        {
            var result = String.Empty;
            var buf = string.Empty;
            for (int i = 0; i < _text.Length; i++)
            {
                buf += _text[i];

                {
                    if (SearchWord(buf))
                    {
                        result += buf + " ";
                        buf = string.Empty;
                    }
                }
            }
            return result;
        }

        public bool SearchWord(string word)
        {
            int index = -1;
            switch (word[0].ToString().ToLower())
            {
                case "a":
                    index = _letters[(int) Alphabet.A]._wordsArray.BinarySearch(word);
                    break;
                case "b":
                    index = _letters[(int) Alphabet.B]._wordsArray.BinarySearch(word);
                    break;
                case "c":
                    index = _letters[(int) Alphabet.C]._wordsArray.BinarySearch(word);
                    break;
                case "d":
                    index = _letters[(int) Alphabet.D]._wordsArray.BinarySearch(word);
                    break;
                case "e":
                    index = _letters[(int) Alphabet.E]._wordsArray.BinarySearch(word);
                    break;
                case "f":
                    index = _letters[(int) Alphabet.F]._wordsArray.BinarySearch(word);
                    break;
                case "g":
                    index = _letters[(int) Alphabet.G]._wordsArray.BinarySearch(word);
                    ;
                    break;
                case "h":
                    index = _letters[(int) Alphabet.H]._wordsArray.BinarySearch(word);
                    break;
                case "i":
                    index = _letters[(int) Alphabet.I]._wordsArray.BinarySearch(word);
                    break;
                case "j":
                    index = _letters[(int) Alphabet.J]._wordsArray.BinarySearch(word);
                    break;
                case "k":
                    index = _letters[(int) Alphabet.K]._wordsArray.BinarySearch(word);
                    break;
                case "l":
                    index = _letters[(int) Alphabet.L]._wordsArray.BinarySearch(word);
                    break;
                case "m":
                    index = _letters[(int) Alphabet.M]._wordsArray.BinarySearch(word);
                    break;
                case "n":
                    index = _letters[(int) Alphabet.N]._wordsArray.BinarySearch(word);
                    break;
                case "o":
                    index = _letters[(int) Alphabet.O]._wordsArray.BinarySearch(word);
                    break;
                case "p":
                    index = _letters[(int) Alphabet.P]._wordsArray.BinarySearch(word);
                    break;
                case "q":
                    index = _letters[(int) Alphabet.Q]._wordsArray.BinarySearch(word);
                    break;
                case "r":
                    index = _letters[(int) Alphabet.R]._wordsArray.BinarySearch(word);
                    break;
                case "s":
                    index = _letters[(int) Alphabet.S]._wordsArray.BinarySearch(word);
                    break;
                case "t":
                    index = _letters[(int) Alphabet.T]._wordsArray.BinarySearch(word);
                    break;
                case "u":
                    index = _letters[(int) Alphabet.U]._wordsArray.BinarySearch(word);
                    break;
                case "v":
                    index = _letters[(int) Alphabet.V]._wordsArray.BinarySearch(word);
                    break;
                case "w":
                    index = _letters[(int) Alphabet.W]._wordsArray.BinarySearch(word);
                    break;
                case "x":
                    index = _letters[(int) Alphabet.X]._wordsArray.BinarySearch(word);
                    break;
                case "y":
                    index = _letters[(int) Alphabet.Y]._wordsArray.BinarySearch(word);
                    break;
                case "z":
                    index = _letters[(int) Alphabet.Z]._wordsArray.BinarySearch(word);
                    break;

            }
            if (index != -1)
            {
                return true;
            }
            return false;
        }

        public void LoadInArray()
        {
            while (!_reader.EndOfStream)
            {
                string word = _reader.ReadLine();

                if (word != "")
                {
                    switch (word[0].ToString().ToLower())
                    {
                        case "a":
                            _letters[(int) Alphabet.A]._wordsArray.Add(word);
                            break;
                        case "b":
                            _letters[(int) Alphabet.B]._wordsArray.Add(word);
                            break;
                        case "c":
                            _letters[(int) Alphabet.C]._wordsArray.Add(word);
                            break;
                        case "d":
                            _letters[(int) Alphabet.D]._wordsArray.Add(word);
                            break;
                        case "e":
                            _letters[(int) Alphabet.E]._wordsArray.Add(word);
                            break;
                        case "f":
                            _letters[(int) Alphabet.F]._wordsArray.Add(word);
                            break;
                        case "g":
                            _letters[(int) Alphabet.G]._wordsArray.Add(word);
                            break;
                        case "h":
                            _letters[(int) Alphabet.H]._wordsArray.Add(word);
                            break;
                        case "i":
                            _letters[(int) Alphabet.I]._wordsArray.Add(word);
                            break;
                        case "j":
                            _letters[(int) Alphabet.J]._wordsArray.Add(word);
                            break;
                        case "k":
                            _letters[(int) Alphabet.K]._wordsArray.Add(word);
                            break;
                        case "l":
                            _letters[(int) Alphabet.L]._wordsArray.Add(word);
                            break;
                        case "m":
                            _letters[(int) Alphabet.M]._wordsArray.Add(word);
                            break;
                        case "n":
                            _letters[(int) Alphabet.N]._wordsArray.Add(word);
                            break;
                        case "o":
                            _letters[(int) Alphabet.O]._wordsArray.Add(word);
                            break;
                        case "p":
                            _letters[(int) Alphabet.P]._wordsArray.Add(word);
                            break;
                        case "q":
                            _letters[(int) Alphabet.Q]._wordsArray.Add(word);
                            break;
                        case "r":
                            _letters[(int) Alphabet.R]._wordsArray.Add(word);
                            break;
                        case "s":
                            _letters[(int) Alphabet.S]._wordsArray.Add(word);
                            break;
                        case "t":
                            _letters[(int) Alphabet.T]._wordsArray.Add(word);
                            break;
                        case "u":
                            _letters[(int) Alphabet.U]._wordsArray.Add(word);
                            break;
                        case "v":
                            _letters[(int) Alphabet.V]._wordsArray.Add(word);
                            break;
                        case "w":
                            _letters[(int) Alphabet.W]._wordsArray.Add(word);
                            break;
                        case "x":
                            _letters[(int) Alphabet.X]._wordsArray.Add(word);
                            break;
                        case "y":
                            _letters[(int) Alphabet.Y]._wordsArray.Add(word);
                            break;
                        case "z":
                            _letters[(int) Alphabet.Z]._wordsArray.Add(word);
                            break;

                    }
                }
            }

        }

    }
}
