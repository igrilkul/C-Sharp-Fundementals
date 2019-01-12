using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre
{
   public class AnimalFactory
    {
        public IAnimal CreateAnimal(string type,string name,int energy,int happiness,int procedureTime)
        {
            switch(type)
            {
                case "Cat":
                    {
                        IAnimal cat = new Cat(name, energy, happiness, procedureTime);
                        return cat;
                    }
                case "Dog":
                    {
                        IAnimal dog = new Dog(name, energy, happiness, procedureTime);
                        return dog;
                    }
                case "Lion":
                    {
                        IAnimal lion = new Lion(name, energy, happiness, procedureTime);
                        return lion;
                    }
                case "Pig":
                    {
                        IAnimal pig = new Pig(name, energy, happiness, procedureTime);
                        return pig;
                    }
                default: throw new InvalidOperationException("No such animal type");
            }
        }
    }
}
