namespace _05E.CalculateSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CalculateSequence
    {
        public static void Main()
        {
            var n = long.Parse(Console.ReadLine());
            var myQueue = new Queue<long>();
            myQueue.Enqueue(n);
            var sCount = 0;

            while (myQueue.Count < 51)
            {
                var s = 0L;

                for (int i = 0; i < myQueue.Count; i++)
                {
                    if (i == sCount)
                    {
                        s = myQueue.Peek();
                    }

                    if (true)
                    {

                    }
                    var previous = myQueue.Dequeue();
                    myQueue.Enqueue(previous);
                }

                myQueue.Enqueue(s + 1);
                myQueue.Enqueue((2 * s + 1));
                myQueue.Enqueue(s + 2);

                sCount++;
            }

            Console.WriteLine(string.Join(" ", myQueue.Take(50)));
        }
    }
}