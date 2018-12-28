using System;

namespace Garage.Biz.Vehicles
{
    [Serializable]
    public abstract class Vehicle
    {
        private string regNr;
        private string color;
        private int wheelsNr;

        protected Vehicle(string regNr, string color, int wheelsNr)
        {
            RegNr = regNr;
            Color = color;
            WheelsNr = wheelsNr;
        }

        public string RegNr { get => regNr; set => regNr = value; }
        public string Color { get => color; set => color = value; }
        public int WheelsNr { get => wheelsNr; set => wheelsNr = value; }

        public override string ToString()
        {
            return $"Regnr: {RegNr}, Color: {Color}, WheelsNr: {WheelsNr}";
        }
    }

}
