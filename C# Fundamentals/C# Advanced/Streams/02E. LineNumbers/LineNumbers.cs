namespace _02E.LineNumbers
{
    using System.IO;

    public class LineNumbers
    {
        public static void Main()
        {
            var reader = new StreamReader("text.txt");
            var writer = new StreamWriter("result.txt");
            var lineCounter = 1;

            using (reader)
            {
                using (writer)
                {
                    var sourceLine = reader.ReadLine();

                    while (sourceLine != null)
                    {
                        writer.WriteLine($"{lineCounter}. {sourceLine}");
                        lineCounter++;
                        sourceLine = reader.ReadLine();
                    }
                }
            }
        }
    }
}