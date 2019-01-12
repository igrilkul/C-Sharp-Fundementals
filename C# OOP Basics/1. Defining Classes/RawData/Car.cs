using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
   public class Car
    {
        private string model;
        private Cargo cargo;
        private Engine engine;
        private List<Tire> tireList;

        public Car(string model, int engineSpeed,int enginePower,int cargoWeight,string cargoType,
            double tire1Pressure,int tire1Age,double tire2Pressure,int tire2Age,double tire3Pressure,
            int tire3Age,double tire4Pressure,int tire4Age)
        {
            this.model = model;
            this.cargo = new Cargo(cargoType, cargoWeight);
            this.engine = new Engine(engineSpeed, enginePower);

            Tire tireOne = new Tire(tire1Age, tire1Pressure);
            Tire tireTwo = new Tire(tire2Age, tire2Pressure);
            Tire tireThree = new Tire(tire3Age, tire3Pressure);
            Tire tireFour = new Tire(tire4Age, tire4Pressure);

            this.tireList=new List<Tire>();
            tireList.Add(tireOne);
            tireList.Add(tireTwo);
            tireList.Add(tireThree);
            tireList.Add(tireFour);
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public Cargo Cargo
        {
            get { return this.cargo; }
            set { this.cargo = value; }
        }

        public Engine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }

        public List<Tire> TireList
        {
            get { return this.tireList; }
            set { this.tireList = value; }
        }
    }
}
