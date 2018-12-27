
using System;

namespace Garage.Biz.Vehicles
{
    [Serializable]
    public class Motorcycle : Vehicle
    {
        private short cylinderVol;

        public Motorcycle(string regNr, string color, byte wheelsNr, short cylinderVol) : base(regNr, color, wheelsNr) => CylinderVol = cylinderVol;

        public short CylinderVol { get => cylinderVol; set => cylinderVol = value; }
    }
}
