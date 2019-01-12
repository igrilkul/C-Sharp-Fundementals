﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    class Citizen : IPerson
    {

        private string name;
        private int age;

        public Citizen(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public int Age
        {
            get{ return this.age; }
            set{ this.age = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
    }
}
