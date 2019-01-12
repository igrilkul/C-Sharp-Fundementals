using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineRadioDatabase
{
    class Program
    {
        

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();

            for (int i = 0; i < n; i++)
            {
                try
                {

                    string[] tokens = Console.ReadLine().Split(';');
                    if (tokens.Length != 3)
                    {
                        throw new InvalidSongException();
                    }

                    string artist = tokens[0];
                    string title = tokens[1];
                    string[] length = tokens[2].Split(':');

                    int minutes;
                    int seconds;

                    if (length.Length != 2 || !int.TryParse(length[0], out minutes)
                        || !int.TryParse(length[1], out seconds))
                    {
                        throw new InvalidSongLengthException();
                    }

                    Song song = new Song(artist, title, minutes, seconds);
                    songs.Add(song);
                    Console.WriteLine("Song added.");

                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);

                }
            }

            Console.WriteLine($"Songs added: {songs.Count}");
            PrintTotalTime(songs);

        }

        public static void PrintTotalTime(List<Song> songs)
        {
            int seconds = songs.Sum(s => s.Seconds);
            int minutes = songs.Sum(s => s.Minutes);
            int hours = 0;
            minutes += seconds / 60;
            hours += minutes / 60;
            seconds = seconds % 60;
            minutes = minutes % 60;

            Console.WriteLine($"Playlist length: {hours}h {minutes}m {seconds}s");
        }
    }

    
}

