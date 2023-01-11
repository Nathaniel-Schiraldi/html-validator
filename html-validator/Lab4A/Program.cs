/*
Name: Nathaniel Schiraldi
Student Number: 000855552
File Created Date: Novemeber 10, 2022 
File Last Updated Date: Novemeber 10, 2022 
Program Purpose: View for the Employee class. Gather employee information, sort by name, number, pay rate, hours worked, and gross pay, and display the information to the user.
Statement of Authorship: I, Nathaniel Schiraldi, 000855552 certify that this material is my original work. No other person's work has been used without due acknowledgement.
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace Lab4
{
    /// <summary>
    /// Program class is used as a view to make use of the Employee model as a Console Application. 
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method that controls the flow of the program.
        /// Stores the user's response to the prompt by calling the Prompt() function.
        /// If the user response is null the loop will prompt the user to try again.
        /// Calls the Read() method if a valid input (except 'E') is entered.
        /// Calls the Sort() method for the list using a lambda expression.
        /// Once the Sort() is completed successfully the DisplaySort() method is called.
        /// </summary>
        /// <param name="args">Main method arguments (string[])</param>
        public static void Main(string[] args)
        {
            bool flag = true;
            var employees = new List<Employee>();
            Read(employees);

            while (flag)
            {
                string response = Prompt();

                if (response == null)
                {
                    Console.Write("\nHit a key to try again ... ");
                    Console.ReadKey();
                    continue;
                }
                else if (response.Equals("E"))
                {
                    break;
                }

                else if (response == "NA")
                {
                    employees.Sort((emp1, emp2) => emp1.Name.CompareTo(emp2.Name)); 
                }

                else if (response == "NU")
                {
                    employees.Sort((emp1, emp2) => emp1.Number.CompareTo(emp2.Number));
                }

                else if (response == "R")
                {
                    employees.Sort((emp1, emp2) => emp2.Rate.CompareTo(emp1.Rate));
                }

                else if (response == "H")
                {
                    employees.Sort((emp1, emp2) => emp2.Hours.CompareTo(emp1.Hours));
                }

                else if (response == "G")
                {
                    employees.Sort((emp1, emp2) => emp2.Gross.CompareTo(emp1.Gross));
                }

                DisplaySort(employees);

                Console.Write("\nHit a key to continue ... ");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// The user prompt with various choices the user can choose from.
        /// A list of these choices are NA, NU, R, H, G, and E.
        /// </summary>
        /// <returns>The result the user selected (string)</returns>
        public static string Prompt()
        {
            Console.Clear();

            Console.Write("\n=============== Employee Menu ===============\n" +
                "=============================================\n" +
                "[NA] - Sort by Name (Ascending)\n" +
                "[NU] - Sort by Number (Ascending)\n" +
                "[R] - Sort by Pay Rate (Descending)\n" +
                "[H] - Sort by Hours Worked (Descending)\n" +
                "[G] - Sort by Gross Pay (Descending)\n" +
                "[E] - Exit the Application\n" +
                "=============================================\n" +
                "Choice: ");

            string choice = Console.ReadLine();


            switch (choice.ToUpper())
            {
                case "NA":
                    Console.WriteLine("\nName Sort Table:\n");
                    return choice;

                case "NU":
                    Console.WriteLine("\nNumber Sort Table:\n");
                    return choice;

                case "R":
                    Console.WriteLine("\nRate Sort Table:\n");
                    return choice;

                case "H":
                    Console.WriteLine("\nHours Sort Table:\n");
                    return choice;

                case "G":
                    Console.WriteLine("\nGross Sort Table:\n");
                    return choice;

                case "E":
                    Console.WriteLine("\nClosing Application . . .");
                    return choice;

                default:
                    Console.Error.WriteLine("Error Invalid Choice Entered!");
                    Console.Beep();
                    return null;
            }
        }

        /// <summary>
        /// Opens the data file, reads the data file, declares and initializes the employees, stops reading, and closes the data file.
        /// If the reading is not successful an exception will be caught depending on the sitation (file not found, incorrect data format, or too much data).
        /// </summary>
        /// <param name="employees">The list of Employee objects (List<Employee>)</param>
        public static void Read(List<Employee> employees)
        {
            const string EMPLOYEESDATAFILE = "employees.txt";
            string employeeData;

            try
            {
                FileStream file = new FileStream(EMPLOYEESDATAFILE, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(file);

                while ((employeeData = reader.ReadLine()) != null)
                {
                    string[] employeeDataArr = employeeData.Split(',');

                    Employee newEmployee = new Employee(employeeDataArr[0], int.Parse(employeeDataArr[1]), decimal.Parse(employeeDataArr[2]), double.Parse(employeeDataArr[3]));

                    employees.Add(newEmployee);

                }
                reader.Close();
                file.Close();
            }

            catch (FileNotFoundException ex)
            {
                Console.Error.WriteLine("\tError Occured when Reading File: " + ex.Message);
                Console.Beep();
            }

            catch (FormatException ex)
            {
                Console.Error.WriteLine("\tError Invalid File Format: " + ex.Message);
                Console.Beep();
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.Error.WriteLine("\tError Index Out Of Range: " + ex.Message);
                Console.Beep();
            }
        }


        /// <summary>
        /// Displays the sorted employee list to the console by means of the table and an implicit call to the ToString() function.
        /// </summary>
        /// <param name="employees">The list of Employee objects (List<Employee>)</param>
        public static void DisplaySort(List<Employee> employees)
        {
            Console.WriteLine("_____________________________________________________________");
            Console.WriteLine("Name\t\t   Number     Rate\t Hours\t    Gross");
            Console.WriteLine("_____________________________________________________________");
            for (int i = 0; i < employees.Count; i++)
            {
                Console.Write(employees[i]);
                Console.WriteLine("_____________________________________________________________");

            }
        }

    }
}
