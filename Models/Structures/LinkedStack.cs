using System;
using System.Collections;

namespace DataStructures.Models.Structures
{
    class LinkedStack<T> : IEnumerable
    {
        private LinkedList<T> _linkedList = new LinkedList<T>();
        public int Count => _linkedList.Count;

        public void Push(T data)
        {
            if (data == null)
                throw new NullReferenceException("Данные ни на что не сссылаются.");
            _linkedList.AddFirst(data);
        }
        public T Pop()
        {
            if (_linkedList.Count <= 0)
                throw new NullReferenceException("Стэк пуст.");
            var data = _linkedList.Head.Data;
            _linkedList.Delete(data);
            return data;
        }
        public T Peek()
        {
            if (_linkedList.Count <= 0)
                throw new NullReferenceException("Стэк пуст.");
            return _linkedList.Head.Data;
        }

        public IEnumerator GetEnumerator()
        {
            if (Count < 0)
                yield break;
            while (Count > 0)
            {
                yield return Pop();
            }
        }
    }
}
