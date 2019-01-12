using System;
using System.Collections.Generic;

namespace CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Engine> engineList = new List<Engine>();
            List<Car> carList = new List<Car>();

            for(int i=0;i<n;i++)
            {
                string[] tokens = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string engineModel = tokens[0];
                int enginePower = int.Parse(tokens[1]);

                if(tokens.Length==3)
                {
                    if(int.TryParse(tokens[2],out int displacement))
                    {
                        Engine engine = new Engine(engineModel, enginePower, displacement);
                        engineList.Add(engine);

                    }
                    else
                    {
                        string efficiency = tokens[2];
                        Engine engine = new Engine(engineModel, enginePower, efficiency);
                        engineList.Add(engine);

                    }

                }
                else if(tokens.Length==4)
                {
                    int displacement = int.Parse(tokens[2]);
                    string efficiency = tokens[3];
                    Engine engine = new Engine(engineModel, enginePower, displacement, efficiency);
                    engineList.Add(engine);

                }
                else
                {
                    Engine engine = new Engine(engineModel, enginePower);
                    engineList.Add(engine);
                }
            }

            n = int.Parse(Console.ReadLine());

            for(int i=0;i<n;i++)
            {
                string[] tokens = Console.ReadLine().Split(new string[] { " " },StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[0];
                string engine = tokens[1];
                var carEngine = engineList.Find(x => x.Model == engine);

                if(tokens.Length==3)
                {
                    if(int.TryParse(tokens[2],out int weight))
                    {
                        Car car = new Car(model, carEngine, weight);
                        carList.Add(car);
                    }
                    else
                    {
                        string color = tokens[2];
                        Car car = new Car(model, carEngine, color);
                        carList.Add(car);

                    }
                }
                else if(tokens.Length==4)
                {
                    int weight = int.Parse(tokens[2]);
                    string color = tokens[3];
                    Car car = new Car(model, carEngine, weight, color);
                    carList.Add(car);

                }
                else
                {
                    Car car = new Car(model, carEngine);
                    carList.Add(car);
                }
            }

            foreach(var car in carList)
            {
                car.ToString();
            }
            Console.ReadLine();
        }
    }
}
