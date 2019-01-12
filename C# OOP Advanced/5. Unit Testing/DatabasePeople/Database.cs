using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabasePeople
{
   public class Database
    {
        private List<Person> people;

        internal List<Person> People { get => people; set => people = value; }

        public Database()
        {
            this.People = new List<Person>();
        }


        public void Add(long id,string username)
        {
            if(People.Exists(p=>p.Id==id || p.Username==username))
            {
                throw new InvalidOperationException("Id/Username already used");
            }
            else
            {
                Person person = new Person(id,username);
                People.Add(person);
            }
        }

        

       

        public Person FindByUsername(string username)
        {
            if(username==null)
            {
                throw new ArgumentNullException("Please enter a username");
            }else if(!People.Exists(p => p.Username == username))
            {
                throw new InvalidOperationException("No user with username present in database");
            }else
            {
                var toReturn = People.Find(p => p.Username == username);

                return toReturn;
            }

        }

        public Person FindById(long id)
        {
            if (id<0)
            {
                throw new ArgumentOutOfRangeException("Please enter a positive Id");
            }
            else if (!People.Exists(p => p.Id == id))
            {
                throw new InvalidOperationException("No user with id present in database");
            }
            else
            {
                var toReturn = People.Find(p => p.Id == id);

                return toReturn;
            }

        }

        public void Remove(string username)
        {
                var toRemove = FindByUsername(username);
                People.Remove(toRemove);
        }


        public void Remove(long id)
        {
            var toRemove = FindById(id);
            People.Remove(toRemove);
        }       
    }
}
