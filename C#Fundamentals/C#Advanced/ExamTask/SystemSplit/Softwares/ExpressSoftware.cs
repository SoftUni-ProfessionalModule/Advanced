namespace SystemSplit
{
    public class ExpressSoftware : Software
    {
        public ExpressSoftware(string hardwareType, string name, long capacity, long memory)
            : base(hardwareType, name, capacity, memory)
        {
            this.MemoryConsumption *= 2;
        }
    }
}