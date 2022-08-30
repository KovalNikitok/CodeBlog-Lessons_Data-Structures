using System.Collections;
using System;
using System.Collections.Generic;
using DataStructures.Models.Interfaces;

namespace DataStructures.Models.Structures
{
    public class HashTable<TKey, TValue> : IPairLists<TKey, TValue>, IEnumerable
    {
        private List<TValue>[] _hashArray;
        public HashTable(int size)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException("Set greater size to hash set.");
            _hashArray = new List<TValue>[size];
        }

        public void Add(TKey key, TValue value)
        {
            var thisKey = GetHash(key);
            if (_hashArray[thisKey] == null)
                _hashArray[thisKey] = new List<TValue>();
            _hashArray[thisKey].Add(value);
        }

        public void Delete(TKey key)
        {
            var hash = GetHash(key);
            if (_hashArray[hash] == null)
                return;
            _hashArray[hash].RemoveAt(hash);
        }

        public bool Search(TKey key, TValue value)
        {
            return _hashArray[GetHash(key)]?.Contains(value) ?? false;
        }

        private int GetHash(TKey key)
        {
            string sKey = key.ToString();
            int result = 0;
            for(int i = 0; i < sKey.Length; i++)
            {
                if (Char.TryParse(sKey[i].ToString(), out char keyChar))
                    result += keyChar;
                else
                    throw new FormatException("Invalid format of key.");
            }
            return result % _hashArray.Length; 
        }

        public IEnumerator GetEnumerator()
        {
            if (_hashArray.Length <= 0)
                yield break;

            foreach (var item in _hashArray)
            {
                if (item != null)
                {
                    foreach (var elem in item)
                    {

                        yield return elem;
                    }
                }
            }
        }
    }
}
