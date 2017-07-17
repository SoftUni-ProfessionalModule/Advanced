namespace Exercises
{
    using System.Collections.Generic;
    using System.Linq;

    public class Person
    {
        private SortedDictionary<string, int> people;

        public Person()
        {
            this.people = new SortedDictionary<string, int>();
        }

        public void AddPerson(string name, int age)
        {
            if (!people.ContainsKey(name))
            {
                people.Add(name, 0);
            }

            people[name] = age;
        }

        public List<KeyValuePair<string, int>> GetPeopleOlderThat30()
        {
            List<KeyValuePair<string, int>> result = people.Where(p => p.Value > 30).ToList();

            return result;
        }
    }
}
