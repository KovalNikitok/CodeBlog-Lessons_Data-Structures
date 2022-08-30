using System.Collections;
using System;


namespace DataStructures.Models.Structures
{
    class LinkedHashTable<T> : IEnumerable
    {
        private LinkedList<T>[] _hashArray;
        public LinkedHashTable(int size)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException("Set greater size to hash set.");
            _hashArray = new LinkedList<T>[size];
        }

        public void Add(T value)
        {
            var key = GetHash(value);
            if (_hashArray[key] == null)
            {
                _hashArray[key] = new LinkedList<T>(value);
                return;
            }
            _hashArray[key].Add(value);
        }

        public bool Search(T value)
        {
            var key = GetHash(value);
            if (_hashArray[key] == null)
                return false;
            return _hashArray[key].First(value);
        }

        private int GetHash(T value)
        {
            /* string sKey = value.ToString();
             int result = 0;
             for (int i = 0; i < sKey.Length; i++)
             {
                 if (Char.TryParse(sKey[i].ToString(), out char keyChar))
                     result += keyChar;
                 else
                     throw new FormatException("Invalid format of key.");
             }
             return result % _hashArray.Length;*/


            // For basic realization with overrided GetHashCode()
            var res = value.GetHashCode() % _hashArray.Length;
            return res < 0 ? -res : res;
        }

        public IEnumerator GetEnumerator()
        {
            if (_hashArray.Length <= 0)
                yield break;

            foreach (var item in _hashArray)
            {
                var current = item?.Head ?? null;
                while (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
        }
    }
}
