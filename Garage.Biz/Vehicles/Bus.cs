using System;
namespace Garage.Biz.Vehicles
{
    [Serializable]
    public class Bus : Vehicle
    {
        private int seatsNr;

        public Bus(string regNr, string color, int wheelsNr, int seatsNr) : base(regNr, color, wheelsNr) => SeatsNr = seatsNr;

        public int SeatsNr { get => seatsNr; set => seatsNr = value; }
    }
}
