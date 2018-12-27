using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool Remove(T vehicle)
        {
            return garage.Remove(vehicle);
        }

        public T Find(string regNr)
        {
            return garage.FirstOrDefault(v => v.RegNr.Equals(regNr));
        }

        //TODO: Maybe change this to enumerable instead of returning a list.
        public ICollection<T> GetAll()
        {
            return garage.ToList();
        }

        public IEnumerable<IGrouping<Type, T>>  GetVehiclesGroupedByType()
        {
            return garage.GroupBy(v => v.GetType());
        }

        public override string ToString()
        {
            return garage.ToString();
        }
    }
}
