using System;

namespace PersonarRegister
{
  class Program
  {
    static void Main(string[] args)
    {
      var register = GetRegister();
      if (register.Count == 0)
      {
        Console.WriteLine("No data entered.");
        return;
      }
      PerformOperations(register);
    }

    static List<Person> GetRegister()
    {
      Console.WriteLine("Enter each entry (name and salary) on a new line.");
      Console.WriteLine("Enter empty line to finish.");

      var register = new List<Person>();
      string input;

      while (!string.IsNullOrEmpty(input = Console.ReadLine()))
      {
        string[] parts = input.Split(' ');

        if (parts.Length < 2)
        {
          Console.WriteLine("Not enough data");
          continue;
        }

        if (!int.TryParse(parts[^1], out int salary) || salary < 0)
        {
          Console.WriteLine("Salary should be a valid positive number.");
          continue;
        }
        string name = string.Join(" ", parts[..^1]);

        register.Add(new Person(name, salary));
      }
      return register;
    }
    static void PerformOperations(List<Person> register)
    {
      while (true)
      {
        ShowMenu();

        if (!int.TryParse(Console.ReadLine(), out int choice))
        {
          Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
          continue;
        }

        switch (choice)
        {
          case 1:
            PrintRegister(register.OrderBy(p => p.Name));
            break;
          case 2:
            PrintRegister(register.OrderBy(p => p.Salary));
            break;
          case 3:
            var matches = SearchByName(register);
            if (matches.Any()) PrintRegister(matches);
            else Console.WriteLine("No matches found.");
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

        Console.WriteLine();
      }
    }

    static void ShowMenu()
    {
      Console.WriteLine("1. Print register sorted by name");
      Console.WriteLine("2. Print register sorted by salary");
      Console.WriteLine("3. Search for a person by name");
      Console.WriteLine("4. Print average salary");
      Console.WriteLine("5. Exit");
    }


    static void PrintRegister(IEnumerable<Person> register)
    {
      foreach (var person in register)
      {
        Console.WriteLine(person);
      }
    }

    static IEnumerable<Person> SearchByName(List<Person> register)
    {
      Console.WriteLine("Enter the name to search for:");
      string searchName = Console.ReadLine();
      return register.Where(p => p.Name.Contains(searchName, StringComparison.OrdinalIgnoreCase));
    }
  }
}
