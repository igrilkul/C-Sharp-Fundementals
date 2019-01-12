using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
   public class Chip:Procedure
    {
        public Chip() : base() { }
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            if (animal.IsChipped)
            {
                throw new ArgumentException($"{animal.Name} is already chipped");
            }

            animal.Happiness -= 5;
            animal.IsChipped = true;
            this.ProcedureHistory.Add(animal);
        }
        public override string History()
        {
            return base.History();
        }
    }
}
