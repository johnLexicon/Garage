using System;
using Garage.Biz;
using Garage.Biz.Vehicles;
using System.Linq;

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
            Console.WriteLine("****All Vehicles****");
            foreach (var vehicle in garageHandler.GetAll())
            {
                Console.WriteLine(vehicle);
            }
            CmdUtils.ShowMessageAndPressKeyToContinue("Press key to continue...");
        }

        internal void ShowVehicleTypesAndCount(GarageHandler<Vehicle> garageHandler)
        {
            var result = garageHandler.GetVehiclesGroupedByType();

            Console.WriteLine("****Vehicles Grouped By Type****");

            foreach (var item in result)
            {
                Console.WriteLine($"Vehicle type: {item.Key.Name}, Count: {item.Count()}");
            }
            CmdUtils.ShowMessageAndPressKeyToContinue("Press key to continue...");
        }
    }
}
