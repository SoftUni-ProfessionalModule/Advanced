namespace _04E.BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicQueueOperations
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var s = inputLine[1];
            var x = inputLine[2];

            var myQueue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            for (int i = 0; i < s; i++)
            {
                myQueue.Dequeue();
            }

            if (myQueue.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (myQueue.Any())
                {
                    Console.WriteLine(myQueue.Min());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
