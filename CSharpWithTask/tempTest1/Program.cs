using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace tempTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var ga = new List<int> { 3, 4, 5, 6 };
            var gb = new List<string> { "apple", "banana", "candle", "dog"};

            var dict = from a in ga
                       join b in gb on ga.IndexOf(a) equals gb.IndexOf(b)
                       select new { key = a, value = b };

            foreach(var i in dict)
            {
                Console.WriteLine(i);
            }
        }
    }
}
