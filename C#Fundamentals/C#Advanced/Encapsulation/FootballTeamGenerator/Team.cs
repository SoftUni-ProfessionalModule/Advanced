namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Team
    {
        private string name;
        private List<Player> players = new List<Player>();

        public Team(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public List<Player> Players
        {
            get { return this.players; }
            set
            {
                this.players = new List<Player>();
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(Player player, string playerName)
        {
            if (!this.players.Contains(player))
            {
                throw new ArgumentException($"Player {playerName} is not in {this.name} team.");
            }

            this.players.Remove(player);
        }

        public double GetTeamRating()
        {
            return this.players.Sum(p => p.AverageStatsValue);
        }
    }
}