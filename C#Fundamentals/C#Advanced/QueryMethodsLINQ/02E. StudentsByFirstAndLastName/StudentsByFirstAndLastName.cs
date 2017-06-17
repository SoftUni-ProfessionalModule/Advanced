namespace _02E.StudentsByFirstAndLastName
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }
    }
    public class StudentsByFirstAndLastName
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            var students = new List<Student>();

            while (inputLine != "END")
            {
                var studentsDetails = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                students.Add(new Student
                {
                    FirstName = studentsDetails[0],
                    SecondName = studentsDetails[1],
                });

                inputLine = Console.ReadLine();
            }

            students
                .Where(n => string.Compare(n.FirstName, n.SecondName, false) < 0)
                .ToList()
                .ForEach(n => Console.WriteLine($"{n.FirstName} {n.SecondName}"));
        }
    }
}