using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
   public class Play : Procedure
    {
        public Play():base() { }
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            animal.Energy -= 6;
            animal.Happiness += 12;
            this.ProcedureHistory.Add(animal);

        }
        public override string History()
        {
            return base.History();
        }
    }
}
