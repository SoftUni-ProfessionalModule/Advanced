namespace BashSoft
{
    using System;
    using System.IO;

    public class Launcher
    {
        public static void Main()
        {
            byte[] inputBuffer = new byte[1024];
            Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));

            InputReader.StartReadingCommands();
        }
    }
}