using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
   public class Ferrari : ICarFunctions
    {
        private string model = "488-Spider";
        private string driver;

        public Ferrari(string driver)
        {
            this.Driver = driver;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.model}/{this.Brakes()}/{this.Gas()}/{this.Driver}");
            return sb.ToString();
        }

        public string Brakes(string message = "Brakes!")
        {
            return message;
        }

        public string Gas(string message = "Zadu6avam sA!")
        {
            return message;
        }

        public string Driver { get => driver; set => driver = value; }

       
    }
}
