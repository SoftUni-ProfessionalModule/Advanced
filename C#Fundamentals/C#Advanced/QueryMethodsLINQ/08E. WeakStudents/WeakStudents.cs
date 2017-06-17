namespace _08E.WeakStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class WeakStudents
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            Func<int, bool> isMarksMatch = x => x >= 2;
            var students = new List<string>();

            while (inputLine != "END")
            {
                var studentMarks = inputLine
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Skip(2)
                    .Select(int.Parse)
                    .Where(m => m <= 3)
                    .ToList();

                if (isMarksMatch(studentMarks.Count))
                {
                    var student = inputLine
                         .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                         .Take(2)
                         .ToArray();

                    students.Add(student[0] + " " + student[1]);
                }

                inputLine = Console.ReadLine();
            }

            students.ForEach(s => Console.WriteLine(s));
        }
    }
}