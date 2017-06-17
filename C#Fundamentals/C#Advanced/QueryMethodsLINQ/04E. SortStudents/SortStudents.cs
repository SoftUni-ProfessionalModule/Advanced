namespace _04E.SortStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
    public class SortStudents
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
                    LastName = studentsDetails[1],
                });

                inputLine = Console.ReadLine();
            }

            students
                .OrderBy(l => l.LastName)
                .ThenByDescending(f => f.FirstName)
                .ToList()
                .ForEach(n => Console.WriteLine($"{n.FirstName} {n.LastName}"));
        }
    }
}