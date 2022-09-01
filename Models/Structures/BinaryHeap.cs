using System.Collections;
namespace DataStructures.Models.Structures
{
    class BinaryHeap : IEnumerable
    {
        private System.Collections.Generic.List<int> _items = new System.Collections.Generic.List<int>();
        public int Count => _items.Count;
        public BinaryHeap() { }
        public BinaryHeap(System.Collections.Generic.List<int> items)
        {
            if (items.Count > 0)
            {
                _items.AddRange(items);
                for (int i = Count; i > 0; i--)
                {
                    Sort(i);
                }
            }

        }
        public void Push(int item)
        {
            _items.Add(item);
            var currentIndex = Count - 1;
            var parentIndex = GetParentIndex(currentIndex);
            if (Count <= 0)
                return;

            while (currentIndex > 0 && _items[currentIndex] > _items[parentIndex])
            {
                Swap(currentIndex, parentIndex);

                currentIndex = parentIndex;
                parentIndex = GetParentIndex(currentIndex);
            }
        }

        public int? PopMax()
        {
            if (Count <= 0)
                return null;
            var result = _items?[0];
            _items[0] = _items[Count - 1];
            _items.RemoveAt(Count - 1);
            if (Count > 0)
                Sort(0);
            return result;
        }

        public void Sort(int currentIndex)
        {
            var maxIndex = currentIndex;
            int leftIndex;
            int rightIndex;

            while (currentIndex < Count)
            {
                leftIndex = 2 * currentIndex + 1;
                rightIndex = 2 * currentIndex + 2;

                if (leftIndex < Count && _items[maxIndex] < _items[leftIndex])
                    maxIndex = leftIndex;
                if (rightIndex < Count && _items[maxIndex] < _items[rightIndex])
                    maxIndex = rightIndex;

                if (maxIndex == currentIndex)
                    break;

                Swap(currentIndex, maxIndex);
                currentIndex = maxIndex;
            }
        }

        private void Swap(int currentIndex, int nextIndex)
        {
            var temp = _items[currentIndex];
            _items[currentIndex] = _items[nextIndex];
            _items[nextIndex] = temp;
        }
        private int GetParentIndex(int currentIndex) => (currentIndex - 1) / 2;

        public IEnumerator GetEnumerator()
        {
            if (Count <= 0)
                yield break;

            for (int i = Count; i > 0; i--)
            {
                yield return PopMax();
            }
        }
    }
}
