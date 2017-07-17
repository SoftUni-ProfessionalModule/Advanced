namespace Google
{
    public class Parent
    {
        private string name;
        private string birthDay;

        public Parent(string name, string birthDay)
        {
            this.name = name;
            this.birthDay = birthDay;
        }

        public string Name
        {
            get { return this.name; }
        }

        public string BirthDay
        {
            get { return this.birthDay; }
        }
    }
}