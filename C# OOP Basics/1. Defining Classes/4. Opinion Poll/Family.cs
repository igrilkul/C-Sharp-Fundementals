﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> persons = new List<Person>();

       public void AddMember(Person member)
        {
            persons.Add(member);
        }

        public List<Person> GetOlderThanThirties()
        {
            return persons.Where(x => x.Age >= 30).OrderBy(x => x.Name).ToList();
        }
    }
}