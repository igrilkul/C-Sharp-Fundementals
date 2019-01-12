using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
   public class Fitness : Procedure
    {
        public Fitness() : base() { }
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            animal.Happiness -= 3;
            animal.Energy += 10;
            this.ProcedureHistory.Add(animal);

        }
        public override string History()
        {
            return base.History();
        }
    }
}
