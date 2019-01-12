using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    class Worker :Human
    {
        private decimal weekSalary;
        private double workHours;

        public Worker(string firstName,string lastName,decimal weekSalary,double workHours):base(firstName,lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHours = workHours;
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                else this.weekSalary = value;
            }
        }

        public double WorkHours
        {
            get
            {
                return this.workHours;
            }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
                else this.workHours = value;
            }
        }

        public decimal GetHourlyPay
        {
            get
            {
                return this.weekSalary / (decimal)(this.workHours * 5);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"First Name: {base.FirstName}");
            sb.AppendLine($"Last Name: {base.LastName}");
            sb.AppendLine($"Week Salary: {this.WeekSalary:F2}");
            sb.AppendLine($"Hours per day: {this.WorkHours:F2}");
            sb.AppendLine($"Salary per hour: {this.GetHourlyPay:F2}");

            return sb.ToString();
        }
    }
}
