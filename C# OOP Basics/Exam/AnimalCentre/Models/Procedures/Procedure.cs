using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected List<IAnimal> procedureHistory;

        public Procedure()
        {
            this.ProcedureHistory = new List<IAnimal>();
        }

        public List<IAnimal> ProcedureHistory
        {
             get { return this.procedureHistory; }
            protected set { this.procedureHistory = value; }
        }

        public virtual void DoService(IAnimal animal, int procedureTime)
        {
            if(animal.ProcedureTime<procedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }

            animal.ProcedureTime -= procedureTime;
        }
        

        public virtual string History()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.GetType().Name}");
            foreach(var animal in this.ProcedureHistory)
            {
                sb.Append
 ($"\n    Animal type: {animal.GetType().Name} - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
            }

            return sb.ToString();
        }
        
    }
}
