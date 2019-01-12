using System;
using System.Collections.Generic;

namespace Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            for(; ; )
            {
                try
                {
                    string input = Console.ReadLine();

                    if(input=="Beast!")
                    {
                        goto Foo;
                    }

                    string[] tokens = Console.ReadLine().Split();
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string gender = tokens[2];

                    switch (input)
                    {
                        case "Cat":
                            {
                                Cat cat = new Cat(name, age, gender);
                                animals.Add(cat);
                                break;
                            }
                        case "Dog":
                            {
                                Dog dog = new Dog(name, age, gender);
                                animals.Add(dog);
                                break;
                            }
                        case "Frog":
                            {
                                Frog frog = new Frog(name, age, gender);
                                animals.Add(frog);
                                break;
                            }
                        case "Kitten":
                            {
                                Kitten kitten = new Kitten(name, age);
                                animals.Add(kitten);
                                break;
                            }
                        case "Tomcat":
                            {
                                Tomcat tomcat = new Tomcat(name, age);
                                animals.Add(tomcat);
                                break;
                            }
                        default:
                            {
                                throw new ArgumentException("Invalid input!");
                            }
                       

                    }
                }
                catch(ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                

            
            }

        Foo:
            PrintAnimals(animals);
        }

        public static void PrintAnimals(List<Animal> animals)
        {
            foreach(var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}
