using System;
using System.Collections.Generic;
using System.Text;

namespace _5._Date_Modifier
{
    public class DateModifier
    {
        
        public int DifferenceCalculator(string firstDate,string secondDate)
        {
            DateTime dateOne = DateTime.Parse(firstDate);
            DateTime dateTwo = DateTime.Parse(secondDate);

            return Math.Abs((dateOne-dateTwo).Days);
        }
    }
}
