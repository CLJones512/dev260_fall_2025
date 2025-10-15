using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Week2Foundations
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayTask();
            ListTask();
            StackTask();
            QueueTask();
            DictionaryTask();
            HashSetTask();

            Console.WriteLine("======Benchmark======");
            Console.WriteLine("N = 1000:");
            Benchmark.MiniBenchmark(1000);
            Console.WriteLine("\n N = 10,000");
            Benchmark.MiniBenchmark(10000);
            Console.WriteLine("\n N = 100,000");
            Benchmark.MiniBenchmark(100000);
            Console.WriteLine("\n N = 250,000");
            Benchmark.MiniBenchmark(250000);
            //Console.WriteLine("\n N = 100,000,000");
            //Benchmark.MiniBenchmark(100000000);
        }

        static void ArrayTask()
        {
            Console.WriteLine("======Array======");
            int[] intArray = new int[10];
            intArray[0] = 10;
            intArray[1] = 20;
            intArray[2] = 30;

            Console.WriteLine($"Index 2 is {intArray[2]}");

            for (int i = 0; i < intArray.Length; i++)
            {
                if (intArray[i] == 30)
                {
                    Console.WriteLine($"The number 30 was found at index {i}");
                }
            }
        }

        static void ListTask()
        {
            Console.WriteLine("======List======");

            var IntList = new List<int> { 1, 2, 3, 4, 5 };
            IntList.Insert(2, 99);
            IntList.Remove(99);
            Console.WriteLine($"Current count is {IntList.Count}");
        }

        static void StackTask()
        {
            Console.WriteLine("======Stack======");
            var urlStack = new Stack<string>();
            urlStack.Push("https://www.google.com/");
            urlStack.Push("https://github.com/");
            urlStack.Push("https://www.codecademy.com/");

            Console.WriteLine($"The current URL is {urlStack.Peek()}");

            while (urlStack.Count > 0)
            {
                Console.WriteLine($"{urlStack.Pop()}");
            }
        }

        static void QueueTask()
        {
            Console.WriteLine("======Queue======");
            var printQueue = new Queue<string>();
            printQueue.Enqueue("MeetingNotes.docx");
            printQueue.Enqueue("ProjectDocumentation.docx");
            printQueue.Enqueue("Timesheet.docx");

            Console.WriteLine($"Next Print Job {printQueue.Peek()}");

            while (printQueue.Count < 0)
            {
                Console.WriteLine(printQueue.Dequeue());
            }
        }

        static void DictionaryTask()
        {
            Console.WriteLine("======Dictionary======");
            var quantityDictionary = new Dictionary<string, int>
            {
                ["SKU-123"] = 40,
                ["SKU-456"] = 50,
                ["SKU-789"] = 60
            };

            quantityDictionary["SKU-456"] += 70;
            if (quantityDictionary.TryGetValue("SKU-012", out var qty))
            {
                Console.WriteLine(qty);
            }
            else
            {
                Console.WriteLine("SKU-012 Not Found");
            }
        }
        
        static void HashSetTask()
        {
            Console.WriteLine("======Hashes======");
            var hs = new HashSet<int> { 1, 2, 3 };
            hs.Add(2);
            Console.WriteLine("HashSet with a duplicate 2");
            var hs2 = new HashSet<int> { 3, 4, 5 };

            foreach (int i in hs)
            {
                Console.Write($"{i}, ");
            }

            hs.UnionWith(hs2);
            Console.WriteLine($"Number of values: {hs.Count}");
        }
    }
}
