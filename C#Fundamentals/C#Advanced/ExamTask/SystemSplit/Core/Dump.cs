using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemSplit
{
    public class Dump
    {
        private List<Hardware> dumpedHardwares;
        private List<Software> dumpedSoftwares;

        public Dump()
        {
            this.dumpedHardwares = new List<Hardware>();
            this.dumpedSoftwares = new List<Software>();
        }

        public List<Hardware> DumpedHardwares
        {
            get { return this.dumpedHardwares; }
        }

        public List<Software> DumpedSoftwares
        {
            get { return this.dumpedSoftwares; }
        }

        public void AddHardware(Hardware hardware)
        {
            this.dumpedHardwares.Add(hardware);
        }

        public void AddSoftwares(List<Software> softwares)
        {
            this.dumpedSoftwares.AddRange(softwares);
        }

        public void DestroyDump(string hardwareName)
        {
            if (dumpedHardwares.Any(h => h.Name == hardwareName))
            {
                var hardware = this.dumpedHardwares.Single(h => h.Name == hardwareName);
                this.dumpedHardwares.Remove(hardware);
                this.dumpedSoftwares.RemoveAll(s => s.HardwareType == hardwareName);
            }
        }

        public string GetDumpAnalyze()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Dump Analysis");
            sb.AppendLine($"Power Hardware Components: {this.dumpedHardwares.Where(h => h.GetType().Name == "PowerHardware").ToList().Count}");
            sb.AppendLine($"Heavy Hardware Components: {this.dumpedHardwares.Where(h => h.GetType().Name == "HeavyHardware").ToList().Count}");
            sb.AppendLine($"Express Software Components: {this.dumpedSoftwares.Where(s => s.GetType().Name == "ExpressSoftware").ToList().Count}");
            sb.AppendLine($"Light Software Components: {this.dumpedSoftwares.Where(s => s.GetType().Name == "LightSoftware").ToList().Count}");
            sb.AppendLine($"Total Dumped Memory: {this.dumpedSoftwares.Sum(h => h.MemoryConsumption)}");
            sb.AppendLine($"Total Dumped Capacity: {this.dumpedSoftwares.Sum(h => h.CapacityConsumption)}");

            return sb.ToString().Trim();
        }
    }
}