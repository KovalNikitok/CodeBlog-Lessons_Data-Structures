using DataStructures.Models.Items;
using System;
using System.Collections;

namespace DataStructures.Models.Structures
{
    class Deqeue<T> : IEnumerable
    {
        private BidirectionalList<T> _deqeue;
        public BidirectionalItem<T> Head
        {
            get
            {
                return _deqeue.Head;
            }
            private set
            {
                _deqeue.Head = value;
            }
        }
        public BidirectionalItem<T> Tail
        {
            get
            {
                return _deqeue.Tail;
            }
            private set
            {
                _deqeue.Tail = value;
            }
        }
        public int Count
        {
            get
            {
                return _deqeue.Count;
            }
            private set
            {
                _deqeue.Count = value;
            }
        }

        public Deqeue()
        {
            _deqeue = new BidirectionalList<T>();
        }
        public Deqeue(T data)
        {
            _deqeue.SetFirstItem(data);
        }

        public void PushFront(T data)
        {
            if (Count <= 0)
            {
                _deqeue.SetFirstItem(data);
                return;
            }

            _deqeue.Add(data);
        }
        public void PushBack(T data)
        {
            if (Count <= 0)
            {
                _deqeue.SetFirstItem(data);
                return;
            }
            _deqeue.AddFirst(data);
        }

        public T PeakFront()
        {
            if (Count <= 0 || Tail == null)
            {
                throw new NullReferenceException("Deqeue is null or empty.");
            }
            return Tail.Data;
        }
        public T PeakBack()
        {
            if (Count <= 0 || Head == null)
            {
                throw new NullReferenceException("Deqeue is null or empty.");
            }
            return Head.Data;
        }

        public T PopFront()
        {
            if (Count <= 0 || Tail == null)
            {
                throw new NullReferenceException("Deqeue is null or empty.");
            }
            if (Tail.Previous != null)
                Tail.Previous.Next = Tail.Next;
            if (Tail.Next != null)
                Tail.Next.Previous = Tail.Previous;
            Count--;

            var current = Tail.Data;
            Tail = Tail.Next;
            return current;
        }

        public T PopBack()
        {
            if (Count <= 0 || Head == null)
            {
                throw new NullReferenceException("Deqeue is null or empty.");
            }
            if (Head.Next != null)
                Head.Next.Previous = Head.Previous;
            if (Head.Previous != null)
                Head.Previous.Next = Head.Next;
            Count--;

            var current = Head.Data;
            Head = Head.Next;
            return current;
        }

        public IEnumerator GetEnumerator()
        {
            if (Count <= 0)
                yield break;

            var current = Head;
            while(current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
