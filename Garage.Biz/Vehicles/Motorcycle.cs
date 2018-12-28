
using System;

namespace Garage.Biz.Vehicles
{
    [Serializable]
    public class Motorcycle : Vehicle
    {
        private int cylinderVol;

        public Motorcycle(string regNr, string color, int wheelsNr, int cylinderVol) : base(regNr, color, wheelsNr) => CylinderVol = cylinderVol;

        public int CylinderVol { get => cylinderVol; set => cylinderVol = value; }
    }
}
