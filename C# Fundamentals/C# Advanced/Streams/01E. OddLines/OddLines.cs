namespace _01E.OddLines
{
    using System;
    using System.IO;
    public class OddLines
    {
        public static void Main()
        {
            StreamReader reader = new StreamReader("../../text.txt");

            using (reader)
            {
                var lineCounter = 0;
                var textLine = reader.ReadLine();

                while (textLine != null)
                {
                    if (lineCounter % 2 == 1)
                    {
                        Console.WriteLine(textLine);
                    }

                    textLine = reader.ReadLine();
                    lineCounter++;
                }
            }
        }
    }
}