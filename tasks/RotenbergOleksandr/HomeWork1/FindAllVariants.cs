using System;
using System.Collections.Generic;

namespace SplitTheString
{
    public class FindAllVariants
    {
        public List<String> FindSeparateWords(string inputString, HashSet<string> dictionary)
        {
            var solution = string.Empty;
            List<string> result = new List<string>();
            if (string.IsNullOrEmpty(inputString))
            {
                return result;
            }
            List<string>[] arr = new List<string>[inputString.Length + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new List<string>();
            }

            for (int i = 1; i <= inputString.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    var substr = inputString.Substring(j, i - j);
                    if (dictionary.Contains(substr))
                    {
                        arr[i].Add(substr);
                    }
                }
            }

            AddAllVariants(arr, inputString.Length, result, solution);

            return result;
        }

        private void AddAllVariants(List<string>[] dp, int index, List<string> res, string solution)
        {
            if (index == 0)
            {
                solution = solution.Substring(0, solution.Length - 1);
                res.Add(solution);
                return;
            }

            foreach (var list in dp[index])
            {
                solution = list + " " + solution;
                AddAllVariants(dp, index - list.Length, res, solution);
                solution = solution.Substring(list.Length + 1);
            }
        }
    }
}