using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemSplit
{
    public class System
    {
        private List<Hardware> hardwares;
        private List<Software> softwares;

        public System()
        {
            this.hardwares = new List<Hardware>();
            this.softwares = new List<Software>();
        }

        public void RegHardware(Hardware hardware)
        {
            this.hardwares.Add(hardware);
        }

        public void RegSoftware(Software software, string hardwareName)
        {
            if (hardwares.Any(h => h.Name == hardwareName))
            {
                var hardware = hardwares.Single(h => h.Name == hardwareName);

                if (hardware.Capacity >= software.CapacityConsumption 
                    && hardware.Memory >= software.MemoryConsumption)
                {
                    this.softwares.Add(software);
                    hardware.Capacity -= software.CapacityConsumption;
                    hardware.Memory -= software.MemoryConsumption;
                }
            }
        }

        public void ReleaseSoftware(string hardwareName, string softwareName)
        {
            if (hardwares.Any(h => h.Name == hardwareName))
            {
                if (softwares.Any(s => s.Name == softwareName))
                {
                    var hardware = hardwares.Single(h => h.Name == hardwareName);
                    var software = softwares.Single(s => s.Name == softwareName);

                    hardware.Capacity += software.CapacityConsumption;
                    hardware.Memory += software.MemoryConsumption;
                    softwares.Remove(software);
                }
            }
        }

        public string GetAnalysis()
        {
            var sb = new StringBuilder();
            sb.AppendLine("System Analysis");
            sb.AppendLine($"Hardware Components: {this.hardwares.Count}");
            sb.AppendLine($"Software Components: {this.softwares.Count}");
            sb.AppendLine($"Total Operational Memory: {this.softwares.Sum(m => m.MemoryConsumption)} / {this.hardwares.Sum(h => h.MaxMemory)}");
            sb.AppendLine($"Total Capacity Taken: {this.softwares.Sum(c => c.CapacityConsumption)} / {this.hardwares.Sum(h => h.MaxCapacity)}");

            return sb.ToString().Trim();
        }

        public string PrintFullSystem()
        {
            var sb = new StringBuilder();

            var powerHardwareComponents = hardwares.Where(h => h.GetType().Name == "PowerHardware").ToList();

            foreach (var powerHardware in powerHardwareComponents)
            {
                sb.AppendLine($"Hardware Component - {powerHardware.Name}");
                sb.AppendLine($"Express Software Components - {softwares.Where(s => s.GetType().Name == "ExpressSoftware").Where(s => s.HardwareType == powerHardware.Name).ToList().Count()}");
                sb.AppendLine($"Light Software Components - {softwares.Where(s => s.GetType().Name == "LightSoftware").Where(s => s.HardwareType == powerHardware.Name).ToList().Count()}");
                sb.AppendLine($"Memory Usage: {softwares.Where(s => s.HardwareType == powerHardware.Name).Sum(x => x.MemoryConsumption)} / {powerHardware.MaxMemory}");
                sb.AppendLine($"Capacity Usage: {softwares.Where(s => s.HardwareType == powerHardware.Name).Sum(x => x.CapacityConsumption)} / {powerHardware.MaxCapacity}");
                sb.AppendLine($"Type: {powerHardware.Type}");
                var softWareComponents = softwares.Where(s => s.HardwareType == powerHardware.Name).Select(s => s.Name).ToArray();
                if (softWareComponents.Any())
                {
                    sb.AppendLine($"Software Components: {string.Join(", ", softWareComponents)}");
                }
                else
                {
                    sb.AppendLine("Software Components: None");
                }
            }

            var heavyHardwareComponents = hardwares.Where(h => h.GetType().Name == "HeavyHardware").ToList();

            foreach (var heavyHardware in heavyHardwareComponents)
            {
                sb.AppendLine($"Hardware Component - {heavyHardware.Name}");
                sb.AppendLine($"Express Software Components - {softwares.Where(s => s.GetType().Name == "ExpressSoftware").Where(s => s.HardwareType == heavyHardware.Name).ToList().Count()}");
                sb.AppendLine($"Light Software Components - {softwares.Where(s => s.GetType().Name == "LightSoftware").Where(s => s.HardwareType == heavyHardware.Name).ToList().Count()}");
                sb.AppendLine($"Memory Usage: {softwares.Where(s => s.HardwareType == heavyHardware.Name).Sum(x => x.MemoryConsumption)} / {heavyHardware.MaxMemory}");
                sb.AppendLine($"Capacity Usage: {softwares.Where(s => s.HardwareType == heavyHardware.Name).Sum(x => x.CapacityConsumption)} / {heavyHardware.MaxCapacity}");
                sb.AppendLine($"Type: {heavyHardware.Type}");
                var softWareComponents = softwares.Where(s => s.HardwareType == heavyHardware.Name).Select(s => s.Name).ToArray();
                if (softWareComponents.Any())
                {
                    sb.AppendLine($"Software Components: {string.Join(", ", softWareComponents)}");
                }
                else
                {
                    sb.AppendLine("Software Components: None");
                }
            }

            return sb.ToString().Trim();
        }

        public Hardware DumpHardware(string hardwareName)
        {
            Hardware hardware = null;

            if (hardwares.Any(h => h.Name == hardwareName))
            {
                hardware = hardwares.Single(h => h.Name == hardwareName);
            }

            return hardware;
        }

        public List<Software> DumpSoftwares(string hardwareName)
        {
            Hardware hardware = null;
            List<Software> softwares = new List<Software>();

            if (hardwares.Any(h => h.Name == hardwareName))
            {
                hardware = hardwares.Single(h => h.Name == hardwareName);
                softwares = this.softwares.Where(s => s.HardwareType == hardwareName).ToList();
            }

            this.hardwares.Remove(hardware);
            
            foreach (var software in softwares)
            {
                this.softwares.Remove(software);
            }

            return softwares;
        }

        public void Restore(string hardwareName, List<Hardware> hardware, List<Software> softwares)
        {
            if (hardware.Any(h => h.Name == hardwareName))
            {
                this.hardwares.Add(hardware.Single(h => h.Name == hardwareName));
                this.softwares.AddRange(softwares.Where(s => s.HardwareType == hardwareName));
                hardware.Remove(hardware.Single(h => h.Name == hardwareName));
                softwares = softwares.Where(s => s.HardwareType != hardwareName).ToList();
            }
        }
    }
}