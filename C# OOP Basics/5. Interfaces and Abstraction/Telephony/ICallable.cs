using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface ICallable
    {
        /// <summary>
        /// Calling number
        /// </summary>
        /// <param name="number">number digits</param>
        /// <returns>Calling number string</returns>
        string Call(string number);
    }
}
