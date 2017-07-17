namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Player
    {
        private string name;
        private double endurance;
        private double sprint;
        private double dribble;
        private double passing;
        private double shooting;
        private List<double> stats;
        private double averageStatsValue;

        private const int MinStatsValue = 0;
        private const int MaxStatsValue = 100;


        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty. ");
                }

                this.name = value;
            }
        }
        private double Endurance
        {
            set
            {
                if (value < MinStatsValue || value > MaxStatsValue)
                {
                    throw new ArgumentException($"Endurance should be between {MinStatsValue} and {MaxStatsValue}.");
                }

                this.endurance = value;
                this.stats.Add(value);
            }
        }

        private double Sprint
        {
            set
            {
                if (value < MinStatsValue || value > MaxStatsValue)
                {
                    throw new ArgumentException($"Sprint should be between {MinStatsValue} and {MaxStatsValue}.");
                }

                this.sprint = value;
                this.stats.Add(value);
            }
        }

        private double Dribble
        {
            set
            {
                if (value < MinStatsValue || value > MaxStatsValue)
                {
                    throw new ArgumentException($"Dribble should be between {MinStatsValue} and {MaxStatsValue}.");
                }

                this.dribble = value;
                this.stats.Add(value);
            }
        }

        private double Passing
        {
            set
            {
                if (value < MinStatsValue || value > MaxStatsValue)
                {
                    throw new ArgumentException($"Passing should be between {MinStatsValue} and {MaxStatsValue}.");
                }

                this.passing = value;
                this.stats.Add(value);
            }
        }

        private double Shooting
        {
            set
            {
                if (value < MinStatsValue || value > MaxStatsValue)
                {
                    throw new ArgumentException($"Shooting should be between {MinStatsValue} and {MaxStatsValue}.");
                }

                this.shooting = value;
                this.stats.Add(value);
            }
        }

        public double AverageStatsValue
        {
            get { return this.averageStatsValue; }
            private set { this.averageStatsValue = stats.Average(); }
        }
    }
}