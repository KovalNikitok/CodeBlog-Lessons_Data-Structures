using System;
using DataStructures.Models;

namespace DataStructures
{
    class Program
    {
        static void Main()
        {
            var list = new LinkedList<int>();
            var lStack = new LinkedStack<int>();

            for (int i = 0; i < 4; i++)
            {
                lStack.Push(5 * i);
                list.Add(i + 7);
            }
            list.AddFirst(25);
            list.AddAfter(13, 51);
            list.Delete(25);
            list.AddFirst(83);

            Console.WriteLine($"Stack has {lStack.Count} elements");
            foreach (var item in lStack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
