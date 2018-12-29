using System;
using System.IO;
using Garage.Biz;
using Garage.Biz.Vehicles;

namespace Garage.Cmd
{
    internal class FindVehiclesMenu
    {

        private static FindVehiclesMenu _instance;
        private readonly string _findVehicleMenuPath = Path.Combine(Environment.CurrentDirectory, "TextFiles", "find_vehicle_menu.txt");
        private readonly string _findVehicleMenu;

        private FindVehiclesMenu()
        {
            _findVehicleMenu = CmdUtils.ReadTextFile(_findVehicleMenuPath);
        }

        internal static FindVehiclesMenu Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new FindVehiclesMenu();
                }
                return _instance;
            }
        }

        internal void FindVehicles(GarageHandler<Vehicle> garageHandler)
        {
            string answer = string.Empty;
            do
            {
                Console.WriteLine(_findVehicleMenu);
                answer = CmdUtils.AskForString("Option: ");
                switch (answer)
                {
                    case "1":
                        //Find vehicle by Reg number
                        Vehicle vehicle = FindVehicleByRegNr(garageHandler);
                        Show(vehicle);
                        break;
                    default:
                        Console.WriteLine($"{answer} is not an option!!");
                        break;
                }

            } while (!answer.Equals("0"));
        }

        private void Show(Vehicle vehicle)
        {
            Console.WriteLine(vehicle);
        }

        private Vehicle FindVehicleByRegNr(GarageHandler<Vehicle> garageHandler)
        {
            string regNr = string.Empty;
            regNr = CmdUtils.AskForString("Regnr: ");
            return garageHandler.Find(regNr);
        }
    }
}
