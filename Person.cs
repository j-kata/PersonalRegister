namespace PersonarRegister
{
    public class Person
    {
        public string Name { get; set; }
        public int Salary { get; set; }

        public Person(string name, int salary)
        {
            Name = name;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"{Name} {Salary}";
        }
    }
}