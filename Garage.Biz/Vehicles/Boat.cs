namespace Garage.Biz.Vehicles
{
    [Serializable]
    public class Boat : Vehicle
    {
        private short length;

        public Boat(string regNr, string color, byte wheelsNr, short length) : base(regNr, color, wheelsNr) => Length = length;

        public short Length { get => length; set => length = value; }
    }
}
