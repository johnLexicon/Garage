using System;
namespace Garage.Biz.Vehicles
{
    [Serializable]
    public class Airplane : Vehicle
    {

        private int enginesNr;

        public Airplane(string regNr, string color, int wheelsNr, int enginesNr) : base(regNr, color, wheelsNr)
        {
            EnginesNr = enginesNr;
        }

        public int EnginesNr { get => enginesNr; set => enginesNr = value; }
    }
}
