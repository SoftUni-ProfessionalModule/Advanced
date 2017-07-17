namespace FamilyTree
{
    using System.Collections.Generic;

    public class Person
    {
        private List<People> parents = new List<People>();
        private List<People> childrens = new List<People>();

        public string Name { get; set; }

        public string BirthDate { get; set; }

        public List<People> Parents
        {
            get { return this.parents = parents; }
            set { this.parents = new List<People>(); }
        }

        public List<People> Childrens
        {
            get { return this.childrens = childrens; }
            set { this.childrens = new List<People>(); }
        }
    }
}