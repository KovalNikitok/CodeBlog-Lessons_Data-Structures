using DataStructures.Models.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Models.Structures
{
    class Set<T> : ILists<T>, IEnumerable
    {
        public System.Collections.Generic.List<T> items = new System.Collections.Generic.List<T>();
        public int Count => items.Count;

        public Set() { }

        public Set(T data)
        {
            items.Add(data);
        }

        public void Add(T data)
        {
            foreach (var item in items)
            {
                if (item.Equals(data))
                    return;
            }
            items.Add(data);
        }

        public void Delete(T data)
        {
            items.Remove(data);
        }

        public Set<T> Union(Set<T> set)
        {
            var result = new Set<T>();
            foreach (var item in items)
            {
                result.Add(item);
            }
            if(set.Count <= 0)
                return result;

            for (int i = 0; i < set.Count; i++)
            {
                if (!items.Contains(set.items[i]))
                    result.Add(set.items[i]);
            }
            return result;
        }

        public Set<T> Intersection(Set<T> set)
        {
            var result = new Set<T>();
            if (set == null)
                return result;

            foreach (var item in items)
            {
                if (set.items.Contains(item))
                    result.Add(item);
            }
            return result;
        }

        public Set<T> Difference(Set<T> set)
        {
            if (set == null)
                return this;

            foreach (var item in items)
            {
                if (set.items.Contains(item))
                    Delete(item);
            }
            return this;
        }

        public bool SubSet(Set<T> set)
        {
            if (set == null)
                return true;
            foreach (var item in set.items)
            {
                if (!items.Contains(item))
                    return false;
            }
            return true;
        }

        public Set<T> SymmetricDifference(Set<T> set)
        {
            var result = new Set<T>();
            if (set == null)
                return this;

            foreach (var item in items)
            {
                if (!set.items.Contains(item))
                    result.Add(item);
            }
            return result;
        }

        public IEnumerator GetEnumerator()
        {
            if (Count <= 0)
                yield break;

            foreach (var item in items)
            {
                yield return item;
            }
        }

        
    }
}
