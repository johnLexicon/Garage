using System;
namespace Garage.Biz.Vehicles
{
    public class Car : Vehicle
    {
        private string fuelType;

        public Car(string regNr, string color, byte wheelsNr, string fuelType) : base(regNr, color, wheelsNr) => FuelType = fuelType;

        public string FuelType { get => fuelType; set => fuelType = value; }
    }
}
