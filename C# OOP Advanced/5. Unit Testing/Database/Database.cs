using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseExample
{
    public class Database
    {
        private int[] storedInts;
        private const int capacity = 16;
        private int index;

        public Database()
        {
            this.storedInts = new int[capacity];
            index = 0;
        }

        public Database(int[] initialInts)
        {
            this.storedInts = new int[capacity];
            if (initialInts.Length <= 16)
            {
                Array.Copy(initialInts, this.StoredInts, initialInts.Length);
                this.index = initialInts.Length;
            }
            else throw new InvalidOperationException("Length must be 16 or less");
        }

        public int[] StoredInts { get => storedInts; set => storedInts = value; }

        public void Remove()
        {
            if(index==0)
            {
                throw new InvalidOperationException("Array is empty");
            }
            this.storedInts[index-1] = 0;
            index--;
        }

        public int[] Fetch()
        {
            int[] result = new int[index];
            Array.Copy(this.storedInts, result, index);

            return result;
        }

        public void Add(int element)
        {
            if (index < capacity)
            {
                StoredInts[index] = element;
                index++;
            }
            else throw new InvalidOperationException("Capacity at full");
        }
    }
}
