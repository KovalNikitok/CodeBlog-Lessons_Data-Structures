using DataStructures.Models.Items;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Models.Structures
{
    class BinaryTree<T> where T : IComparable<T>
    {
        public TreeRecursionItem<T> Root { get; private set; }

        public int Count { get; private set; }

        public BinaryTree()
        {
            Root = new TreeRecursionItem<T>();
            Count = 0;
        }

        public BinaryTree(T data)
        {
            Root = new TreeRecursionItem<T>(data);
            Count = 1;
        }

        /*public void Add(T data)
        {
            if (data == null)
                return;
            if (Count == 0)
            {
                Root.Data = data;
                Count++;
                return;
            }

            var current = Root;
            while (current != null)
            {
                if (data.CompareTo(current.Data) < 0)
                    current = current.Previous;
                else
                    current = current.Next;
            }
            current = new BidirectionalItem<T>(data);
            Count++;
        }*/

        public void Add(T data)
        {
            if (Count == 0)
            {
                Root.Data = data;
                Count = 1;
                return;
            }
            if (Root.Add(data))
                Count++;
        }

        public List<T> Preorder()
        {
            var itemsList = new List<T>(Count);
            PreorderRecursion(Root, itemsList);
            return itemsList;
        }

        private void PreorderRecursion(TreeRecursionItem<T> item, List<T> itemsArray)
        {
            if (item == null)
                return;
            itemsArray.Add(item.Data);

            if (item.Left != null)
                PreorderRecursion(item.Left, itemsArray);
            if (item.Right != null)
                PreorderRecursion(item.Right, itemsArray);
        }


        // TODO: Copy(prefix), DeleteAll(postfix), Sort(infix)

        public IEnumerator GetEnumerator()
        {
            if (Count <= 0)
                yield break;

            var itemsList = Preorder();
            foreach (var item in itemsList)
            {
                if (item != null)
                    yield return item;
            }
        }
    }
}
