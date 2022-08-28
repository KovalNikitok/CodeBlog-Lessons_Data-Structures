using DataStructures.Models.Interfaces;
using DataStructures.Models.Items;
using System.Collections;
using System;


namespace DataStructures.Models
{
    class BidirectionalList<T> : ILists<T>, IEnumerable
    {
        public BidirectionalItem<T> Head { get; set; }
        public BidirectionalItem<T> Tail { get; set; }
        public int Count { get; private set; }
        

        public BidirectionalList() { }
        public BidirectionalList(T data)
        {
            SetFirstItem(data);
        }

        public void Add(T data)
        {
            if (Count == 0)
            {
                SetFirstItem(data);
                return;
            } 

            var newItem = new BidirectionalItem<T>(data);
            newItem.Previous = Tail;
            Tail.Next = newItem;
            Tail = newItem;
            Count++;
        }

        public void Delete(T data)
        {
            if (Count == 0)
                return;
            
            if(Head.Data.Equals(data))
            {
                if(Head.Next != null)
                    Head.Next.Previous = Head.Previous;
                Head = Head.Next;
                Count--;
                return;
            }
            
            var current = Head.Next;
            while (current != null)
            {
                if(current.Data.Equals(data))
                {
                    if(current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                    } 
                    if(current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }
                    current.Previous = null;
                    Count--;
                    return;
                }
                current = current.Next;
            }
        }

        public void Reverse()
        {
            if (Count == 0)
                return;
            var head = Head;
            var tail = Tail;
            T data;
            for(int i = 0, length = Count / 2; i < length; i++)
            {
                data = head.Data;
                head.Data = tail.Data;
                tail.Data = data;

                head = head.Next;
                tail = tail.Previous;
            }
        }

        public void SetFirstItem(T data)
        {
            var newItem = new BidirectionalItem<T>(data);
            Head = newItem;
            Tail = newItem;
            Count = 1;
        }
        public IEnumerator GetEnumerator()
        {
            if (Count == 0)
                yield break;
            var current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
