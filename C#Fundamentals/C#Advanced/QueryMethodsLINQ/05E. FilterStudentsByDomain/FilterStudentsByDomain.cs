namespace _05E.FilterStudentsByDomain
{
    using System;
    using System.Collections.Generic;

    public class FilterStudentsByDomain
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            Func<string, bool> isEmailMatch = x => x.Contains("@gmail.com");
            var students = new List<string>();

            while (inputLine != "END")
            {
                var studentsDetails = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var email = studentsDetails[2];

                if (isEmailMatch(email))
                {
                    students.Add(studentsDetails[0] + " " + studentsDetails[1]);
                }

                inputLine = Console.ReadLine();
            }

            students.ForEach(s => Console.WriteLine(s));
        }
    }
}