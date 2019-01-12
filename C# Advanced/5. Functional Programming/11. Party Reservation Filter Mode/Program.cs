using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Party_Reservation_Filter_Mode
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, string[], bool> StartsWith = (n,x) => n.StartsWith(x[1][0]);
            Func<string, string[], bool> EndsWith = (n, x) => n.EndsWith(x[1][0]);
            Func<string,int,bool> Length = (n, x) => n.Length==x;
            Func<string, string[], bool> ContainsChar = (n, x) => n.Contains(x[1][0]); 

            List<string> guestList = Console.ReadLine().Split().ToList();
            List<string[]> filterList = new List<string[]>();
            string input = Console.ReadLine();

            while(input!="Print")
            {
                string[] tokens = input.Split(";");
                string command = tokens[0];

                // filter type, filter parameter
                string[] filter = new string[] { tokens[1], tokens[2] }; 

                if(command=="Add filter")
                {
                    filterList.Add(filter);
                }
                else
                {
                    filterList.RemoveAll(p => p.SequenceEqual(filter));
                   
                }

                input = Console.ReadLine();
            }

            foreach(var filter in filterList)
            {

                if (filter[0] == "Starts with")
                {
                    guestList.RemoveAll(n => StartsWith(n, filter));
                }
                else if (filter[0] == "Ends with")
                {
                    guestList.RemoveAll(n => EndsWith(n, filter));

                }
                else if (filter[0] == "Length")
                {
                    int len = int.Parse(filter[1]);
                    guestList.RemoveAll(n => Length(n, len));
                }
                else
                {
                    guestList.RemoveAll(n => ContainsChar(n, filter));
                }

            }

            if(guestList.Count>0)
            {
                Console.WriteLine(string.Join(" ", guestList));
            }
            else
            {
                Console.WriteLine("Nobody is going to the party");
            }

        }
    }
}
