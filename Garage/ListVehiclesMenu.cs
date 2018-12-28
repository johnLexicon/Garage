using System;
using Garage.Biz;
using Garage.Biz.Vehicles;

namespace Garage.Cmd
{
    public class ListVehiclesMenu
    {

        private static ListVehiclesMenu _instance;

        private ListVehiclesMenu()
        {
        }

        internal static ListVehiclesMenu Instance
        {
            get
            {
                if(_instance is null)
                {
                    _instance = new ListVehiclesMenu();
                }
                return _instance;
            }
        }

        internal void ShowAll(GarageHandler<Vehicle> garageHandler)
        {
            foreach (var vehicle in garageHandler.GetAll())
            {
                Console.WriteLine(vehicle);
            }
        }
    }
}
