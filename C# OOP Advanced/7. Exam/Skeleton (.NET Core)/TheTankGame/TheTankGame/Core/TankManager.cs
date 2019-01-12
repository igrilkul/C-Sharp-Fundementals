﻿namespace TheTankGame.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Entities.Miscellaneous;
    using Entities.Vehicles;
    using Entities.Parts;
    using Entities.Parts.Contracts;
    using Entities.Vehicles.Contracts;
    using Utils;

    using TheTankGame.Entities.Parts.Factories.Contracts;
    using TheTankGame.Entities.Vehicles.Factories.Contracts;
    using System;
    using System.Reflection;

    public class TankManager : IManager
    {
        private readonly IDictionary<string, IVehicle> vehicles;
        private readonly IDictionary<string, IPart> parts;
        private readonly IList<string> defeatedVehicles;
        private readonly IBattleOperator battleOperator;

        //hmmm
        private readonly IVehicleFactory vehicleFactory;
        private readonly IPartFactory partFactory;

        public TankManager(IBattleOperator battleOperator,
            IVehicleFactory vehicleFactory,IPartFactory partFactory)
        {
            this.battleOperator = battleOperator;
            this.vehicleFactory = vehicleFactory;
            this.partFactory = partFactory;

            this.vehicles = new Dictionary<string, IVehicle>();
            this.parts = new Dictionary<string, IPart>();
            this.defeatedVehicles = new List<string>();
        }

        public string AddVehicle(IList<string> arguments)
        {
            string vehicleType = arguments[0];
            string model = arguments[1];
            double weight = double.Parse(arguments[2]);
            decimal price = decimal.Parse(arguments[3]);
            int attack = int.Parse(arguments[4]);
            int defense = int.Parse(arguments[5]);
            int hitPoints = int.Parse(arguments[6]);

            IVehicle vehicle = vehicleFactory.CreateVehicle(vehicleType, model,
                weight, price, attack, defense, hitPoints);

            if (vehicle != null)
            {
                this.vehicles.Add(vehicle.Model, vehicle);
            }

            return string.Format(
                GlobalConstants.VehicleSuccessMessage,
                vehicleType,
                vehicle.Model);
        }

        public string AddPart(IList<string> arguments)
        {
            string vehicleModel = arguments[0];
            string partType = arguments[1];
            string model = arguments[2];
            double weight = double.Parse(arguments[3]);
            decimal price = decimal.Parse(arguments[4]);
            int additionalParameter = int.Parse(arguments[5]);

            IPart part = partFactory.CreatePart(partType,model,weight,price,
                additionalParameter);

            
            //Type type = Assembly
            //    .GetCallingAssembly()
            //    .GetTypes().First(t=>t.Name=="VehicleAssembler");

            //MethodInfo method = type
            //    .GetMethods()
            //    .First(m => m.Name == "Add" + partType + "Part");

            //Object[] args ={ part};
            IVehicle vehicle =this.vehicles[vehicleModel];
            //method.Invoke(type, args);
            
            switch(partType)
            {
                case "Arsenal":
                    {
                        vehicle.AddArsenalPart(part);
                        break;
                    }
                case "Shell":
                    {
                        vehicle.AddShellPart(part);
                        break;
                    }
                case "Endurance":
                    {
                        vehicle.AddEndurancePart(part);
                        break;
                    }
            }
           // this.vehicles[vehicleModel].AddArsenalPart(part);

            return string.Format(
                GlobalConstants.PartSuccessMessage,
                partType,
                part.Model,
                vehicleModel);
        }

        public string Inspect(IList<string> arguments)
        {
            string model = arguments[0];

            
            string result = this.vehicles.ContainsKey(model) ?
                this.vehicles[model].ToString() :
                this.parts[model].ToString();

            return result;
        }

        public string Battle(IList<string> arguments)
        {
            string attackerVehicleModel = arguments[0];
            string targetVehicleModel = arguments[1];

            string winnerVehicleModel = this.battleOperator
                .Battle(this.vehicles[attackerVehicleModel],
                this.vehicles[targetVehicleModel]);

            if (winnerVehicleModel.Equals(attackerVehicleModel))
            {
                this.vehicles[targetVehicleModel]
                    .Parts
                    .ToList()
                    .ForEach(x => this.parts.Remove(x.Model));

                this.vehicles.Remove(targetVehicleModel);
                this.defeatedVehicles.Add(targetVehicleModel);
            }
            else
            {
                this.vehicles[attackerVehicleModel]
                    .Parts
                    .ToList()
                    .ForEach(x => this.parts.Remove(x.Model));

                this.vehicles.Remove(attackerVehicleModel);
                this.defeatedVehicles.Add(attackerVehicleModel);
            }

            return string.Format(
                GlobalConstants.BattleSuccessMessage,
                attackerVehicleModel,
                targetVehicleModel,
                winnerVehicleModel);
        }

        public string Terminate(IList<string> arguments)
        {
            StringBuilder finalResult = new StringBuilder();

            finalResult.Append("Remaining Vehicles: ");

            if (this.vehicles.Count > 0)
            {
                finalResult
                    .AppendLine(string.Join(", ",
                        this.vehicles
                            .Values
                            .Select(v => v.Model)
                            .ToArray()));
            }
            else
            {
                finalResult.AppendLine("None");
            }

            finalResult.Append("Defeated Vehicles: ");

            if (this.defeatedVehicles.Count > 0)
            {
                finalResult
                    .AppendLine(string.Join(", ", this.defeatedVehicles));
            }
            else
            {
                finalResult
                    .AppendLine("None");
            }
            int usedParts = this.vehicles.Sum(v => v.Value.Parts.Count());
            finalResult
                .Append("Currently Used Parts: ")
                .Append(usedParts);

            return finalResult.ToString();
        }
    }
}