using System;
using System.Collections.Generic;
using System.Text;

namespace DatabasePeople
{
   public class Person
    {
        private long id;
        private string username;

        public Person(long id, string username)
        {
            this.Id = id;
            this.Username = username;
        }

        public string Username { get => username; set => username = value; }
        public long Id { get => id; set => id = value; }
    }
}
