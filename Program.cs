using System;

namespace PersonarRegister
{
  class Program
  {
    static void Main(string[] args)
    {
      var register = new List<Person>();

      Console.WriteLine("Please enter each entry (name and salary separated by a space) on a new line. Type 'exit' to finish.");

      string input;
      while ((input = Console.ReadLine()) != "exit")
      {       
        string[] parts = input.Split(' ');

        if (parts.Length < 2)
        {
          Console.WriteLine("Not enough data");
          continue;
        }

        if (!int.TryParse(parts[^1], out int salary))
        {
          Console.WriteLine("Salary should be a valid number.");
          continue;
        }
        string name = string.Join(" ", parts[..^1]);

        register.Add(new Person(name, salary));
      }

      while (true)
      {
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Print register sorted by name");
        Console.WriteLine("2. Print register sorted by salary");
        Console.WriteLine("3. Search for a person by name");
        Console.WriteLine("4. Print average salary");
        Console.WriteLine("5. Exit");

        if (!int.TryParse(Console.ReadLine(), out int choice))
        {
          Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
          continue;
        }
        switch (choice)
        {
          case 1:
            register.Sort((x, y) => x.Name.CompareTo(y.Name));
            PrintRegister(register);
            break;
          case 2:
            register.Sort((x, y) => x.Salary.CompareTo(y.Salary));
            PrintRegister(register);
            break;
          case 3:
            Console.WriteLine("Enter the name to search for:");
            string searchName = Console.ReadLine();
            var matches = register.Where(p => p.Name.Contains(searchName, StringComparison.OrdinalIgnoreCase));
            PrintRegister([.. matches]);
            break;
          case 4:
            double averageSalary = register.Average(p => p.Salary);
            Console.WriteLine($"Average salary: {averageSalary}");
            break;
          case 5:
            return;
          default:
            Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
            break;
        }
      }
    }

    static void PrintRegister(List<Person> register)
    {
      foreach (var person in register)
      {
        Console.WriteLine(person);
      }
    }
  }
}
