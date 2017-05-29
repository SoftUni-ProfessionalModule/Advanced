namespace _04L.AcademyGraduation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AcademyGraduation
    {
        public static void Main()
        {
            var linesNumber = int.Parse(Console.ReadLine());

            var studentsDict = new SortedDictionary<string, List<double>>();

            for (int i = 0; i < linesNumber; i++)
            {
                var currentStudent = Console.ReadLine();
                var scores = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                if (!studentsDict.ContainsKey(currentStudent))
                {
                    studentsDict.Add(currentStudent, new List<double>());
                }

                studentsDict[currentStudent].AddRange(scores);
            }

            foreach (var student in studentsDict)
            {
                Console.WriteLine($"{student.Key} is graduated with {student.Value.Average()}");
            }
        }
    }
}