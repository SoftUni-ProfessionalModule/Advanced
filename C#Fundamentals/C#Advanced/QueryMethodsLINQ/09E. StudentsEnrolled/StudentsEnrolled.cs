namespace _09E.StudentsEnrolled
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsEnrolled
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            Func<string, bool> isYearsMatch = x => x.EndsWith("14") || x.EndsWith("15");
            var students = new List<string>();

            while (inputLine != "END")
            {
                var facultyNumber = inputLine
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Take(1)
                    .ToArray();

                if (isYearsMatch(facultyNumber[0]))
                {
                    var studentMarks = inputLine
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Skip(1)
                    .ToList();

                    students.Add(string.Join(" ", studentMarks));
                }

                inputLine = Console.ReadLine();
            }

            students.ForEach(s => Console.WriteLine(s));
        }
    }
}