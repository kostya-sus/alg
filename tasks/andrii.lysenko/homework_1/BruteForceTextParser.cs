using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_spacing
{
    public class BruteForceTextParser : TextParser
    {
        private string[] _dictionary;

        public override void SetDictionary(string[] dictionary)
        {
            _dictionary = dictionary;
        }

        protected override List<string> GetValidPrefixesList(string textWithoutSpaces)
        {
            var validPrefixesList = new List<string>();
            for (int i = 1; i <= textWithoutSpaces.Length; i++)
            {
                string prefix = textWithoutSpaces.Substring(0, i);
                if (_dictionary.Contains(prefix))
                {
                    validPrefixesList.Add(prefix);
                }
            }
            return validPrefixesList;
        }
    }
}