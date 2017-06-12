namespace _06L.MathPotato
{
    using System;
    using System.Collections.Generic;

    public class MathPotato
    {
        public static void Main()
        {
            var myQueuePlayers = new Queue<string>(Console.ReadLine().Split());
            var count = int.Parse(Console.ReadLine());
            var cyrcle = 1;

            while (myQueuePlayers.Count > 1)
            {
                for (int i = 1; i < count; i++)
                {
                    var remainder = myQueuePlayers.Dequeue();
                    myQueuePlayers.Enqueue(remainder);
                }

                if (IsPrime(cyrcle))
                {
                    Console.WriteLine($"Prime {myQueuePlayers.Peek()}");
                }
                else
                {
                    Console.WriteLine($"Removed {myQueuePlayers.Dequeue()}");

                }

                cyrcle++;
            }

            Console.WriteLine($"Last is {myQueuePlayers.Dequeue()}");
        }

        public static bool IsPrime(int candidate)
        {
            if ((candidate & 1) == 0)
            {
                if (candidate == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            for (int i = 3; (i * i) <= candidate; i += 2)
            {
                if ((candidate % i) == 0)
                {
                    return false;
                }
            }
            return candidate != 1;
        }
    }
}