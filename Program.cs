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
            var set = new Set<int>();
            var set1 = new Set<int>();
            var hashTable = new HashTable<string, int>(5);
            var linkedHashTable = new LinkedHashTable<int>(4);

            for (int i = 0; i < 3; i++)
            {
                lStack.Push(5 * i);
                list.Add(i + 7);
                biList.Add(i * 10);
                circList.Add(14 * i);
                queue.Enqeue(21 - i * 2);
                deqeue.PushBack(i + 13 * 3);
                deqeue.PushFront(i * 15);
                set.Add(i * 72);
                set1.Add(i * 36);
                hashTable.Add($"{i}elems", i * 999);
                linkedHashTable.Add(i * 150);
            }

            // Stack
            Console.WriteLine($"Stack has {lStack.Count} elements");
            foreach (var item in lStack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // Linked list
            list.AddFirst(25);
            list.AddAfter(13, 51);
            list.Delete(25);
            Console.WriteLine($"Linked list has {list.Count} elements");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // Bidirectional list
            biList.Delete(30);
            biList.Delete(0);
            biList.Reverse();
            Console.WriteLine($"Bidirectional list has {biList.Count} elements");
            foreach (var item in biList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // Circular list
            circList.Delete(28);
            Console.WriteLine($"Circular list has {circList.Count} elements");
            foreach (var item in circList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // Queue
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

            // Deqeue
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
            Console.WriteLine();


            // Set
            Console.WriteLine($"Set has {set.Count} elements");
            Console.Write($"Before changing:");
            foreach (var item in set)
            {
                Console.Write($" {item}");
            }
            Console.WriteLine();

            set = set.Union(set1);
            Console.WriteLine($"Now union set has {set.Count} elements");
            Console.Write($"After union:");
            foreach (var item in set)
            {
                Console.Write($" {item}");
            }
            Console.WriteLine();

            set = set.Intersection(set1);
            Console.WriteLine($"Now set by intersection has {set.Count} elements");
            Console.Write($"After intersection:");
            foreach (var item in set)
            {
                Console.Write($" {item}");
            }
            Console.WriteLine();

            Console.WriteLine($"Set has subset of 72? - {set.SubSet(new Set<int>(72))}");

            set.Add(511);
            set = set.SymmetricDifference(set1);
            Console.WriteLine($"Now set with symmetric difference has {set.Count} elements");
            Console.Write($"After symmetric difference:");
            foreach (var item in set)
            {
                Console.Write($" {item}");
            }
            Console.WriteLine();

            // Hash Table
            Console.WriteLine($"Hash table:\n(hash function calculate by element resolved to string and summary by chars code)");
            foreach (var item in hashTable)
            {
                Console.Write($" {item}");
            }
            Console.WriteLine();

            Console.WriteLine($"Is hash table has element '0'? - {hashTable.Search($"0", 0)}");
            Console.WriteLine($"Is hash table has element '999'? - {hashTable.Search($"1", 999)}");
            Console.WriteLine($"Is hash table has element '2314'? - {hashTable.Search($"2", 2314)}");

            Console.WriteLine();

            // Linked Hash Table
            Console.Write("Linked hash table have: ");
            foreach (var item in linkedHashTable)
            {
                Console.Write($" {item}");
            }
            Console.WriteLine();

            Console.WriteLine($"Linked hash tablse has 0? - {linkedHashTable.Search(0)}");
            Console.WriteLine($"Linked hash tablse has 150? - {linkedHashTable.Search(150)}");
            Console.WriteLine($"Linked hash tablse has 15? - {linkedHashTable.Search(15)}");
            Console.WriteLine();
        }
    }
}
