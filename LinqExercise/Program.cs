using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine(numbers.Sum());
            //TODO: Print the Average of numbers
            Console.WriteLine(numbers.Average());
            //TODO: Order numbers in ascending order and print to the console
            Console.WriteLine("Ascending: " + string.Join(", ", numbers.OrderBy(n => n)));
            //TODO: Order numbers in descending order and print to the console
            Console.WriteLine("Descending: " + string.Join(", ", numbers.OrderByDescending(n => n)));
            //TODO: Print to the console only the numbers greater than 6
            Console.WriteLine("Greater than 6: " + string.Join(", ", numbers.Where(n => n > 6)));
            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            var sortNumbers = numbers.OrderBy(n => n);
            int count = 0;
            foreach (var number in sortNumbers)
            {
                if (count < 4)
                {
                    Console.WriteLine(number);
                    count++;
                }
                else
                {
                    break;
                }
            }
            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            numbers[4] = 40;
            Console.WriteLine("Descending with age: " + string.Join(", ", numbers.OrderByDescending(n => n)));
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            employees
                .Where(employee => employee.FirstName.StartsWith("C") || employee.FirstName.StartsWith("S"))
                .OrderBy(employee => employee.FirstName)
                .Select(employee => employee.FullName)
                .ToList()
                .ForEach(Console.WriteLine);
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            employees
                .Where(employee => employee.Age > 26)
                .OrderBy(employee => employee.Age)
                .ThenBy(employee => employee.FirstName)
                .Select(employee => new { employee.FullName, employee.Age })
                .ToList()
                .ForEach(employee => Console.WriteLine($"Name: {employee.FullName}, Age: {employee.Age}"));
            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            Console.WriteLine("Filtered YOE Sum:");
            Console.WriteLine(employees
                .Where(employee => employee.YearsOfExperience <= 10 && employee.Age > 35)
                .Sum(employee => employee.YearsOfExperience));
            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            Console.WriteLine($"Average Years of Experience: {employees.Where(employee => employee.YearsOfExperience <= 10 && employee.Age > 35).Average(employee => employee.YearsOfExperience):F2}");
            //:F2 formats avg to two decimal places

            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Concat(new[] { new Employee("Jesus", "Garcia", 40, 12) }).ToList();
            employees.ForEach(employee => Console.WriteLine($"{employee.FullName}, Age: {employee.Age}, Experience: {employee.YearsOfExperience} years"));

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
