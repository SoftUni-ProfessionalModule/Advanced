namespace _05E.Phonebook
{
    using System;
    using System.Collections.Generic;

    public class Phonebook
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();

            var phonebook = new Dictionary<string, string>();

            while (inputLine != "search")
            {
                var phonebookDetails = inputLine.Split('-');
                var currentContactName = phonebookDetails[0];
                var phoneNumber = phonebookDetails[1];

                if (!phonebook.ContainsKey(currentContactName))
                {
                    phonebook.Add(currentContactName, phoneNumber);
                }
                else
                {
                    phonebook[currentContactName] = phoneNumber;

                }

                inputLine = Console.ReadLine();
            }

            var name = Console.ReadLine();

            while (name != "stop")
            {
                if (!phonebook.ContainsKey(name))
                {
                    Console.WriteLine($"Contact {name} does not exist.");
                }
                else
                {
                    Console.WriteLine($"{name} -> {phonebook[name]}");
                }

                name = Console.ReadLine();
            }
        }
    }
}