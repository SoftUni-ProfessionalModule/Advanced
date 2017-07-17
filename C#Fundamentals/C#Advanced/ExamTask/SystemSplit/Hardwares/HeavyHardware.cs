namespace SystemSplit
{
    public class HeavyHardware : Hardware
    {
        public HeavyHardware(string type, string name, long capacity, long memory) 
            : base(type, name, capacity, memory)
        {
            this.Capacity *= 2;
            this.MaxCapacity = Capacity;
            this.Memory -= (this.Memory / 4);
            this.MaxMemory = Memory;
        }
    }
}