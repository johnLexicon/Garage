using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Garage.Biz.Vehicles;

namespace Garage.Data
{
    public class VehiclesBinary : IVehiclesDAO
    {
        private readonly string fileName = "vehicles.bin";

        public Vehicle[] RetrieveAllVehicles()
        {
            IFormatter formatter = new BinaryFormatter();
            Vehicle[] vehicles;
            using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                vehicles = (Vehicle[])formatter.Deserialize(stream);
            }

            return vehicles;
        }

        public void SaveAllVehicles(Vehicle[] vehicles)
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, vehicles);
            }
        }
    }
}
