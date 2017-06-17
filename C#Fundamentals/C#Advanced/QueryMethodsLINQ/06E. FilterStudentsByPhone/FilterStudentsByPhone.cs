namespace _06E.FilterStudentsByPhone
{
    using System;
    using System.Collections.Generic;

    public class FilterStudentsByPhone
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            Func<string, bool> isEmailPhone = x => x.StartsWith("02") || x.StartsWith("+3592");
            var students = new List<string>();

            while (inputLine != "END")
            {
                var studentsDetails = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var phoneNumber = studentsDetails[2];

                if (isEmailPhone(phoneNumber))
                {
                    students.Add(studentsDetails[0] + " " + studentsDetails[1]);
                }

                inputLine = Console.ReadLine();
            }

            students.ForEach(s => Console.WriteLine(s));
        }
    }
}