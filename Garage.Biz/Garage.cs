using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Garage.Biz.Vehicles;

namespace Garage.Biz
{
    internal class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private int capacity;
        private int parkedCars;
        private readonly T[] vehiclesCollection;

        /// <summary>
        /// An instance of a Garage that can store Vehicle types or subtypes of Vehicle.
        /// </summary>
        /// <param name="capacity">The maximum number of vehicles the garage can store</param>
        public Garage(int capacity)
        {
            Capacity = capacity;
            vehiclesCollection = new T[capacity];
        }

        /// <summary>
        /// Gets or sets the capacity
        /// </summary>
        /// <value>The capacity</value>
        /// <exception cref="ArgumentOutOfRangeException">If the capacity is zero or negative</exception>
        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "The capacity value must be >= 0");
                }
                capacity = value;
            }
        }

        public int SpacesAvailable { get => Capacity - parkedCars; }

        /// <summary>
        /// Add the specified vehicle.
        /// </summary>
        /// <returns>true if the vehicle was added otherwise false.</returns>
        /// <param name="vehicle">The vehicle to add</param>
        public bool Add(T vehicle)
        {
            if(vehicle == null || SpacesAvailable <= 0)
            {
                return false;
            }

            int index = Array.IndexOf(vehiclesCollection, null);

            this[index] = vehicle;
            parkedCars++;

            return true;
        }

        /// <summary>
        /// Remove the specified item.
        /// </summary>
        /// <returns>true if the item was removed otherwise false</returns>
        /// <param name="vehicle">The vehicle to be removed</param>
        public bool Remove(T vehicle)
        {
            if(vehicle is null)
            {
                return false;
            }
            int index = Array.IndexOf(vehiclesCollection, vehicle);
            if(index != -1)
            {
                this[index] = null;
                return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var v in vehiclesCollection)
            {
                yield return v;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Overridden bracket operator
        /// </summary>
        /// <param name="index">The index to get or set</param>
        public T this[int index]
        {
            get => vehiclesCollection[index];
            private set => vehiclesCollection[index] = value;
        }

        //TODO: Test this!!!
        public override string ToString()
        {
            var sb = new StringBuilder();
            this.ToList<T>().ForEach(v => sb.Append(nameof(v)));
            return sb.ToString();
        }
    }
}
