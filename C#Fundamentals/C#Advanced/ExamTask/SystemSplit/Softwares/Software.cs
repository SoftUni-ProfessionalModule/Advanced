namespace SystemSplit
{
    public abstract class Software
    {
        private string hardwareType;
        private string name;
        private long capacityComptionnsu;
        private long memoryConsumption;

        public Software(string hardwareType, string name, long capacity, long memory)
        {
            this.hardwareType = hardwareType;
            this.name = name;
            this.CapacityConsumption = capacity;
            this.MemoryConsumption = memory;
        }

        public string HardwareType
        {
            get { return this.hardwareType; }
        }

        public string Name
        {
            get { return this.name; }
        }

        public long CapacityConsumption
        {
            get { return this.capacityComptionnsu; }
            set { this.capacityComptionnsu = value; }
        }

        public long MemoryConsumption
        {
            get { return this.memoryConsumption; }
            set { this.memoryConsumption = value; }
        }
    }
}