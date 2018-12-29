using System;
using System.Collections.Generic;
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
        private readonly string _findVehiclesByPropertiesMenuPath = Path.Combine(Environment.CurrentDirectory, "TextFiles", "find_vehicles_by_properties.txt");
        private readonly string _findVehiclesByPropertiesMenu;

        private FindVehiclesMenu()
        {
            _findVehicleMenu = CmdUtils.ReadTextFile(_findVehicleMenuPath);
            _findVehiclesByPropertiesMenu = CmdUtils.ReadTextFile(_findVehiclesByPropertiesMenuPath);
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
                    case "0":
                        //Quit
                        CmdUtils.ShowMessageAndPressKeyToContinue("Exits Find Vehicles Menu. Press key to continue...");
                        break;
                    case "1":
                        //Find vehicle by Reg number
                        Vehicle vehicle = FindVehicleByRegNr(garageHandler);
                        Show(vehicle);
                        break;
                    case "2":
                        //Find vehicles by properties
                        FindVehiclesByPropertyValues(garageHandler);
                        break;
                    default:
                        Console.WriteLine($"{answer} is not an option!!");
                        break;
                }

            } while (!answer.Equals("0"));
        }

        private void FindVehiclesByPropertyValues(GarageHandler<Vehicle> garageHandler)
        {
            List<Tuple<string, string>> propValuePairs = new List<Tuple<string, string>>();
            //Dictionary<string, string> existingProperties = new Dictionary<string, string>
            //{
            //    {"1", PropertyI}
            //}
            string answer = string.Empty;
            do
            {
                Console.WriteLine(_findVehiclesByPropertiesMenu);
                answer = CmdUtils.AskForString("Option: ");
                switch (answer)
                {
                    case "0":
                        //Quit
                        break;
                    case "1":
                        string propertyName = CmdUtils.AskForString("Name of property: ");
                        string propertyValue = CmdUtils.AskForString("Property value: ");
                        propValuePairs.Add(new Tuple<string, string>(propertyName, propertyValue));
                        break;
                    default:
                        Console.WriteLine($"{answer} is not an option!!");
                        break;
                }
            } while (!answer.Equals("0"));

            List<Vehicle> vehicles = garageHandler.FindVehiclesByPropertyValues(propValuePairs);
        }

        private void Show(Vehicle vehicle)
        {
            if(vehicle is null)
            {
                CmdUtils.ShowMessageAndPressKeyToContinue("No vehicle found with that reg number. Press key to continue...");
                return;
            }
            Console.WriteLine("****Found Vehicle***");
            Console.WriteLine(vehicle);
            CmdUtils.ShowMessageAndPressKeyToContinue("Press key to continue...");
        }

        private Vehicle FindVehicleByRegNr(GarageHandler<Vehicle> garageHandler)
        {
            string regNr = string.Empty;
            regNr = CmdUtils.AskForString("Regnr: ");
            return garageHandler.Find(regNr);
        }
    }
}
