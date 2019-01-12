using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster
{
    public class Ram : Product
    {
        private const double RamWeight = 0.1;
        public Ram(double price) : base(price,RamWeight)
        {
           
        }
    }
}
