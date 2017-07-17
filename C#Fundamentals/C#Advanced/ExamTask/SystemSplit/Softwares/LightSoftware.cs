namespace SystemSplit
{
    public class LightSoftware : Software
    {
        public LightSoftware(string hardwareType, string name, long capacity, long memory) 
            : base(hardwareType, name, capacity, memory)
        {
            this.CapacityConsumption += (this.CapacityConsumption * 50) / 100;
            this.MemoryConsumption -= (this.MemoryConsumption * 50) / 100;
        }
    }
}