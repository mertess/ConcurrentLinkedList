using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ConcurrentLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            BlockingCollection<int> block = new BlockingCollection<int>();
            LinkedList<int> linked = new LinkedList<int>();
        }
    }
}
