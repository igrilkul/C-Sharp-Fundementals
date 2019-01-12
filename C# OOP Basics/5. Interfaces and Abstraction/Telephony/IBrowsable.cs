using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface IBrowsable
    {
        /// <summary>
        /// Browsing stringSites
        /// </summary>
        /// <param name="site">site string</param>
        /// <returns>Browsing site string</returns>
        string Browse(string site);
    }
}
