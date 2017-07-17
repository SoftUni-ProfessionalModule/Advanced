namespace SystemSplit
{
    public class PowerHardware : Hardware
    {
        public PowerHardware(string type, string name, long capacity, long memory) 
            : base(type, name, capacity, memory)
        {
            this.Capacity -= ((this.Capacity * 3) / 4);
            this.MaxCapacity = Capacity;
            this.Memory += ((this.Memory * 3) / 4);
            this.MaxMemory = Memory;
        }
    }
}