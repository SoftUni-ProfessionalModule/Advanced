namespace _10E.SimpleTextEditor
{
    using System;
    using System.Collections.Generic;

    public class SimpleTextEditor
    {
        public static void Main()
        {
            var numberOfCommands = int.Parse(Console.ReadLine());

            var text = string.Empty;
            var commandValue = 0;
            var lastUndoneCommand = new Stack<string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                var commandParams = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var commandType = commandParams[0];

                switch (commandType)
                {
                    case "1":
                        lastUndoneCommand.Push(text);
                        text += commandParams[1];
                        break;
                    case "2":
                        lastUndoneCommand.Push(text);
                        commandValue = int.Parse(commandParams[1]);
                        text = text.Substring(0, text.Length - commandValue);
                        break;
                    case "3":
                        commandValue = int.Parse(commandParams[1]);
                        Console.WriteLine(text[commandValue- 1]);
                        break;
                    case "4":
                        text = lastUndoneCommand.Pop();
                        break;
                }
            }
        }
    }
}