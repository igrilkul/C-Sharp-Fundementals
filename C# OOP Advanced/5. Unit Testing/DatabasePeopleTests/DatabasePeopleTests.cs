using DatabasePeople;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DatabasePeopleTests
{
    [TestFixture]
    public class DatabasePeopleTests
    {
        Type type = typeof(Database);

        [Test]
        public void CtorShouldInitList()
        {
            Database db = new Database();

            var list = (List<Person>)type
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == "people")
                .GetValue(db);

            int expected = 0;
            Assert.That(list.Count, Is.EqualTo(expected));
        }

        [Test]
        public void AddingPersonToList()
        {
        Database db = new Database();
            long id =123;
            string username = "gosho";

            db.Add(id, username);
            db.Add(345, "pesho");
            var list = (List<Person>)type
               .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
               .First(f => f.Name == "people")
               .GetValue(db);

            int expected = 2;
            Assert.That(list.Count, Is.EqualTo(expected));
        }

        [Test]
        public void AddingSameIdShouldThrowException()
        {
            Database db = new Database();

            db.Add(123, "gosho");

           
            Assert.Throws<InvalidOperationException>(() => db.Add(123, "pesho"));
        }

        [Test]
        public void AddingSameUsernameShouldThrowException()
        {
            Database db = new Database();

            db.Add(123, "pesho");

            Assert.Throws<InvalidOperationException>(() => db.Add(234, "pesho"));
        }

        [Test]
        [TestCase(1234)]
        [TestCase(456)]
        [TestCase(1)]
        public void FindByIdShouldReturnPerson(long id)
        {
            Database db = new Database();
            db.Add(1234, "tosho");
            db.Add(456, "pesho");
            db.Add(1, "sasho");
            db.Add(2, "ivanka");

            var found=db.FindById(id);
            Assert.That(found.Id, Is.EqualTo(id));
        }

        [Test]
        public void FindByIdShouldThrowWhenNotFound()
        {
            Database db = new Database();
            db.Add(1234, "tosho");
            db.Add(456, "pesho");
            db.Add(1, "sasho");
            db.Add(2, "ivanka");

            Assert.Throws<InvalidOperationException>(() => db.FindById(999));
        }

        

        [Test]
        public void FindByIdShouldThrowWhenNegativeInput()
        {
            Database db = new Database();
            db.Add(1234, "tosho");
            db.Add(456, "pesho");
            db.Add(1, "sasho");
            db.Add(2, "ivanka");

            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(-999));
        }

        [Test]
        public void FindByUsernameShouldThrowWhenNoInput()
        {
            Database db = new Database();
            db.Add(1234, "tosho");
            db.Add(456, "pesho");
            db.Add(1, "sasho");
            db.Add(2, "ivanka");

            Assert.Throws<ArgumentNullException>(() => db.FindByUsername(null));
        }

        [Test]
        [TestCase("tosho")]
        [TestCase("pesho")]
        [TestCase("sasho")]
        public void FindByUsernameShouldReturnPerson(string username)
        {
            Database db = new Database();
            db.Add(1234, "tosho");
            db.Add(456, "pesho");
            db.Add(1, "sasho");
            db.Add(2, "ivanka");

            var found = db.FindByUsername(username);
            Assert.That(found.Username, Is.EqualTo(username));
        }

        [Test]
        [TestCase("ToSho")]
        [TestCase("tOSho")]
        [TestCase("IVANKA")]
        public void FindByUsernameShouldBeCaseSensitive(string username)
        {
            Database db = new Database();
            db.Add(1234, "tosho");
            db.Add(456, "pesho");
            db.Add(1, "sasho");
            db.Add(2, "ivanka");

            Assert.Throws<InvalidOperationException>(()=>db.FindByUsername(username));
        }
        [Test]
        public void RemoveById()
        {
            Database db = new Database();

            db.Add(1234, "pesho");
            db.Add(123, "gosho");

            db.Remove(123);

            Assert.Throws<InvalidOperationException>(() => db.FindById(123));
        }

        [Test]
        public void RemoveByUsername()
        {
            Database db = new Database();

            db.Add(1234, "pesho");
            db.Add(123, "gosho");

            db.Remove("gosho");

            Assert.Throws<InvalidOperationException>(() => db.FindByUsername("gosho"));
        }

       
    }
}
