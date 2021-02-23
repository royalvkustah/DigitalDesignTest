using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml;

namespace DigitalDesignTest
{
    public static class WordSplitter
    {

        public static Dictionary<string,int> Execute(string path)
        {
            string line;
            Dictionary<string,int> wordsDict = new Dictionary<string, int>();
            using (StreamReader sr = new StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.StartsWith("<p>")&&line.EndsWith("</p>"))
                    {
                        line = line[3..^4];
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

        public static void AddWord(string word, Dictionary<string,int> dict)
        {
            if (dict.ContainsKey(word))
            {
                dict[word]++;
            }
            else
            {
                dict.Add(word,1);
            }
        }

        public static Dictionary<string, int> SortDictionary(Dictionary<string, int> dict)
        {
            dict = dict.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            return dict;
        }

        public static string ModifyWord(string word)
        {
            char[] CharsToTrim = { '.', ',', '!', '?', ':', '"', '-', ' ', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            
            while (word.Contains('<'))
            {
                int a = word.IndexOf('<');
                int b = word.IndexOf('>');
                word=word.Remove(a,b-a+1);
            }
            word = word.Trim(CharsToTrim);
            return word.ToLower();
        }
        public static Dictionary<string, int> RemoveSpaces(Dictionary<string, int> dict)
        {
            foreach (var item in dict)
            {
                if (item.Key== "" || item.Key==" "|| item.Key==null|| item.Key== " ")
                {
                    dict.Remove(item.Key);
                }
            }
            return dict;
        }
    }
}
