using System;
using System.Linq;

namespace StreetLights
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lights = Console.ReadLine().Split();
            TrafficLight[] trafficLights = new TrafficLight[lights.Length];

            for (int i=0;i<lights.Length;i++)
            {
                trafficLights[i] = new TrafficLight(lights[i]);
            }

            int n = int.Parse(Console.ReadLine());
            for(int i=0;i<n;i++)
            {
                foreach(var light in trafficLights)
                {
                    light.Update();
                }
                Console.WriteLine(string.Join(" ",trafficLights.Select(t=>t.CurrentColor)));
            }
        }
    }
}
