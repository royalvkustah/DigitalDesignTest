using System;
using System.IO;
using System.Collections.Generic;

namespace DigitalDesignTest
{
    class Program
    {

        public static string pathPrefix = @"..\..\..\Files\";
        static void Main(string[] args)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            dictionary = WordSplitter.Execute(pathPrefix+"book1.fb2");
            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Key+"__________"+item.Value);
            }
            FileWriter.WriteFile(dictionary);
        }
    }
}
