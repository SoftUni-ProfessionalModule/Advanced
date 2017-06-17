namespace _01E.StudentsByGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }
    }
    public class StudentsByGroup
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            var students = new List<Student>();

            while (inputLine != "END")
            {
                var studentsDetails = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var group = int.Parse(studentsDetails[2]);

                if (group == 2)
                {
                    students.Add(new Student
                    {
                        FirstName = studentsDetails[0],
                        SecondName = studentsDetails[1],
                    });
                }

                inputLine = Console.ReadLine();
            }

            students
                .OrderBy(n => n.FirstName)
                .ToList()
                .ForEach(n => Console.WriteLine($"{n.FirstName} {n.SecondName}"));
        }
    }
}