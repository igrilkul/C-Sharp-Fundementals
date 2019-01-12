using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfString
{
    public class Box<T>
        where T:IComparable<T>
    {
        private  T[] items;
        private ulong size;
        private ulong capacity;

        public Box()
        {
            this.size = 0;
            this.capacity = 4;
            this.items = new T[capacity];
        }

        public ulong Size => this.size;
        public ulong Capacity => this.capacity;

        //public T[] Items { get; private set; }

        public void Swap(ulong index1,ulong index2)
        {
            T tempVar = this.items[index1];
            this.items[index1] = this.items[index2];
            this.items[index2] = tempVar;
        }

        public int GreaterThan(T inputItem)
        {
            int count = 0;

           for(ulong i=0;i<size;i++)
            {
                if(items[i].CompareTo(inputItem)>0)
                {
                    count++;
                }
            }

            return count;
        }

        public void Add(T element)
        {
            if (size == capacity)
            {
                IncreaseCapacity();
            }
            this.items[size++] = element;
        }

        private void IncreaseCapacity()
        {
            var cloning = new T[capacity];
            this.items.CopyTo(cloning, 0);

            this.capacity *= 2;
            this.items = new T[capacity];
            cloning.CopyTo(this.items, 0);
        }

        public T Remove(ulong index)
        {
            if(index<0 || index>=size)
            {
                throw new IndexOutOfRangeException("Current index is out of range");
            }

            T value = items[index];

            var cloning = new T[size-1];
            ulong cloneCounter = 0;

            for(ulong i=0;i<size;i++)
            {
                if(i==index)
                {
                    continue;
                }
                cloning[cloneCounter++] = items[i];
            }

            this.items = new T[capacity];
            cloning.CopyTo(items, 0);
            size--;
            return value;
        }

        public bool Contains(T element)
        {
            for(ulong i=0;i<size;i++)
            {
                if(items[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public  T Max()
        {
            T max=items[0];
            for(ulong i=0;i<size;i++)
            {
                if (items[i].CompareTo(max)>0)
                {
                    max = items[i];
                }
            }
            return max;
        }

        public T Min()
        {
            T min = items[0];
            for (ulong i = 0; i < size; i++)
            {
                if (items[i].CompareTo(min) < 0)
                {
                    min = items[i];
                }

            }
            return min;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for(ulong i=0;i<size;i++)
            {
                var item = items[i];
                sb.AppendLine($"{item}");
            }

            return sb.ToString();
        }

        public void Sort()
        {
            bool isSorted = false;

            while(!isSorted)
            {
                isSorted = true;

                for(ulong i=1;i<size;i++)
                {
                    // b < a => swap
                    if(items[i].CompareTo(items[i-1])<0)
                    {
                        isSorted = false;
                        Swap(i, i - 1);
                    }
                }
            }
        }
    }
}
