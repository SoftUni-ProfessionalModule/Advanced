using System;

namespace SystemSplit
{
    public class Startup
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            string[] commandArgs = null;

            CommandInterpreter commandInterpreter = new CommandInterpreter();

            while (inputLine != "System Split")
            {
                commandArgs = inputLine.Split(new[] { ' ', '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);

                commandInterpreter.GetCommand(commandArgs);

                inputLine = Console.ReadLine();
            }

            commandArgs = inputLine.Split(new[] { ' ', '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
            commandInterpreter.GetCommand(commandArgs);
        }
    }
}