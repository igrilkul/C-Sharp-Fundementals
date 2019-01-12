namespace AnimalCentre.Models.Contracts
{
    using System.Collections.Generic;

    public interface IHotel
    {
       //Implement me
       int Capacity { get; }
        IReadOnlyDictionary<string,IAnimal> Animals { get; }
        void Accomodate(IAnimal animal);
        void Adopt(string animalName, string owner);
    }
}
