using DataStructures.Models.Items;
using System.Collections;

namespace DataStructures.Models.Structures
{
    class Dictionary<TKey, TValue> : IEnumerable
    {
        private KeyValueItem<TKey, TValue>[] items;
        public Dictionary(int size)
        {
            items = new KeyValueItem<TKey, TValue>[size];
        }

        public void Add(TKey key, TValue value)
        {
            if (key == null)
                return;
            for (int i = GetHash(key); i < items.Length; i++)
            {
                if (items[i] == null)
                {
                    items[i] = new KeyValueItem<TKey, TValue>(key, value);
                    return;
                }
                if (items[i].Key.Equals(key))
                    return;
            }
        }

        public void Remove(TKey key)
        {
            if (key == null)
                return;
            for (int i = GetHash(key); i < items.Length; i++)
            {
                if (items[i] == null)
                    continue;
                if (items[i].Key.Equals(key))
                {
                    items[i] = null;
                    return;
                }
            }
        }

        public TValue Search(TKey key)
        {
            if (key == null)
                return default(TValue);
            for (int i = GetHash(key); i < items.Length; i++)
            {
                if (items[i] == null)
                    continue;
                if (items[i].Key.Equals(key))
                {
                    return items[i].Value;
                }
            }
            return default(TValue);
        }

        private int GetHash(TKey key)
        {
            var res = key.GetHashCode() % items.Length;
            return  res < 0 ? -res : res;
        }
        public IEnumerator GetEnumerator()
        {
            if (items.Length <= 0)
                yield break;
            foreach (var item in items)
            {
                if (item != null)
                    yield return item.Value;
            }
        }
    }
}
