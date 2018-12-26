
using Garage.Biz.Vehicles;

namespace Garage.Biz
{
    public class GarageHandler<T> where T : Vehicle
    {
        private readonly Garage<T> garage;

        public GarageHandler(int garageCapacity)
        {
            garage = new Garage<T>(garageCapacity);
        }

        public bool Add(T vehicle)
        {
            return garage.Add(vehicle);
        }
    }
}
