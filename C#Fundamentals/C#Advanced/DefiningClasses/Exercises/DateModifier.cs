namespace Exercises
{
    using System;
    using System.Linq;

    public class DateModifier
    {
        private DateTime firstDate;
        private DateTime secondDate;

        public double CalculateDifference(string inputDateOne, string inputDateTwo)
        {
            var firstDateTokens = inputDateOne.Split().Select(int.Parse).ToArray();
            this.firstDate = new DateTime(firstDateTokens[0], firstDateTokens[1], firstDateTokens[2]);

            var secondDateTokens = inputDateTwo.Split().Select(int.Parse).ToArray();
            this.secondDate = new DateTime(secondDateTokens[0], secondDateTokens[1], secondDateTokens[2]);

            return 
                (secondDate - firstDate).TotalDays > 0 ? 
                (secondDate - firstDate).TotalDays : (firstDate - secondDate).TotalDays;
        }
    }
}