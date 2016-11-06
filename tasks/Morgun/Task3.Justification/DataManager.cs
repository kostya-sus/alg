using System.Collections.Generic;
using System.IO;

namespace TextJustification
{
    public static class DataManager
    {

        public static string ReadLinesFromFile(string path, string defaultValue = "")
        {
            var inputText = string.Empty;

            if (!File.Exists(path))
            {
                return inputText;
            }

            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {

                    string readLine = streamReader.ReadLine();

                    while (readLine != null)
                    {
                        inputText += readLine.Replace("\n"," ") + " ";
                        readLine = streamReader.ReadLine();
                    }
                }
            }
            return inputText;
        }

        public static void WriteOutput(List<string> strings, string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    for (int i = 0; i < strings.Count; i++)
                    {
                        streamWriter.WriteLine(strings[i]);
                    }
                }
            }
        }
    }
}
