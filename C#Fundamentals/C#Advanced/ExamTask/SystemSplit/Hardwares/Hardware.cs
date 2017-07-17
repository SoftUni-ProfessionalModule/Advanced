namespace SystemSplit
{
    public abstract class Hardware
    {
        private string type;
        private string name;
        private long capacity;
        private long memory;
        private long maxCapacity;
        private long maxMemory;

        public Hardware(string type, string name, long capacity, long memory)
        {
            this.type = type;
            this.name = name;
            this.Capacity = capacity;
            this.Memory = memory;
            this.maxCapacity = capacity;
            this.maxMemory = memory;
        }

        public long MaxCapacity
        {
            get { return this.maxCapacity; }
            protected set
            {
                this.maxCapacity = value;
            }
        }

        public long MaxMemory
        {
            get { return this.maxMemory; }
            set
            {
                this.maxMemory = value;
            }
        }

        public string Type
        {
            get { return this.type; }
            
        }

        public string Name
        {
            get { return this.name; }
        }

        public long Capacity
        {
            get { return this.capacity; }
            set
            {
                if (value >= 0)
                {
                    this.capacity = value;
                }
            }
        }

        public long Memory
        {
            get { return this.memory; }
            set
            {
                if (value >= 0)
                {
                    this.memory = value;
                }
            }
        }
    }
}