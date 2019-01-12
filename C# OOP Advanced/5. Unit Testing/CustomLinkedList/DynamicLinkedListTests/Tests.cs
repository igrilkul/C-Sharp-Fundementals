using CustomLinkedList;
using NUnit.Framework;
using System;

namespace DynamicLinkedListTests
{
    [TestFixture]
    public class Tests
    {
        private const int InitialCount= 0;

        [Test]
        public void ConstructorShouldSetCountToZero()
        {
            DynamicList<int> list = new DynamicList<int>();

            Assert.That(list.Count, Is.EqualTo(InitialCount),
                "Constructor did not properly set counter to 0 upon initialization");
        }

        [Test]
        public void AddingElementShouldIncreaseCount()
        {
            DynamicList<int> list = new DynamicList<int>();
            int element = 2;
            list.Add(element);
            list.Add(element + 1);

            Assert.That(list.Count, Is.EqualTo(2),"Add did not properly increase counter");
        }

        [Test]
        public void OverloadShouldReturnIndexedElement()
        {
            DynamicList<int> list = new DynamicList<int>();
            int a = 2;
            int b = 3;
            int c = 4;

            list.Add(a);
            list.Add(b);
            list.Add(c);

            Assert.That(list[0], Is.EqualTo(a),"Overload get did not return proper result");
            Assert.That(list[1], Is.EqualTo(b), "Overload get did not return proper result");
            Assert.That(list[2], Is.EqualTo(c), "Overload get did not return proper result");
        }

        

        [Test]
        [TestCase(-1)]
        [TestCase(int.MaxValue)]
        public void OverloadShouldReturnOutOfRangeException(int index)
        {
            DynamicList<int> list = new DynamicList<int>();
            int a = 2;
            int b = 3;
            int c = 4;

            list.Add(a);
            list.Add(b);
            list.Add(c);

            int returnValue = 0;
            Assert.Throws<ArgumentOutOfRangeException>(() => returnValue=list[index],
                "Overload get did not throw proper exception");
        }


        [Test]
        public void OverloadShouldSetIndexedElement()
        {
            DynamicList<int> list = new DynamicList<int>();
            int a = 2;
            int b = 3;
            int c = 4;

            list.Add(a);
            list.Add(b);
            list.Add(c);

            int toSet = 666;
            int toSet2 = 99;
            list[0] = toSet;
            list[2] = toSet2;

            Assert.That(list[0], Is.EqualTo(toSet),
                "Overload does not properly set");
            Assert.That(list[2], Is.EqualTo(toSet2),
                "Overload does not properly set");
        }

        [Test]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(-1)]
        public void OverloadSetShouldThrowException(int index)
        {
            DynamicList<int> list = new DynamicList<int>();
            int a = 2;
            int b = 3;
            int c = 4;

            list.Add(a);
            list.Add(b);
            list.Add(c);

            Assert.Throws<ArgumentOutOfRangeException>(()=>list[index]=5,
                "Overload setter did not throw proper exception");
            
        }

        [Test]
        public void RemoveAtShouldDecreaseCount()
        {
            DynamicList<int> list = new DynamicList<int>();
            int a = 2;
            int b = 3;
            int c = 4;

            list.Add(a);
            list.Add(b);
            list.Add(c);

            list.RemoveAt(1);

            Assert.That(list.Count, Is.EqualTo(2),
                "RemoveAt did not properly decrease counter");
        }

        [Test]
        public void RemoveAtShouldReturnRemoved()
        {
            DynamicList<int> list = new DynamicList<int>();
            int a = 2;
            int b = 3;
            int c = 4;

            list.Add(a);
            list.Add(b);
            list.Add(c);

            int removed=list.RemoveAt(1);

            Assert.That(removed, Is.EqualTo(b),
                "RemoveAt did not return proper result");
        }

        [Test]
        [TestCase(3)]
        [TestCase(5)]
        [TestCase(-1)]
        public void RemoveAtShouldThrowException(int index)
        {
            DynamicList<int> list = new DynamicList<int>();
            int a = 2;
            int b = 3;
            int c = 4;

            list.Add(a);
            list.Add(b);
            list.Add(c);

            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(index),
                "RemoveAt did not throw proper exception");
        }
        

        [Test]
        public void RemoveAtWithEmptyListShouldThrow()
        {
            DynamicList<int> list = new DynamicList<int>();

            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(0),"RemoveAt did not throw " +
                "ArgumentOutOfRangeException when tested with empty list");
        }

        [Test]
        public void RemoveShouldDecreaseCount()
        {
            DynamicList<int> list = new DynamicList<int>();
            int a = 2;
            int b = 3;
            int c = 4;

            list.Add(a);
            list.Add(b);
            list.Add(c);

            list.Remove(b);
            Assert.That(list.Count, Is.EqualTo(2),"Remove did not properly decrease counter");
        }

        [Test]
        public void RemoveShouldReturnRemovedIndex()
        {
            DynamicList<int> list = new DynamicList<int>();
            int a = 2;
            int b = 3;
            int c = 4;

            list.Add(a);
            list.Add(b);
            list.Add(c);

            int removed = list.Remove(b);
            Assert.That(removed, Is.EqualTo(1),"Remove did not return the correct index");
        }

        [Test]
        public void RemoveShouldNotBeInList()
        {
            DynamicList<int> list = new DynamicList<int>();
            int a = 2;
            int b = 3;
            int c = 4;

            list.Add(a);
            list.Add(b);
            list.Add(c);

            list.Remove(b);
            Assert.That(list.Contains(b), Is.False,"Item removed is still in the list");
        }

        [Test]
        public void RemoveShouldReturnMinusOneWhenNotFound()
        {
            DynamicList<int> list = new DynamicList<int>();
            int a = 2;
            int b = 3;
            int c = 4;

            list.Add(a);
            list.Add(b);
            list.Add(c);

           int removed= list.Remove(9090);
            Assert.That(removed, Is.EqualTo(-1),"Remove did not return -1 when item not found");
        }

        [Test]
        public void IndexOfShouldReturnCorrectIndex()
        {
            DynamicList<int> list = new DynamicList<int>();
            int a = 2;
            int b = 3;
            int c = 4;

            list.Add(a);
            list.Add(b);
            list.Add(c);

            Assert.That(list.IndexOf(b), Is.EqualTo(1),"IndexOf did not return the correct index");
        }

        [Test]
        public void IndexOfShouldReturnNegativeWhenNotFound()
        {
            DynamicList<int> list = new DynamicList<int>();
            int a = 2;
            int b = 3;
            int c = 4;

            list.Add(a);
            list.Add(b);
            list.Add(c);

            int d = 66;

            Assert.That(list.IndexOf(d), Is.EqualTo(-1),"IndexOf does not return -1 when item not found");
        }

        [Test]
        public void ContainsShouldReturnTrueIfElementIsInList()
        {
            DynamicList<int> list = new DynamicList<int>();
            int a = 2;
            int b = 3;
            int c = 4;

            list.Add(a);
            list.Add(b);
            list.Add(c);

            

            Assert.That(list.Contains(b), Is.True,"Contains method did not find element properly");
        }

        [Test]
        public void ContainsShouldReturnFalseIfNotInsideList()
        {
            DynamicList<int> list = new DynamicList<int>();
            int a = 2;
            int b = 3;
            int c = 4;

            list.Add(a);
            list.Add(b);
            list.Add(c);

            int d = 66;

            Assert.That(list.Contains(d), Is.False,"Contains method returned true with non-existent item");
        }
       

    }
}
