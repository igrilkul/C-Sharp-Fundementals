using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRadioDatabase
{
   public class Song
    {
        private string artist;
        private string title;
        private int minutes;
        private int seconds;

        public Song(string artist, string title, int minutes,int seconds)
        {
            this.Artist = artist;
            this.Title = title;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }

        public string Artist
        {
            get
            {
                return this.artist;
            }
            set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidArtistNameException();
                }
                else this.artist = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidSongNameException();
                }
                else this.title = value;
            }
        }

        public int Minutes
        {
            get
            {
                return this.minutes;
            }
            set
            {
                if (value < 0 || value > 14)
                {
                    throw new InvalidSongMinutesException();
                }
                else this.minutes = value;
            }
        }

        public int Seconds
        {
            get
            {
                return this.seconds;
            }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new InvalidSongSecondsException();
                }
                else this.seconds = value;
            }
        }
    }
}
