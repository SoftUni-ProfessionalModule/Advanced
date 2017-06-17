namespace _03E.StudentsByAge
{
    using System;
    using System.Collections.Generic;

    public class StudentsByAge
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            Func<int, int, int, bool> isAgeMatch = (x, y, z) => y >= x && y <= z;
            var students = new List<string>();

            while (inputLine != "END")
            {
                var studentDetails = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var age = int.Parse(studentDetails[2]);

                if (isAgeMatch(18, age, 24))
                {
                    students.Add(inputLine);
                }

                inputLine = Console.ReadLine();
            }

            students.ForEach(s => Console.WriteLine(s));
        }
    }
}