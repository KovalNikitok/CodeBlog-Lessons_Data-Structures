using System.Collections.Generic;
using System.Collections;
using System;

namespace DataStructures.Models.Structures
{
    class Queue<T> : IEnumerable
    {
        private System.Collections.Generic.List<T> _queue;
        private T Head => _queue[Count - 1];
        private T Tail => _queue[0];
        public int Count => _queue.Count;
        public Queue()
        {
            _queue = new System.Collections.Generic.List<T>();
        }
        public Queue(T data) : this()
        {
            _queue.Add(data);
        }

        public void Enqeue(T data)
        {
            _queue.Insert(0, data);
        }

        public T Deqeue()
        {
            if (Count <= 0)
                throw new NullReferenceException("Queue have not elements.");
            var item = Head;
            _queue.RemoveAt(Count - 1);
            return item;
        }
        public T Peek()
        {
            if (Count <= 0)
                throw new NullReferenceException("Queue have not elements.");
            return Head;
        }

        public T PeekBack()
        {
            if (Count <= 0)
                throw new NullReferenceException("Queue have not elements.");
            return Tail;
        }

        public IEnumerator GetEnumerator()
        {
            if (Count <= 0)
                yield break;

            for(int i = Count; i > 0; i--)
            {
                yield return _queue[i - 1];
            }
        }
    }
}
