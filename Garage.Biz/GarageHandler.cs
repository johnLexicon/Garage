using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public int GarageCapacity { get => garage.Capacity; }

        public int SpacesAvailable { get => garage.SpacesAvailable; }

        public bool Add(T vehicle)
        {
            if(garage.SpacesAvailable == 0)
            {
                throw new GarageIsFullException("The garage is already full.");
            }

            return garage.Add(vehicle);
        }

        public bool Remove(T vehicle)
        {
            return garage.Remove(vehicle);
        }

        public bool RemoveByRegnr(string regNr)
        {
            T vehicle = Find(regNr);
            if(vehicle is null)
            {
                return false;
            }
            return Remove(vehicle);
        }

        public T Find(string regNr)
        {
            var result = garage.Where(v => v != null);
            return result.FirstOrDefault(v => v.RegNr.ToLower().Equals(regNr.ToLower()));
        }

        //TODO: Try to solve this!!!
        public IEnumerable<T> FindVehiclesByPropertyValues(List<Tuple<string, string >> props)
        {

            List<string> found = new List<string>();

            foreach(var vehicle in garage)
            {
                PropertyInfo pInfo = vehicle.GetType().GetProperty("Color");
                if(pInfo != null)
                {
                    var value = pInfo.GetValue(vehicle);
                    var content = "whatever";
                }
            }

            return garage;
        }

        //TODO: Maybe change this to enumerable instead of returning a list.
        public ICollection<T> GetAll()
        {
            return garage.Where(v => v != null).ToList();
        }

        public IEnumerable<IGrouping<Type, T>>  GetVehiclesGroupedByType()
        {
            var result = garage.Where(v => v != null);
            return result.GroupBy(v => v.GetType());
        }

        public override string ToString()
        {
            return garage.ToString();
        }
    }
}
