using DatabaseExample;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace DatabaseTests
{
    [TestFixture]
    public class DatabaseTests
    {
        private const int Capacity = 16;
        private const int initialIndex = 0;

        Type type = typeof(Database);

        [Test]
        public void EmptyConstructorShouldInitData()
        {
            Database db = new Database();

            var field = (int[])type
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == "storedInts")
                .GetValue(db);

            var size = field.Length;
            Assert.That(size, Is.EqualTo(Capacity));
          
        }

        [Test]
        public void IndexOfEmptyDbShouldBeZero()
        {
            Database db = new Database();

            var index = (int)type
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == "index")
                .GetValue(db);

            
            Assert.That(index, Is.EqualTo(initialIndex));
        }

        [Test]
        public void NonEmptyConstructor()
        {
            int[] initialInts = new int[] { 1, 2, 3, 4, 5 };
            Database db = new Database(initialInts);

            var field = (int[])type
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == "storedInts")
                .GetValue(db);


            var size = field.Length;
            Assert.That(size, Is.EqualTo(Capacity));
            
        }

       

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 69})]
        [TestCase(new int[] { 2,6,9})]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void CtorShouldSetIndexToZero(int[] values)
        {
            Database db = new Database(values);

            int expectedIndex = values.Length;

            var index = (int)type
                .GetFields(BindingFlags.Instance|BindingFlags.NonPublic)
                .First(f => f.Name == "index").GetValue(db);
            Assert.That(index, Is.EqualTo(expectedIndex));
        }


        [Test]
        public void InitializeWithArrayBiggerThan16()
        {
            int[] initialInts = new int[] 
            { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            Assert.Throws<InvalidOperationException>(()=>new Database(initialInts));
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1,2,3})]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void AddShouldUpdateIndex(int[] values)
        {
            Database db = new Database(values);
           
            db.Add(3);
            var index = (int)type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
               .First(f => f.Name == "index").GetValue(db);
            int expected = values.Length + 1;

            Assert.That(index, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldThrowInvalidOperationsExceptionWhenAddingToFullArray()
        {
            int[] initialInts = new int[]
           { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            Database db = new Database(initialInts);


            Assert.Throws<InvalidOperationException>(() => db.Add(3));
        }

        [Test]
        [TestCase(new int[] { 1})]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void RemoveShouldSetToZeroAndUpdateIndex(int[] values)
        {
            Database db = new Database(values);

            db.Remove();

            var index = (int)type
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == "index")
                .GetValue(db);

            var expected = values.Length - 1;

            Assert.That(index, Is.EqualTo(expected));
            Assert.That(db.StoredInts[index], Is.EqualTo(0));
        }

        [Test]
        public void RemoveShouldThrowIOperationsExceptionWhenEmpty()
        {
            Database db = new Database(new int[] { });

            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        [Test]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void FetchShouldReturnArrayWithValuesOnly(int[] values)
        {
            Database db = new Database(values);

            var returned = db.Fetch();
            var returnedLength = returned.Length;
            var expected = values.Length;

            Assert.That(returnedLength, Is.EqualTo(expected));
        }
    }
}
