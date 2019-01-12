using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
   public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> carList = new List<Car>();

            for(int i=0;i<n;i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string model = tokens[0];
                int engineSpeed = int.Parse(tokens[1]);
                int enginePower = int.Parse(tokens[2]);
                int cargoWeight = int.Parse(tokens[3]);
                string cargoType = tokens[4];
                double tire1Pressure = double.Parse(tokens[5]);
                int tire1Age = int.Parse(tokens[6]);
                double tire2Pressure = double.Parse(tokens[7]);
                int tire2Age = int.Parse(tokens[8]);
                double tire3Pressure = double.Parse(tokens[9]);
                int tire3Age = int.Parse(tokens[10]);
                double tire4Pressure = double.Parse(tokens[11]);
                int tire4Age = int.Parse(tokens[12]);

                Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, 
                    tire1Pressure, tire1Age, tire2Pressure, tire2Age, tire3Pressure, tire3Age, tire4Pressure, tire4Age);
                carList.Add(car);
            }

            string typeOfCargo = Console.ReadLine();

            if(typeOfCargo=="flamable")
            {
                foreach (var car in carList
                    .Where(x => x.Cargo.Type == typeOfCargo && x.Engine.Power>250))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else
            {
                foreach (var car in carList
                    .Where(x => x.Cargo.Type == typeOfCargo && x.TireList.Exists(y=>y.Pressure<1)))
                {
                    Console.WriteLine(car.Model);
                }
            }

            Console.ReadLine();

            
        }
    }
}
