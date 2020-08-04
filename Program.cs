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

            /**
            * addEmpData function will prompt user to enter new data for the db
            */
            void addEmpData()
            {
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
            }

            /**
            * updateEmpData function will prompt user which employee record to edit by obtaining empId.
            * It will then prompt user to enter updated employee record data for the db
            */
            void updateEmpData()
            {
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

            /**
            * deleteEmpData function will prompt user which employee record to delete by obtaining empId
            */
            void deleteEmpData()
            {
                // delete employee data by employee id
                Console.WriteLine("Enter Employee ID :");
                int empIdEntered = Convert.ToInt32(Console.ReadLine());

                    var employee = new Employee { empId = empIdEntered };
                    context.Entry(employee).State = EntityState.Deleted;
                    context.SaveChanges();
                    Console.WriteLine("You have successfully deleted employee data");
            }

            // provide options for user
            Console.WriteLine("What action would you like to perform: ADD, DELETE, or UPDATE");
            string actionSelected = Console.ReadLine();
                    if(actionSelected.ToLower() == "add")
                    {
                        // call add function
                        addEmpData();
                    } else if (actionSelected.ToLower() == "update")
                    {
                        // call update function
                        updateEmpData();
                    } else if (actionSelected.ToLower() == "delete")
                    {
                        // call delete function
                        deleteEmpData();
                    }
                    else
                    {
                        Console.WriteLine("Please rerun the app following correct instructions");
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
