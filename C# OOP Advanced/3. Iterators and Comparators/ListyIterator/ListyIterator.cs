using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
   public class ListyIterator<T> : IEnumerable<T>
    {
        private T[] elements;
        private int index;

        public ListyIterator(T[] elements)
        {
            this.elements = elements;
            this.index = 0;
        }

        public bool Move()
        {
            if (!HasNext())
            {
                return false;
            }
            else
            {
                index++;
                return true;
            }
        }

        public void Print()
        {
            if(elements.Length==0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(elements[index]);
        }

        public void PrintAll()
        {
            if (elements.Length == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(string.Join(" ",elements));
        }

        public bool HasNext()
        {
            if (index + 1 <= this.elements.Length - 1)
            {
                return true;
            }
            else return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
           for(int i=0;i<this.elements.Length-1;i++)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
