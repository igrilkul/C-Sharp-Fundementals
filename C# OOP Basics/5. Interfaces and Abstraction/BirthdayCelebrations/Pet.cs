using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    class Pet : ICreatureInfo
    { 
        public string Name { get; }
        public string Birthdate { get; }

        public Pet(string name,string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

    }
}
