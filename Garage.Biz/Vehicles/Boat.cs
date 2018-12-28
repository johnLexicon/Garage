using System;

namespace Garage.Biz.Vehicles
{
    [Serializable]
    public class Boat : Vehicle
    {
        private double length;

        public Boat(string regNr, string color, int wheelsNr, double length) : base(regNr, color, wheelsNr) => Length = length;

        public double Length { get => length; set => length = value; }

        public override string ToString()
        {
            return $"{base.ToString()}, Length: {Length}";
        }
    }
}
