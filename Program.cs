using System;

namespace AverageStudents
{
  class Program
  {
    static void Main(string[] args)
    {
      string userInput = Menu();
      Student[] students = new Student[5];
      int position = 0;

      while (userInput.ToUpper() != "X")
      {
        switch (userInput)
        {
          case "1":
            position = addStudent(students, position);
            break;
          case "2":
            showStudentsGrade(students);
            break;
          case "3":
            showTotalAverage(students);
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }

        userInput = Menu();
      }

    }

    private static string Menu()
    {
      Console.WriteLine();
      Console.WriteLine("========================");
      Console.WriteLine("--- Average Students ---");
      Console.WriteLine("========================");
      Console.WriteLine("\nEnter a option:\n");
      Console.WriteLine("1 - Add a student");
      Console.WriteLine("2 - List students");
      Console.WriteLine("3 - Calculate all average");
      Console.WriteLine("X - To exit");
      Console.WriteLine();

      string userInput = Console.ReadLine();
      return userInput;
    }

    private static int addStudent(Student[] students, int position)
    {
      Console.WriteLine("Student's Name:");
      students[position].Name = Console.ReadLine().ToUpper();
      Console.WriteLine();
      Console.WriteLine("Student's grade");
      students[position].Grade = decimal.Parse(Console.ReadLine());

      position++;
      return position;
    }
    
    private static void showStudentsGrade(Student[] students)
    {
      foreach (var student in students)
      {
        if (!string.IsNullOrEmpty(student.Name))
        {
          Console.WriteLine($"Student: {student.Name} - Grade: {student.Grade}");
        }
      }
    }

    private static void showTotalAverage(Student[] students)
    {
      decimal totalGrade = 0;
      int studentQtd = 0;

      foreach (var student in students)
      {
        if (!string.IsNullOrEmpty(student.Name))
        {
          totalGrade += student.Grade;
          studentQtd++;
        }
      }

      var totalAverage = totalGrade / studentQtd;
      Console.WriteLine($"Total Average is: {totalAverage.ToString("0.##")}");
    }

  }
}
