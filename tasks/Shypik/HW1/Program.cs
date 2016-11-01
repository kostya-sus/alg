using System;
using System.IO;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;

namespace WordsStd {
    class Program {
        static void Main(string[] args) {
            const string filename = "dict_en.txt";
            string phrase = "catsanddogs";
            HashSet<string> dictionary = ReadDictFromFile(filename, phrase);

            List<string> segmentationsNaive = new List<string>();
            textSegmentationNaive(segmentationsNaive, phrase, dictionary);

            List<string>[] segmentationsArray = new List<string>[phrase.Length];
            for (int i = 0; i < phrase.Length; i++) {
                segmentationsArray[i] = new List<string>();
            }
            textSegmentation(segmentationsArray, phrase, 0, dictionary);
            List<string> segmentations = segmentationsArray[0];

            var segArray1 = segmentationsNaive.ToArray();
            var segArray2 = segmentations.ToArray();
            for (int i = 0; i < segArray1.Length; i++) {
                if (segArray1[i].Trim() != segArray2[i].Trim()) {
                    Console.WriteLine("Not equal results for {0}", i);
                    return;
                }
                Console.WriteLine(segArray2[i]);
            }

            Console.WriteLine("Variants num: {0}", segArray1.Length);
            Console.WriteLine("Naive method called: {0}", countSegmentationNaive);
            Console.WriteLine("Dp method called: {0}", countSegmentation);

            Console.ReadLine();
        }

        static int countSegmentationNaive = 0;
        static void textSegmentationNaive(List<string> split, string text, HashSet<string> dict, string prevPrefix = "") {
            countSegmentationNaive++;
            if (dict.Contains(text)) {
                split.Add(prevPrefix + " " + text);
            }
            for (int i = 1; i < text.Length; i++) {
                string prefix = text.Substring(0, i);
                if (dict.Contains(prefix)) {
                    string suffix = text.Substring(i);
                    textSegmentationNaive(split, suffix, dict, prevPrefix + " " + prefix);
                }
            }
        }

        static int countSegmentation = 0;
        static List<string> textSegmentation(List<string>[] splits, string text, int j, HashSet<string> dict) {
            if (splits[j].Count != 0) {
                return splits[j];
            }
            countSegmentation++;
            string textEnd = text.Substring(j);
            if (dict.Contains(textEnd)) {
                splits[j].Add(textEnd);
            }
            for (int i = 1; i < textEnd.Length; i++) {
                string prefix = textEnd.Substring(0, i);
                if (dict.Contains(prefix)) {
                    //string suffix = textEnd.Substring(i + j);
                    List<string> suffixSplit = textSegmentation(splits, text, i + j, dict);
                    foreach (var item in suffixSplit) {
                        splits[j].Add(prefix + " " + item);
                    }
                }
            }
            return splits[j];
        }

        static HashSet<string> ReadDictFromFile(string filename, string phrase) {
            HashSet<string> dictionary = new HashSet<string>();

            StreamReader file =
               new System.IO.StreamReader(filename);
            string line;
            while ((line = file.ReadLine()) != null) {
                if (phrase.Contains(line.Trim())) {
                    if (line.Trim() != "") dictionary.Add(line.Trim());
                }
            }
            Console.WriteLine("Ended reading from file");
            file.Close();
            return dictionary;
        }

    }
}
