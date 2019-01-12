using System;
using System.Collections.Generic;
using System.Linq;

namespace RectangleIntersection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<Rectangle> recs = new List<Rectangle>();
            for(int i=0;i<n[0];i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string id = tokens[0];
                double width = double.Parse(tokens[1]);
                double height = double.Parse(tokens[2]);
                double x1 = double.Parse(tokens[3]);
                double y2 = double.Parse(tokens[4]);

                Rectangle rec = new Rectangle(id, width, height, x1, y2);
                recs.Add(rec);
            }

            for(int i=0;i<n[1];i++)
            {
                string[] recsToCheck = Console.ReadLine().Split();
               var recOne = recs.Find(x => x.Id == recsToCheck[0]);
               var recTwo = recs.Find(x => x.Id == recsToCheck[1]);

                Console.WriteLine(recOne.Intersects(recTwo));
            }

            Console.ReadLine();
        }
    }
}
