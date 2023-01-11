/*
Name: Nathaniel Schiraldi
Student Number: 000855552
File Created Date: November 10, 2022 
File Last Updated Date: November 10, 2022
Program Purpose: Model for the Employee class. 
Statement of Authorship: I, Nathaniel Schiraldi, 000855552 certify that this material is my original work. No other person's work has been used without due acknowledgement.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    /// <summary>
    /// Employee class is used as a starting class to model employees in a console application.
    /// </summary>
    internal class Employee
    {

        // The employee's first name and last name (string).
        private string name;

        // The employee's number (integer).
        private int number;

        // The employee's rate of pay (decimal).
        private decimal rate;

        // The employee's hours worked (double).
        private double hours;

        // The employee's gross pay (decimal).
        private decimal gross;

        /// <summary>
        /// The employee constructor used to set the values for properties Name, Number, Rate, Hours, and Gross.
        /// Validation is done in the constructor.
        /// </summary>
        /// <param name="name">The employees's full name (string)</param>
        /// <param name="number">The employee's number (integer)</param>
        /// <param name="rate">The employee's rate of pay (decimal)</param>
        /// <param name="hours">The employee's hours worked (double)</param>
        /// <exception cref="FormatException">Exception if the hours worked is not in a correct format of: ## or: ##.# or: ##.##</exception>
        /// <exception cref="FormatException">Exception if the name is not in the correct format of: Firstname Lastname</exception>
        /// <exception cref="FormatException">Exception if the number is not in the correct format of: ######</exception>
        /// <exception cref="FormatException">Exception if the rate is not in the correct format of: ##.##</exception>
        public Employee(string name, int number, decimal rate, double hours)
        {
            string[] fullName = name.Split();
            if ((fullName.Length != 2) || (!fullName[0].ToString().All(character => Char.IsLetter(character))))
            {
                throw new FormatException();
            }
            Name = name;

            if ((number.ToString().Length != 6) || (!number.ToString().All(char.IsDigit)))
            {
                throw new FormatException();
            }
            Number = number;

            if (rate.ToString().Length != 5)
            {
                throw new FormatException();
            }
            else
            {
                if (!rate.ToString().Contains('.'))
                {
                    throw new FormatException();
                }
                else
                {
                    string[] rateBefAft = rate.ToString().Split('.');
                    if ((!rateBefAft[0].ToString().All(numberValue => Char.IsDigit(numberValue))) || (!rateBefAft[1].ToString().All(numberValue => Char.IsDigit(numberValue))))
                    {
                        throw new FormatException();
                    }
                }
            }
            Rate = rate;

            if (hours.ToString().Length < 2 || hours.ToString().Length > 5 || hours.ToString().Length == 3)
            {
                throw new FormatException();
            }

            else if (hours.ToString().Length == 2)
            {
                if (!hours.ToString().All(numberValue => Char.IsDigit(numberValue)))
                {
                    throw new FormatException();
                }
            }
            // Length 4 or 5
            else
            {
                if (!hours.ToString().Contains('.'))
                {
                    throw new FormatException();
                }
                else
                {
                    string[] hoursBefAft = hours.ToString().Split('.');
                    if ((!hoursBefAft[0].ToString().All(numberValue => Char.IsDigit(numberValue))) || (!hoursBefAft[1].ToString().All(numberValue => Char.IsDigit(numberValue))))
                    {
                        throw new FormatException();
                    }
                }
            }
            Hours = hours;


            Gross = Gross;
        }

        /// <summary>
        /// Name property used to set and get the employees's name.
        /// </summary>
        public string Name
        {
            get { return name; }

            set 
            {
                name = value;
            }
        }

        /// <summary>
        /// Number property used to set and get the employees's number.
        /// </summary>
        public int Number
        {
            get { return number; }

            set
            {
                number = value;
            }
        }

        /// <summary>
        /// Rate property used to set and get the employee's rate value.
        /// </summary>
        public decimal Rate
        {
            get { return rate; }

            set
            {
                rate = value;
            }
        }

        /// <summary>
        /// Hour property used to set and get the employee's hour value.
        /// </summary>
        public double Hours
        {
            get { return hours; }

            set
            {
                hours = value;
            }
        }

        /// <summary>
        /// Hour property used to set and get the employee's gross pay value.
        /// </summary>
        public decimal Gross
        {
            get { return gross; }

            set
            {
                if (Hours > 40)
                {
                    gross = (((decimal)Hours - 40) * Rate * (decimal)1.5) + (40 * Rate);
                }

                gross = Rate * (decimal)Hours;
            }
        }

 
        /// <summary>
        /// Displaying a string representation of the employee object with the properties of Name, Number, Rate, Hours, and Gross.
        /// Fixes the gross pay and get hours decimal to two positions. 
        /// </summary>
        /// <returns>The employee's name, number, pay rate, hours worked, and gross pay (string)</returns>
        public override string ToString()
        {
            return $"{Name,-18} {Number,-10} {Rate,-10} {Hours,-10:F} ${Gross,-10:F}\n";
        }

    }
}
