namespace Google
{
    using System;
    using System.Collections.Generic;

    public class GoogleStartUp
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            var personDict = new Dictionary<string, Person>();

            while (inputLine != "End")
            {
                var personDetails = inputLine.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                var personeName = personDetails[0];
                var classType = personDetails[1];

                if (!personDict.ContainsKey(personeName))
                {
                    personDict.Add(personeName, new Person(personeName));
                }

                switch (classType)
                {
                    case "company":
                        var currentCompany = new Company(personDetails[2], personDetails[3], decimal.Parse(personDetails[4]));
                        personDict[personeName].Company = currentCompany;
                        break;
                    case "car":
                        var currentCar = new Car(personDetails[2], int.Parse(personDetails[3]));
                        personDict[personeName].Car = currentCar;
                        break;
                    case "parents":
                        var currentParent = new Parent(personDetails[2], personDetails[3]);
                        personDict[personeName].Parents.Add(currentParent);
                        break;
                    case "children":
                        var currentChildren = new Children(personDetails[2], personDetails[3]);
                        personDict[personeName].Childrens.Add(currentChildren);
                        break;
                    case "pokemon":
                        var currentPokemon = new Pokemon(personDetails[2], personDetails[3]);
                        personDict[personeName].Pokemons.Add(currentPokemon);
                        break;
                }

                inputLine = Console.ReadLine();
            }

            var neededName = Console.ReadLine();

            Console.WriteLine(personDict[neededName].ToString());
        }
    }
}