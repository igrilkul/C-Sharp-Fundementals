using TheTankGame.Entities.Vehicles;
using TheTankGame.Entities.Vehicles.Contracts;
using TheTankGame.Entities.Miscellaneous;
using TheTankGame.Entities.Miscellaneous.Contracts;
using TheTankGame.Entities.Parts;
using TheTankGame.Entities.Parts.Contracts;

namespace TheTankGame.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class BaseVehicleTests
    {
        string model = "bleh";
        double weight = 30;
        decimal price = 40;
        int attack = 50;
        int defense = 60;
        int hitPoints = 70;
        IAssembler assembler = new VehicleAssembler();

        string partModel = "h";
        double partWeight = 4;
        decimal partPrice = 7;
        int attackMod = 2;

        

        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        public void ShouldThrowExceptionWithInvalidModel(string invalidModel)
        {
            Assert.Throws<ArgumentException>(() => new Vanguard(invalidModel, weight, price, attack, defense, hitPoints, assembler));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-2)]
        public void ShouldThrowExceptionWithInvalidPrice(decimal invalidPrice)
        {
            Assert.Throws<ArgumentException>(() => new Vanguard(model, weight, invalidPrice, attack, defense, hitPoints, assembler));
        }

        [Test]
        [TestCase(-1)]
        public void ShouldThrowWithInvalidAttack(int invalidAttack)
        {
            Assert.Throws<ArgumentException>(() =>
            new Vanguard(model, weight, price, invalidAttack, defense, hitPoints, assembler));

        }

        [Test]
        [TestCase(-1)]
        public void ShouldThrowWithInvalidDefense(int invalidDefense)
        {
            Assert.Throws<ArgumentException>(() =>
           new Vanguard(model, weight, price, attack, invalidDefense, hitPoints, assembler));

        }

        [Test]
        [TestCase(-1)]
        public void ShouldThrowWithInvalidHP(int invalidHP)
        {
            Assert.Throws<ArgumentException>(() =>
           new Vanguard(model, weight, price, attack, defense, invalidHP, assembler));

        }

        [Test]
        public void ShouldAddArsenalPart()
        {
            IPart arsenalPart = new ArsenalPart(partModel, partWeight, partPrice, attackMod);

            IVehicle vehicle = new Vanguard(model, weight, price, attack, defense, hitPoints, assembler);
            vehicle.AddArsenalPart(arsenalPart);
            Assert.That(vehicle.TotalAttack > 50);
        }

        [Test]
        public void ShouldAddShellPart()
        {
            IPart shellPart = new ShellPart(partModel, partWeight, partPrice, attackMod);

            IVehicle vehicle = new Vanguard(model, weight, price, attack, defense, hitPoints, assembler);
            vehicle.AddShellPart(shellPart);

            Assert.That(vehicle.TotalDefense > defense);

        }

        [Test]
        public void ShouldAddEndurancePart()
        {
            IPart endurancePart = new EndurancePart
                (partModel, partWeight, partPrice, attackMod);

            IVehicle vehicle = new Vanguard(model, weight, price, attack, defense, hitPoints, assembler);
            vehicle.AddEndurancePart(endurancePart);

            Assert.That(vehicle.TotalHitPoints > hitPoints);
        }

        [Test]
        public void ToStringShouldReturnProperString()
        {
            IVehicle vehicle = new Vanguard(model, weight, price, attack, defense, hitPoints, assembler);
            string result = "Vanguard - bleh\r\nTotal Weight: 30.000\r\nTotal Price: 40.000\r\nAttack: 50\r\nDefense: 60\r\nHitPoints: 70\r\nParts: None";

            Assert.That(vehicle.ToString(), Is.EqualTo(result));

        }

    }
}