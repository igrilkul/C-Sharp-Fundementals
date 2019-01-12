using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRadioDatabase
{
   public class InvalidSongNameException:InvalidSongException
    {
        public InvalidSongNameException
            (string message="Song name should be between 3 and 20 symbols.")
            :base(message)
        { }
    }
}
