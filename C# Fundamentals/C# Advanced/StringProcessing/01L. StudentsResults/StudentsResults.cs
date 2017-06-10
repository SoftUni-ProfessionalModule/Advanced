namespace _01L.StudentsResults
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsResults
    {
        public static void Main()
        {
            var numberOfLines = int.Parse(Console.ReadLine());
            var students = new Dictionary<string, List<double>>();

            for (int i = 0; i < numberOfLines; i++)
            {
                var inputLine = Console.ReadLine()
                .Split(new char[] { '-', ',', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                var studentName = inputLine[0];

                if (!students.ContainsKey(studentName))
                {
                    students.Add(studentName, new List<double>());
                }

                students[studentName].Add(double.Parse(inputLine[1]));
                students[studentName].Add(double.Parse(inputLine[2]));
                students[studentName].Add(double.Parse(inputLine[3]));
            }

            Console.WriteLine(string.Format("{0,-10}|{1,7}|{2,7}|{3,7}|{4,7}|", "Name", "CAdv", "COOP", "AdvOOP", "Average"));

            foreach (var student in students)
            {
                Console.WriteLine
                    (string.Format("{0,-10}|{1,7:f2}|{2,7:f2}|{3,7:f2}|{4,7:f4}|"
                    , student.Key, student.Value[0], student.Value[1], student.Value[2], student.Value.Average()));
            }
        }
    }
}