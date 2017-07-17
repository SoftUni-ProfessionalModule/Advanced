using System;

namespace SystemSplit
{
    public class CommandInterpreter
    {
        System system = new System();
        Dump dump = new Dump();

        public void GetCommand(string[] commansArgs)
        {
            var currentCommand = commansArgs[0];

            switch (currentCommand)
            {
                case "RegisterPowerHardware":
                    system.RegHardware
                        (new PowerHardware("Power", commansArgs[1], long.Parse(commansArgs[2]), long.Parse(commansArgs[3])));
                    break;
                case "RegisterHeavyHardware":
                    system.RegHardware
                        (new HeavyHardware("Heavy", commansArgs[1], long.Parse(commansArgs[2]), long.Parse(commansArgs[3])));
                    break;
                case "RegisterExpressSoftware":
                    var expressSoft = 
                        new ExpressSoftware(commansArgs[1], commansArgs[2], long.Parse(commansArgs[3]), long.Parse(commansArgs[4]));
                    system.RegSoftware(expressSoft, commansArgs[1]);
                    break;
                case "RegisterLightSoftware":
                    var lightSoft =
                        new LightSoftware(commansArgs[1], commansArgs[2], long.Parse(commansArgs[3]), long.Parse(commansArgs[4]));
                    system.RegSoftware(lightSoft, commansArgs[1]);
                    break;
                case "ReleaseSoftwareComponent":
                    system.ReleaseSoftware(commansArgs[1], commansArgs[2]);
                    break;
                case "Analyze":
                    Console.WriteLine(system.GetAnalysis()); 
                    break;
                case "Dump":
                    dump.AddHardware(system.DumpHardware(commansArgs[1]));
                    dump.AddSoftwares(system.DumpSoftwares(commansArgs[1]));
                    break;
                case "Restore":
                    system.Restore(commansArgs[1], dump.DumpedHardwares, dump.DumpedSoftwares);
                    break;
                case "Destroy":
                    dump.DestroyDump(commansArgs[1]);
                    break;
                case "DumpAnalyze":
                    Console.WriteLine(dump.GetDumpAnalyze());
                    break;
                case "System":
                    Console.WriteLine(system.PrintFullSystem());
                    break;
            }
        }
    }
}