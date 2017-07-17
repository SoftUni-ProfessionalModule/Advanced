namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FootballTeamGenerator
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            var teams = new List<Team>();

            while (inputLine != "END")
            {
                var tokens = inputLine.Split(';');

                try
                {
                    switch (tokens[0])
                    {
                        case "Team":
                            var team = new Team(tokens[1]);
                            teams.Add(team);
                            break;
                        case "Add":
                            if (teams.Any(t => t.Name == tokens[1]))
                            {
                                team = teams.SingleOrDefault(t => t.Name == tokens[1]);
                                var player =
                                    new Player(tokens[2], int.Parse(tokens[3]), int.Parse(tokens[4]), int.Parse(tokens[5]), int.Parse(tokens[6]), int.Parse(tokens[7]));

                                team.AddPlayer(player);
                            }
                            else
                            {
                                Console.WriteLine($"Team {tokens[1]} does not exist.");
                            }
                            break;
                        case "Remove":
                            team = teams.SingleOrDefault(t => t.Name == tokens[1]);
                            team.RemovePlayer(team.Players.SingleOrDefault(p => p.Name == tokens[2]), tokens[2]);
                            break;
                        case "Rating":
                            if (teams.Any(t => t.Name == tokens[1]))
                            {
                                team = teams.SingleOrDefault(t => t.Name == tokens[1]);
                                Console.WriteLine($"{team.Name} - {Math.Ceiling(team.GetTeamRating())}");
                            }
                            else
                            {
                                Console.WriteLine($"Team {tokens[1]} does not exist.");
                            }
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }


                inputLine = Console.ReadLine();
            }
        }
    }
}