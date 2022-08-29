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
            var biList = new BidirectionalList<int>();
            var circList = new CircularList<int>();
            var queue = new Queue<int>();

            for (int i = 0; i < 5; i++)
            {
                lStack.Push(5 * i);
                list.Add(i + 7);
                biList.Add(i * 10);
                circList.Add(14 * i);
                queue.Enqeue(21 - i * 2);
            }
            

            Console.WriteLine($"Stack has {lStack.Count} elements");
            foreach (var item in lStack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            list.AddFirst(25);
            list.AddAfter(13, 51);
            list.Delete(25);
            Console.WriteLine($"Linked list has {list.Count} elements");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
           
            biList.Delete(30);
            biList.Delete(0);
            biList.Reverse();
            Console.WriteLine($"Bidirectional list has {biList.Count} elements");
            foreach (var item in biList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            circList.Delete(28);
            Console.WriteLine($"Circular list has {circList.Count} elements");
            foreach (var item in circList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            
            Console.WriteLine($"Queue has {queue.Count} elements");
            Console.WriteLine(queue.PeekBack());
            Console.WriteLine();
            Console.WriteLine(queue.Peek());
            Console.WriteLine();
            Console.WriteLine(queue.Deqeue());
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
