using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern
{
    public class PersonByName : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if(x.Name.Length - y.Name.Length!=0)
            {
                return x.Name.Length - y.Name.Length;
            }
            else
            {
                return x.Name.ToLower()[0].CompareTo(y.Name.ToLower()[0]);
            }
        }
    }
}
