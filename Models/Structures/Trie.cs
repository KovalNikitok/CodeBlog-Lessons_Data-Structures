using DataStructures.Models.Items;
using System;

namespace DataStructures.Models.Structures
{
    class Trie<T>
    {
        private TrieNode<T> _root;
        public int Count { get; set; }

        public Trie()
        {
            _root = new TrieNode<T>('\0', default(T));
            Count = 0;
        }
        public Trie(T data)
        {
            _root = new TrieNode<T>('\0', data);
            Count = 1;
        }

        public void Add(string key, T data) => AddNode(key, ref data, _root);
        public void Delete(string key) => DeleteNode(key, _root);
        public T Search(string key) => SearchNode(key, _root);

        private void AddNode(string key, ref T Data, TrieNode<T> node)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                if (node.IsWord)
                    return;
                node.Data = Data;
                node.IsWord = true;
                Count++;
                return;
            }

            var subNode = node.TryFind(key[0]);
            if (subNode != null)
            {
                AddNode(key[1..], ref Data, subNode);
                return;
            }

            subNode = new TrieNode<T>(key[0], Data);
            if (node.SubNodes.TryAdd(key[0], subNode))
            {
                AddNode(key[1..], ref Data, subNode);
            }
            else
                throw new ArgumentException("Can not add element to sub nodes dictionary.");

            return;
        }

        private void DeleteNode(string key, TrieNode<T> node)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                if (!node.IsWord)
                    return;
                node.IsWord = false;
                node.Data = default(T);
                Count--;
                return;
            }

            var subNode = node.TryFind(key[0]);
            if (subNode != null)
            {
                DeleteNode(key[1..], subNode);
                return;
            }
        }

        private T SearchNode(string key, TrieNode<T> node)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                if (node.IsWord)
                    return node.Data;

                return default;
            }

            var subNode = node.TryFind(key[0]);
            if (subNode != null)
            {
                return SearchNode(key[1..], subNode);
            }
            return default;
        }
    }
}
