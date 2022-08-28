namespace DataStructures
{
    class Item<T>
    {
        private T _data;
        public Item<T> Next { get; set; }

        public T Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value ?? default(T);
            }
        }
        public Item()
        {
            _data = default(T);
        }
        public Item(T data)
        {
            Data = data;
        }
        public override string ToString()
        {
            return $"{_data}";
        }
    }
}
