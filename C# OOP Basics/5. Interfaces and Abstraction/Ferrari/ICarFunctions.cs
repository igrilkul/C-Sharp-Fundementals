using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public interface ICarFunctions
    {
        /// <summary>
        /// When the car uses brakes
        /// </summary>
        /// <param name="message">the brake message</param>
        /// <returns>returns brake message</returns>
        string Brakes(string message);

        /// <summary>
        /// When the car uses gas
        /// </summary>
        /// <param name="message">gas message</param>
        /// <returns>the gas message</returns>
        string Gas(string message="Zadu6avam sA!");
    }
}
