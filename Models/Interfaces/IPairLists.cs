namespace DataStructures.Models.Interfaces
{
    interface IPairLists<TKey, TValue>
    {
        void Add(TKey key, TValue value);
        void Delete(TKey key);
    }
}
