using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace DigitalDesignLibrary
{
    public static class WordSplitter
    {
        private static Dictionary<string, int> Execute(string path)
        {
            string line;
            Dictionary<string, int> wordsDict = new Dictionary<string, int>();
            using (StreamReader sr = new StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.StartsWith("<p>") && line.EndsWith("</p>"))
                    {
                        line = line.Substring(3, line.Length - 7);
                        string[] words = line.Split(' ');
                        foreach (var item in words)
                        {
                            AddWord(ModifyWord(item), wordsDict);
                        }
                    }
                }
            }
            RemoveSpaces(wordsDict);
            return SortDictionary(wordsDict);
        }
        private static void AddWord(string word, Dictionary<string, int> dict)
        {
            if (dict.ContainsKey(word))
            {
                dict[word]++;
            }
            else
            {
                dict.Add(word, 1);
            }
        }
        private static Dictionary<string, int> SortDictionary(Dictionary<string, int> dict)
        {
            dict = dict.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            return dict;
        }
        private static string ModifyWord(string word)
        {
            char[] CharsToTrim = { '.', ',', '!', '?', ':', '"', '-', ' ', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            while (word.Contains('<'))
            {
                int a = word.IndexOf('<');
                int b = word.IndexOf('>');
                word = word.Remove(a, b - a + 1);
            }
            word = word.Trim(CharsToTrim);
            return word.ToLower();
        }
        private static Dictionary<string, int> RemoveSpaces(Dictionary<string, int> dict)
        {
            foreach (var item in dict)
            {
                if (item.Key == "" || item.Key == " " || item.Key == null || item.Key == " ")
                {
                    dict.Remove(item.Key);
                }
            }
            return dict;
        }
    }
}