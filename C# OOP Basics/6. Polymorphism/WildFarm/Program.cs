using System;
using System.Collections.Generic;

namespace WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string input;
            while((input = Console.ReadLine())!="End")
            {
                string[] tokens = input.Split();
                Animal animal = MakeAnimal(tokens);
                animals.Add(animal);

                tokens = Console.ReadLine().Split();
                Food food = MakeFood(tokens);

                Console.WriteLine(animal.ProduceSound());

                animal.Eat(food);
            }

            PrintAnimals(animals);
        }



        public static void PrintAnimals(List<Animal> animals)
        {
            foreach(var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        public static Animal MakeAnimal(string[] tokens)
        {
            switch(tokens[0])
            {
                case nameof(Cat):
                    return new Cat(tokens[1], double.Parse(tokens[2]), tokens[3], tokens[4]);
                case nameof(Tiger):
                    return new Tiger(tokens[1], double.Parse(tokens[2]), tokens[3], tokens[4]);
                case nameof(Dog):
                    return new Dog(tokens[1], double.Parse(tokens[2]), tokens[3]);
                case nameof(Mouse):
                    return new Mouse(tokens[1], double.Parse(tokens[2]), tokens[3]);
                case nameof(Owl):
                    return new Owl(tokens[1], double.Parse(tokens[2]), double.Parse(tokens[3]));
                case nameof(Hen):
                    return new Hen(tokens[1], double.Parse(tokens[2]), double.Parse(tokens[3]));
                default: throw new NotImplementedException("No such species");
            }
        }

        public static Food MakeFood(string[] tokens)
        {
            int quantity = int.Parse(tokens[1]);

            switch(tokens[0])
            {
                case nameof(Vegetable):
                    return new Vegetable(quantity);
                case nameof(Fruit):
                    return new Fruit(quantity);
                case nameof(Meat):
                    return new Meat(quantity);
                case nameof(Seeds):
                    return new Seeds(quantity);
                default:
                    throw new NotImplementedException("No such food");
            }
        }
    }
}
