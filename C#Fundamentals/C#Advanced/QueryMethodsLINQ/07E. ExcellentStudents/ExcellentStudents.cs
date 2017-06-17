namespace _07E.ExcellentStudents
{
    using System;
    using System.Collections.Generic;

    public class ExcellentStudents
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            Func<string, bool> isMarksMatch = x => x.Contains("6");
            var students = new List<string>();

            while (inputLine != "END")
            {
                var studentsDetails = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (isMarksMatch(inputLine))
                {
                    students.Add(studentsDetails[0] + " " + studentsDetails[1]);
                }

                inputLine = Console.ReadLine();
            }

            students.ForEach(s => Console.WriteLine(s));
        }
    }
}