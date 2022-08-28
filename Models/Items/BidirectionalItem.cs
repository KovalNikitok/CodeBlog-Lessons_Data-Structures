namespace DataStructures.Models.Items
{
    class BidirectionalItem<T>
    {
        private T _data;
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
        public BidirectionalItem<T> Previous { get; set; }
        public BidirectionalItem<T> Next { get; set; }
        
        public BidirectionalItem() 
        {
            _data = default(T);
        }
        
        public BidirectionalItem(T data) 
        {
            Data = data;
        }
        public override string ToString()
        {
            return _data.ToString();
        }
    }
}
