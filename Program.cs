using System;

namespace PersonarRegister
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Please enter name and salary separated by a space:");
      while (true)
      {
        string[] parts = Console.ReadLine().Split(' ');

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
        Console.WriteLine($"Name: {name}, salary: {salary}");
      }
    }
  }
}
