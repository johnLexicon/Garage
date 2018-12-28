using System;

namespace Garage.Biz.Vehicles
{
    [Serializable]
    public class Boat : Vehicle
    {
        private int length;

        public Boat(string regNr, string color, int wheelsNr, int length) : base(regNr, color, wheelsNr) => Length = length;

        public int Length { get => length; set => length = value; }
    }
}
