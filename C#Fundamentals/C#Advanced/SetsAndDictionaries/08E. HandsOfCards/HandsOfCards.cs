namespace _08E.HandsOfCards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class HandsOfCards
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            var playersAndCards = new Dictionary<string, HashSet<string>>();

            while (inputLine != "JOKER")
            {
                var inputParams = inputLine.Split(':');
                var playerName = inputParams[0];

                var cards = inputParams[1]
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(c => c.Trim())
                    .ToArray();


                if (!playersAndCards.ContainsKey(playerName))
                {
                    playersAndCards.Add(playerName, new HashSet<string>(cards));
                }
                else
                {
                    playersAndCards[playerName].UnionWith(cards);
                }

                inputLine = Console.ReadLine();
            }

            foreach (var player in playersAndCards)
            {
                var currentPlayerResult = CalculateScore(playersAndCards[player.Key]);

                Console.WriteLine($"{player.Key}: {currentPlayerResult}");
            }

        }

        private static int CalculateScore(HashSet<string> cards)
        {
            var tempScore = 0;
            var totalScore = 0;

            foreach (var card in cards)
            {
                var isDigit = int.TryParse(card.Substring(0, card.Length - 1), out tempScore);
                var type = card.Last();

                if (!isDigit)
                {
                    var power = card.Substring(0, card.Length - 1);

                    switch (power)
                    {
                        case "J":
                            tempScore = 11;
                            break;
                        case "Q":
                            tempScore = 12;
                            break;
                        case "K":
                            tempScore = 13;
                            break;
                        case "A":
                            tempScore = 14;
                            break;
                    }
                }

                switch (type)
                {
                    case 'S':
                        tempScore *= 4;
                        break;
                    case 'H':
                        tempScore *= 3;
                        break;
                    case 'D':
                        tempScore *= 2;
                        break;
                    case 'C':
                        tempScore *= 1;
                        break;
                }

                totalScore += tempScore;
            }

            return totalScore;
        }
    }
}