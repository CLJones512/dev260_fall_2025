using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Week2Foundations
{
    public class Benchmark
    {   
        public static void MiniBenchmark(int n)
        {
            var list = new List<int>();
            var hs = new HashSet<int>();
            var dict = new Dictionary<int, bool>();

            for (int i = 0; i < n; i++)
            {
                list.Add(i);
                hs.Add(i);
                dict[i] = true;
            }

            var sw = Stopwatch.StartNew();
            bool listContains = list.Contains(n - 1);
            sw.Stop();
            Console.WriteLine($"List.Contains: {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            bool hsContains = hs.Contains(n - 1);
            sw.Stop();
            Console.WriteLine($"HashSet.Contains: {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            bool dictContains = dict.ContainsKey(n - 1);
            sw.Stop();
            Console.WriteLine($"Dict.ContainsKey: {sw.ElapsedMilliseconds} ms");

            sw .Restart();
            bool listContainsInvalid = list.Contains(-1);
            sw.Stop();
            Console.WriteLine($"List.Contains(-1): {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            bool hsContainsInvalid = hs.Contains(-1);
            sw.Stop();
            Console.WriteLine($"HashSet.Contains(-1): {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            bool dictContainsInvalid = dict.ContainsKey(-1);
            sw.Stop();
            Console.WriteLine($"Dict.ContainsKey(-1): {sw.ElapsedMilliseconds} ms");
        }
    }
}