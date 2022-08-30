namespace DataStructures.Models.Items
{
    class KeyValueItem<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public KeyValueItem() {  }
        public KeyValueItem(TKey key, TValue value) 
        {
            if (key == null)
                return;
            Key = key;
            Value = value;
        }
        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
