using System.Collections.Generic;

namespace DataStructures.Models.Items
{
    class TrieNode<T>
    {
        public char Symbol { get; set; }
        public T Data { get; set; }
        public bool IsWord { get; set; }
        public Dictionary<char, TrieNode<T>> SubNodes { get; set; }
        public string Prefix { get; set; }
        public TrieNode(char key, T data)
        {
            Symbol = key;
            Data = data;
            SubNodes = new Dictionary<char, TrieNode<T>>();
        }

        public TrieNode<T> TryFind(char symbol)
        {
            if (SubNodes.TryGetValue(symbol, out TrieNode<T> value))
                return value;
            else 
                return null;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
        public override bool Equals(object obj)
        {
            if (obj is TrieNode<T> item)
                return Data.Equals(item.Data);
            else 
                return false;
        }
        public override int GetHashCode()
        {
            return Symbol;
        }
    }
}
