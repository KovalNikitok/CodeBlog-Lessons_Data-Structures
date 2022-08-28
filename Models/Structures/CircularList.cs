using DataStructures.Models.Interfaces;
using DataStructures.Models.Items;
using System.Collections;

namespace DataStructures.Models
{
    class CircularList<T> : ILists<T>, IEnumerable
    {
        public BidirectionalItem<T> Head { get; set; }
        public int Count { get; set; }
        public CircularList() { }
        public CircularList(T data)
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
            newItem.Next = Head;
            newItem.Previous = Head.Previous;
            if (Head.Previous != null)
                Head.Previous.Next = newItem;
            Head.Previous = newItem;
            Count++;
        }

        public void Delete(T data)
        {
            if (Count == 0)
                return;

            var current = Head;

            if (current.Data.Equals(data))
            {
                RemoveItem(current);
                Head = current.Next;
                return;
            }

            do
            {
                if (current.Data.Equals(data))
                {
                    RemoveItem(current);
                    return;
                }
                current = current.Next;
            }
            while (current != Head);
        }

        private void RemoveItem(BidirectionalItem<T> item)
        {
            item.Previous.Next = item.Next;
            item.Next.Previous = item.Previous;
            Count--;
        }

        public void SetFirstItem(T data)
        {
            var newItem = new BidirectionalItem<T>(data);
            Head = newItem;
            Head.Previous = newItem;
            Head.Next = newItem;
            Count = 1;
        }

        public IEnumerator GetEnumerator()
        {
            if (Count == 0)
                yield break;
            var current = Head;
            do
            {
                yield return current.Data;
                current = current.Next;
            }
            while (current != Head);
        }
    }
}
