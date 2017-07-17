namespace FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FamilyTree
    {
        public static void Main()
        {
            var neededPerson = Console.ReadLine();
            var peopleList = new List<People>();
            var lines = new List<string>();
            var person = new Person();
            var isName = false;

            if (!neededPerson.Contains("/"))
            {
                person.Name = neededPerson;
                isName = true;
            }
            else
            {
                person.BirthDate = neededPerson;
            }

            var inputLine = Console.ReadLine();

            while (inputLine != "End")
            {
                if (!inputLine.Contains("-"))
                {
                    var tokens = inputLine.Split();
                    var name = $"{tokens[0]} {tokens[1]}";
                    var date = tokens[2];

                    if (isName)
                    {
                        if (person.Name == name)
                        {
                            person.BirthDate = date;
                        }
                        else
                        {
                            peopleList.Add(new People() { Name = name, BirthDate = date });
                        }
                    }
                    else
                    {
                        if (person.BirthDate == date)
                        {
                            person.Name = name;
                        }
                        else
                        {
                            peopleList.Add(new People() { Name = name, BirthDate = date });
                        }
                    }
                }
                else
                {
                    lines.Add(inputLine);

                }

                inputLine = Console.ReadLine();
            }

            FindChilds(peopleList, lines, person);
            FindParents(peopleList, lines, person);
            PrintResult(person);
        }

        private static void FindChilds(List<People> peopleList, List<string> lines, Person person)
        {
            foreach (var line in lines)
            {
                var tokens = line.Split('-').Select(p => p.Trim()).ToArray();
                var leftToken = tokens[0];
                var rightToken = tokens[1];

                if (!leftToken.Contains("/"))
                {
                    if (person.Name == leftToken)
                    {
                        var child = new People();
                        child = GetChild(peopleList, person, rightToken);
                    }
                }
                else
                {
                    if (person.BirthDate == leftToken)
                    {
                        var child = new People();

                        child = GetChild(peopleList, person, rightToken);
                    }
                }
            }
        }

        private static People GetChild(List<People> peopleList, Person person, string rightToken)
        {
            People child;
            if (!rightToken.Contains("/"))
            {
                child = peopleList.SingleOrDefault(p => p.Name == rightToken);
            }
            else
            {
                child = peopleList.SingleOrDefault(p => p.BirthDate == rightToken);
            }

            if (child != null)
            {
                person.Childrens.Add(child);
            }

            return child;
        }

        private static void FindParents(List<People> peopleList, List<string> lines, Person person)
        {
            foreach (var line in lines)
            {
                var tokens = line.Split('-').Select(p => p.Trim()).ToArray();
                var leftToken = tokens[0];
                var rightToken = tokens[1];

                if (!rightToken.Contains("/"))
                {
                    if (person.Name == rightToken)
                    {
                        var parent = new People();
                        parent = GetParent(peopleList, person, leftToken);
                    }
                }
                else
                {
                    if (person.BirthDate == rightToken)
                    {
                        var parent = new People();
                        parent = GetParent(peopleList, person, leftToken);
                    }
                }
            }
        }

        private static People GetParent(List<People> peopleList, Person person, string leftToken)
        {
            People parent;
            if (!leftToken.Contains("/"))
            {
                parent = peopleList.SingleOrDefault(p => p.Name == leftToken);
            }
            else
            {
                parent = peopleList.SingleOrDefault(p => p.BirthDate == leftToken);
            }

            if (parent != null)
            {
                person.Parents.Add(parent);
            }

            return parent;
        }

        private static void PrintResult(Person person)
        {
            Console.WriteLine($"{person.Name} {person.BirthDate}");
            Console.WriteLine($"Parents:");
            if (person.Parents.Count > 0)
            {
                person.Parents.ForEach(p => Console.WriteLine($"{p.Name} {p.BirthDate}"));
            }
            Console.WriteLine("Children:");
            if (person.Childrens.Count > 0)
            {
                person.Childrens.ForEach(ch => Console.WriteLine($"{ch.Name} {ch.BirthDate}"));
            }
        }
    }
}