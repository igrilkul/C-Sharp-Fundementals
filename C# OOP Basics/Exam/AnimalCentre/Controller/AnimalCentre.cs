using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Hotels;
using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AnimalCentre
{
   public class AnimalCentre
    {
        private AnimalFactory af;
        private Chip chip;
        private DentalCare dentalCare;
        private Fitness fitness;
        private NailTrim nailTrim;
        private Play play;
        private Vaccinate vaccinate;
        private Hotel hotel;
        private Dictionary<string, string> adoptedAnimals;

        public AnimalCentre()
        {
            this.af = new AnimalFactory();
            this.chip = new Chip();
            this.dentalCare = new DentalCare();
            this.fitness = new Fitness();
            this.nailTrim = new NailTrim();
            this.play = new Play();
            this.vaccinate = new Vaccinate();
            this.hotel = new Hotel();
            this.adoptedAnimals = new Dictionary<string, string>();
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            IAnimal animal=af.CreateAnimal(type, name, energy, happiness, procedureTime);
            this.hotel.Accomodate(animal);
            string result =
                $"Animal {name} registered successfully";
            return result;
        }

        public string Chip(string name, int procedureTime)
        {
            IAnimal animal = CheckForAnimal(name);
             
            chip.DoService(animal, procedureTime);
            string result =
                $"{name} had chip procedure";
            return result;
        }

        public string Vaccinate(string name, int procedureTime)
        {
            IAnimal animal = CheckForAnimal(name);
            vaccinate.DoService(animal, procedureTime);
            string result =
                $"{name} had vaccination procedure";
            return result;
        }

        public string Fitness(string name, int procedureTime)
        {
            IAnimal animal = CheckForAnimal(name);
            fitness.DoService(animal, procedureTime);
            string result =
                $"{name} had fitness procedure";
            return result;
        }

        public string Play(string name, int procedureTime)
        {
            IAnimal animal = CheckForAnimal(name);
            play.DoService(animal, procedureTime);
            string result =
                $"{name} was playing for {procedureTime} hours";
            return result;
        }

        public string DentalCare(string name, int procedureTime)
        {
            IAnimal animal = CheckForAnimal(name);
            dentalCare.DoService(animal, procedureTime);
            string result =
                $"{name} had dental care procedure";
            return result;
        }

        public string NailTrim(string name, int procedureTime)
        {
            IAnimal animal = CheckForAnimal(name);
            nailTrim.DoService(animal, procedureTime);
            string result =
                $"{name} had nail trim procedure";
            return result;
        }

        public string Adopt(string animalName, string owner)
        {
            IAnimal animal = CheckForAnimal(animalName);
            hotel.Adopt(animalName, owner);
            string result;
            if(animal.IsChipped)
            {
                result = $"{owner} adopted animal with chip";
            }
            else
            {
                result = $"{owner} adopted animal without chip";
            }
            AddAdoptedAnimalToDictionary(owner, animal.Name);

            return result;

        }

        public string History(string type)
        {
            return GetProcedure(type);
        }

        private string GetProcedure(string type)
        {
            switch(type)
            {
                case "Chip":
                    {
                        return chip.History();
                    }
                case "DentalCare":
                    {
                        return dentalCare.History();
                    }
                case "Fitness":
                    {
                        return fitness.History();
                    }
                case "NailTrim":
                    {
                        return nailTrim.History();
                    }
                case "Play":
                    {
                        return play.History();
                    }
                case "Vaccinate":
                    {
                        return vaccinate.History();
                    }
                default: throw new ArgumentException("No such procedure type");
            }
        }

        private IAnimal CheckForAnimal(string name)
        {
            if(!this.hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            return hotel.Animals[name];
        }

        private void AddAdoptedAnimalToDictionary(string owner,string animalName)
        {
            if(this.adoptedAnimals.ContainsKey(owner))
            {
                adoptedAnimals[owner] += $" {animalName}";
            }
            else
            {
                adoptedAnimals.Add(owner, $" {animalName}");
            }
            
        }

        public void PrintCentre()
        {
            foreach(var kvp in adoptedAnimals.OrderBy(p=>p.Key))
            {
                Console.WriteLine($"--Owner: {kvp.Key}");
                Console.WriteLine($"    - Adopted animals:{kvp.Value}");
            }
        }
    }
}
