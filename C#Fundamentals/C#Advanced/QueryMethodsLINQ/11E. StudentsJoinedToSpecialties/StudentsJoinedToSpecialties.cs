namespace _11E.StudentsJoinedToSpecialties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentSpecialty
    {
        public string Specialty { get; set; }

        public string FacultyNumber { get; set; }
    }

    public class Student
    {
        public string Name { get; set; }

        public string FacultyNumber { get; set; }
    }
    public class StudentsJoinedToSpecialties
    {
        public static void Main()
        {
            var specialtiesInput = Console.ReadLine();
            var specialtyList = new List<StudentSpecialty>();
            var studentList = new List<Student>();

            while (specialtiesInput != "Students:")
            {
                var specialtyAsArr = specialtiesInput.Split().Take(2).ToArray();
                var specialty = string.Join(" ", specialtyAsArr);
                var facNumber = specialtiesInput.Split().Skip(2).ToArray();

                specialtyList.Add(new StudentSpecialty { Specialty = specialty, FacultyNumber = facNumber[0] });

                specialtiesInput = Console.ReadLine();
            }

            var studentsInput = Console.ReadLine();

            while (studentsInput != "END")
            {
                var facNumber = studentsInput.Split().Take(1).ToArray();
                var namesAsArr = studentsInput.Split().Skip(1).ToArray();
                var name = string.Join(" ", namesAsArr);

                studentList.Add(new Student { Name = name, FacultyNumber = facNumber[0] });

                studentsInput = Console.ReadLine();
            }

            var result = studentList.Join(specialtyList, arg => arg.FacultyNumber, arg => arg.FacultyNumber, (first, second) => new { name = first.Name, facNum = first.FacultyNumber, speciality = second.Specialty });

            foreach (var student in result.OrderBy(x => x.name))
            {
                Console.WriteLine($"{student.name} {student.facNum} {student.speciality}");
            }
        }
    }
}