using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
   public  class Smartphone : IBrowsable, ICallable
    {
        private string[] numbers;
        private string[] sites;

        public Smartphone(string[] numbers, string[] sites)
        {
            this.numbers = numbers;
            this.sites = sites;
        }

        public string Browse(string site)
        {
            //ToDo run checks
            if(site.Any(char.IsDigit))
            {
                throw new ArgumentException("Invalid URL!");
            }
            return $"Browsing: {site}!";
        }

        public  string Call(string number)
        {
            //checks
            if(!long.TryParse(number,out long parsedNumber))
            {
                throw new ArgumentException("Invalid number!");
            }
            return $"Calling... {number}";
        }

        public override string ToString()
        {
            StringBuilder numbersString = new StringBuilder();
            StringBuilder sitesString = new StringBuilder();

            foreach(var number in this.numbers)
            {
                try
                {
                    numbersString.AppendLine(Call(number));
                }
                catch(ArgumentException ae)
                {
                    numbersString.AppendLine(ae.Message);
                }
            }

            foreach (var site in this.sites)
            {
                try
                {
                    sitesString.AppendLine(Browse(site));
                }
                catch (ArgumentException ae)
                {
                    sitesString.AppendLine(ae.Message);
                }
            }

            return numbersString.ToString() + sitesString.ToString();
        }
    }
}
