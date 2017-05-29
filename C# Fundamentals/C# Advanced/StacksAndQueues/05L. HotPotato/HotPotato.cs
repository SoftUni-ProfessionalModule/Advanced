namespace _05L.HotPotato
{
    using System;
    using System.Collections.Generic;

    public class HotPotato
    {
        public static void Main()
        {
            var myQueuePlayers = new Queue<string>(Console.ReadLine().Split());
            var count = int.Parse(Console.ReadLine());

            while (myQueuePlayers.Count > 1)
            {
                for (int i = 0; i < count - 1; i++)
                {
                    var remainder = myQueuePlayers.Dequeue();
                    myQueuePlayers.Enqueue(remainder);
                }

                Console.WriteLine($"Removed {myQueuePlayers.Dequeue()}");
            }

            Console.WriteLine($"Last is {myQueuePlayers.Dequeue()}");
        }
    }
}