using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Hotels
{
    public class Hotel : IHotel
    {
        private const int capacity = 10;
        //Needs to be Ireadonlycollection
        private readonly Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>();
        }



        public int Capacity
        {
            get
            {
                return capacity;
            }
        }
      
        public IReadOnlyDictionary<string, IAnimal> Animals
        {
            get { return this.animals; }
            
        }

        public void Accomodate(IAnimal animal)
        {
            if(this.Animals.Count==capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }
            if(this.Animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }

            this.animals.Add(animal.Name, animal);
        }

        public void Adopt(string animalName, string owner)
        {
            if(!this.Animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            IAnimal animal = this.Animals[animalName];
            animal.Owner = owner;
            animal.IsAdopt = true;
            this.animals.Remove(animalName);
        }
    }
}
