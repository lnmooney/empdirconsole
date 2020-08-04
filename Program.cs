using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFCoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new EFCoreAppContext())
            {
            // provide options for user
            Console.WriteLine("What action would you like to perform: ADD, DELETE, or UPDATE");
            string actionSelected = Console.ReadLine();
                    if(actionSelected.ToLower() == "add")
                    {
                        // add employee data
                        Console.WriteLine("Enter First Name :");
                        string firstNameEntered = Console.ReadLine();

                        Console.WriteLine("Enter Last Name :");
                        string lastNameEntered = Console.ReadLine();

                        Console.WriteLine("Enter Job Title :");
                        string jobTitleEntered = Console.ReadLine();

                        var employee = new Employee {
                            firstName = firstNameEntered,
                            lastName = lastNameEntered,
                            jobTitle = jobTitleEntered
                        };
                        context.Add(employee);
                        context.SaveChanges();
                        Console.WriteLine("You have successfully added employee data");

                    } else if (actionSelected.ToLower() == "delete")
                    {
                        // delete employee data by employee id
                        Console.WriteLine("Enter Employee ID :");
                        int empIdEntered = Convert.ToInt32(Console.ReadLine());

                        var employee = new Employee { empId = empIdEntered };
                        context.Entry(employee).State = EntityState.Deleted;
                        context.SaveChanges();
                        Console.WriteLine("You have successfully deleted employee data");

                    } else if (actionSelected.ToLower() == "update")
                    {
                        // update employee data
                        Console.WriteLine("Enter Employee ID :");
                        int empIdEntered = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter Updated First Name :");
                        string firstNameEntered = Console.ReadLine();

                        Console.WriteLine("Enter Updated Last Name :");
                        string lastNameEntered = Console.ReadLine();

                        Console.WriteLine("Enter Updated Job Title :");
                        string jobTitleEntered = Console.ReadLine();

                        var employee = new Employee { empId = empIdEntered };
                        context.Entry(employee).State = EntityState.Modified;

                        employee.firstName = firstNameEntered;
                        employee.lastName = lastNameEntered;
                        employee.jobTitle = jobTitleEntered;

                        context.SaveChanges();
                        Console.WriteLine("You have successfully updated employee data");
                    }
                    else
                    {
                        Console.WriteLine("Please rerun the app following instructions");
                    }

                // display employee records
                foreach(var employee in context.Employees)
                {
                    Console.WriteLine(employee.empId + " " + employee.firstName.ToLower() + " " + employee.lastName.ToLower() + ": " + employee.jobTitle.ToUpper());
                }
            }
        }
    }
}
