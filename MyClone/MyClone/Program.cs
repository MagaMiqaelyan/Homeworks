﻿using System;

namespace MyClone
{
    class Program
    {
        static void Main(string[] args)
        {
            var employee = new Employee()
            {
                name = "Armen",
                salary = 150000,
                salarybonus = 30000,
                salaryday = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month),
            };
            var person = new Person()
            {
                firstname = "Mary",
                lastname = "Manukyan",
                age = 35,
                weight = 52.5,
                height = 161.5                
            };
            
            Console.WriteLine("First name: " + person.firstname);
            Console.WriteLine("Last name: " + person.lastname);
            Console.WriteLine("Age: " + person.age);
            Console.WriteLine("Weight: " + person.weight);
            Console.WriteLine("Height: " + person.height);
            
            Person personclone = (Person)person.Clone();
            Console.WriteLine("\nCopy person\n");
            Console.WriteLine("First name: " + personclone.firstname);
            Console.WriteLine("Last name: " + personclone.lastname);
            Console.WriteLine("Age: " + personclone.age);
            Console.WriteLine("Weight: " + personclone.weight);
            Console.WriteLine("Height: " + personclone.height);

            Console.WriteLine("\nName: " + employee.name);
            Console.WriteLine("Salary: " + employee.salary);
            Console.WriteLine("Bonus: " + employee.salarybonus);
            Console.WriteLine("Salary day: " + employee.salaryday);
            
            Employee employeeclone = (Employee)employee.Clone();
            Console.WriteLine("\nCopy employee\n");
            Console.WriteLine("Name: " + employeeclone.name);
            Console.WriteLine("Salary: " + employeeclone.salary);
            Console.WriteLine("Bonus: " + employeeclone.salarybonus);
            Console.WriteLine("Salary day: " + employeeclone.salaryday);
        }
    }
}
