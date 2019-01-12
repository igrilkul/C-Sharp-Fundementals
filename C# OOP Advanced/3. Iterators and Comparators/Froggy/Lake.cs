using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    public class Lake:IEnumerable<int>
    {
        private int[] stones;

        public Lake(int[] stones)
        {
            this.Stones = stones;
        }

        protected int[] Stones { get; set; }

        public IEnumerator<int> GetEnumerator()
        {
            for(int i=0;i<Stones.Length;i+=2)
            {
                yield return this.Stones[i];
            }

            int index;
            if ((Stones.Length-1) % 2 == 0)
            {
                index = Stones.Length - 2;
            }
            else index = Stones.Length-1;

            for(;index>0;index-=2)
            {
                yield return this.Stones[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
