using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern
{
    class PersonByAge : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Age - y.Age;
        }
    }
}
