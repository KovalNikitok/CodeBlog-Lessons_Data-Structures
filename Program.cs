using System;
using DataStructures.Models.Structures;

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
            var deqeue = new Deqeue<int>();

            for (int i = 0; i < 3; i++)
            {
                lStack.Push(5 * i);
                list.Add(i + 7);
                biList.Add(i * 10);
                circList.Add(14 * i);
                queue.Enqeue(21 - i * 2);
                deqeue.PushBack(i + 13 * 3);
                deqeue.PushFront(i * 15);
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

            
            Console.WriteLine($"Deqeue has {deqeue.Count} elements");
            Console.Write($"Before changing:");
            foreach (var item in deqeue)
            {
                Console.Write($" {item}");
            }
            Console.WriteLine();

            deqeue.PeakFront();
            deqeue.PopBack();
            deqeue.PopBack();
            deqeue.PopFront();
            Console.WriteLine($"Now deqeue has {deqeue.Count} elements");
            Console.Write($"After changing:");
            foreach (var item in deqeue)
            {
                Console.Write($" {item}");
            }
            Console.WriteLine();
        }
    }
}
