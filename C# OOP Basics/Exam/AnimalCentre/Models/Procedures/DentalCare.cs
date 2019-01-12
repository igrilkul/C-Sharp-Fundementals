using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
  public  class DentalCare:Procedure
    {
        public DentalCare() : base() { }
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            animal.Happiness += 12;
            animal.Energy += 10;
            this.ProcedureHistory.Add(animal);

        }
        public override string History()
        {
            return base.History();
        }
    }
}
