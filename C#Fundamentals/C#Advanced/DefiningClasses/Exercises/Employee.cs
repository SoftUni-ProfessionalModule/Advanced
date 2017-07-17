namespace Exercises
{
    public class Employee
    {
        private string name;
        private decimal salary;
        private string position;
        private string department;
        private string email;
        private int age;

        public Employee(string name, decimal salary, string position, string department)
        {
            this.name = name;
            this.salary = salary;
            this.position = position;
            this.department = department;
            this.Email = "n/a";
            this.Age = -1;
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; } }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; } }

        public string Department
        { get { return this.department; } }

        public decimal Salary
        { get { return this.salary; } }

        public string Name
        { get { return this.name; } }
    }
}