namespace Google
{
    public class Children
    {
        private string name;
        private string birthDay;

        public Children(string name, string birthDay)
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