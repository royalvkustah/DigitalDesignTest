using System;
using System.IO;
using System.Collections.Generic;
using DigitalDesignLibrary;
using System.Reflection;
using System.Diagnostics;
using System.Threading;


namespace DigitalDesignTest
{
    class Program
    {
        public static string pathPrefix = @"..\..\..\Files\";
        static void Main(string[] args)
        {
            Stopwatch swatch = new Stopwatch();
            swatch.Start();
            string line;
            string text="";
            using (StreamReader sr = new StreamReader(pathPrefix + "book13.fb2"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.StartsWith("<p>") && line.EndsWith("</p>"))
                    {
                        line = line.Substring(3, line.Length - 7);
                        text += line;
                    }
                }
            }
            var dictionary = new Dictionary<string, int>();
            var t = typeof(WordSplitter);
            var f = t.GetMethod("Execute", BindingFlags.NonPublic|BindingFlags.Static);
 //           dictionary = (Dictionary<string, int>)f.Invoke(null,new object[] { text });
            dictionary = WordSplitter.ExecutePrarllel(text);

            using (StreamWriter sw = new StreamWriter(@"..\..\..\Files\words.txt", false))
            {
                foreach (var item in dictionary)
                {
                    sw.WriteLine(item.Key + "____________________" + item.Value);
                }
            }
            Console.WriteLine(swatch.ElapsedMilliseconds);
                              foreach (var item in dictionary)
                          {
                          Console.WriteLine(item.Key+"__________"+item.Value);
                  }
            Console.WriteLine("_______________________________________________________________________");
 //           foreach (var item in Parameter.dicts)
   //         {
     //           Console.WriteLine(item.Key + "__________" + item.Value);
       //     }
        }
    }
}
