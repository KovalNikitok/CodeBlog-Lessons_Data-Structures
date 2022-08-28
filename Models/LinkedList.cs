using System.Collections;

namespace DataStructures.Models
{
    class LinkedList<T> : IEnumerable
    {
        public Item<T> Head { get; private set; }
        public Item<T> Tail { get; private set; }
        public int Count { get; set; }

        public LinkedList()
        {
            Count = 0;
        }
        public LinkedList(T data)
        {
            SetFirstItem(data);
        }

        public void Add(T data)
        {
            if (Head == null)
            {
                SetFirstItem(data);
                return;
            }

            var current = Head;
            do
            {
                if (current.Next == null)
                {
                    var newItem = new Item<T>(data);
                    current.Next = newItem;
                    Tail = newItem;
                    Count++;
                    return;
                }
                current = current.Next;
            }
            while (current != null);
        }

        public void Delete(T data)
        {
            if (Head == null)
                return;
            if (Head.Data.Equals(data))
            {
                Head = Head.Next;
                if (Count == 1)
                    Tail = Head;
                Count--;
                return;
            }

            var previous = Head;
            var current = Head.Next;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    previous.Next = current.Next;
                    if (current.Next == null)
                        Tail = previous;
                    Count--;
                    return;
                }
                previous = current;
                current = current.Next;
            }
        }

        public void Delete(Item<T> item)
        {
            if (Head == null)
                return;
            if (Head.Equals(item))
            {
                Head = Head.Next;
                if (Count == 1)
                    Tail = Head;
                Count--;
                return;
            }

            var previous = Head;
            var current = Head.Next;

            while (current != null)
            {
                if (current.Equals(item))
                {
                    previous.Next = current.Next;
                    if (current.Next == null)
                        Tail = previous;
                    Count--;
                    return;
                }
                previous = current;
                current = current.Next;
            }
        }

        public void AddFirst(T data)
        {
            if (Head == null)
            {
                SetFirstItem(data);
                return;
            }
            
            var newItem = new Item<T>(data);
            newItem.Next = Head;
            Head = newItem;
            Count++;
        }

        public void AddAfter(T targetData, T data)
        {
            if (Head == null)
                return;

            var current = Head;
            do
            {
                if(current.Data.Equals(targetData))
                {
                    var newItem = new Item<T>(data);
                    newItem.Next = current.Next;
                    current.Next = newItem;
                    Count++;
                    return;
                }
                current = current.Next;
            } 
            while (current != null);

        }

        private void SetFirstItem(T data)
        {
            var newItem = new Item<T>(data);
            Head = newItem;
            Tail = newItem;
            Count = 1;
        }

        public IEnumerator GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
