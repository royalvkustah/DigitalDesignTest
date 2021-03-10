using System;
using System.IO;
using System.Collections.Generic;
using DigitalDesignLibrary;
using System.Reflection;


namespace DigitalDesignTest
{
    class Program
    {
        public static string pathPrefix = @"..\..\..\Files\";
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, int>();
            var t = typeof(WordSplitter);
            var f = t.GetMethod("Execute", BindingFlags.NonPublic|BindingFlags.Static);
            dictionary = (Dictionary<string, int>)f.Invoke(null,new object[] { pathPrefix + "book13.fb2" });
            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Key+"__________"+item.Value);
            }
            using (StreamWriter sw = new StreamWriter(@"..\..\..\Files\words.txt", false))
            {
                foreach (var item in dictionary)
                {
                    sw.WriteLine(item.Key + "____________________" + item.Value);
                }
            }
        }
    }
}
