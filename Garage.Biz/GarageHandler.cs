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

        /// <summary>
        /// Finds the vehicles by property values. Uses reflection for comparing the properties in the vehicles.
        /// </summary>
        /// <returns>The vehicles that contain all the properties and their values from the argument propValuePairs</returns>
        /// <param name="propValuePairs">A list with tuples PropertyName and Value pairs</param>
        public List<T> FindVehiclesByPropertyValues(List<Tuple<string, string >> propValuePairs)
        {
            //The vehicles that contain all the properties and it values from the propValuePairs
            List<T> result = new List<T>();


            foreach (var vehicle in garage.Where(v => v != null))
            {
                //Retrieves the names of the properties in the vehicle.
                string[] propertiesInVehicle = vehicle.GetType().GetProperties().Select(pi => pi.Name).ToArray();

                //Checks that all the properties in the propValuePairs exists in the vehicle properties
                bool allIncluded = propValuePairs.Select(pvp => pvp.Item1).All(propertiesInVehicle.Contains);

                //If the vehicle contains all the properties
                if (allIncluded)
                {
                    //Checks that all the properties and their values are equal to the ones in the vehicle.
                    bool sameValues = propValuePairs.All((pvp) =>
                    {
                        var value = vehicle.GetType().GetProperty(pvp.Item1).GetValue(vehicle);
                        return value.ToString().ToLower().Equals(pvp.Item2.ToLower());
                    });
                    //If the vehicle is a match then it is added to the result list.
                    if (sameValues)
                    {
                        result.Add(vehicle);
                    }
                }
            }

            return result;
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
