using System;
namespace Garage.Biz.Vehicles
{
    [Serializable]
    public class Bus : Vehicle
    {
        private byte seatsNr;

        public Bus(string regNr, string color, byte wheelsNr, byte seatsNr) : base(regNr, color, wheelsNr) => SeatsNr = seatsNr;

        public byte SeatsNr { get => seatsNr; set => seatsNr = value; }
    }
}
