using System;
using System.IO;
using Garage.Biz;
using Garage.Biz.Vehicles;

namespace Garage.Cmd
{
    internal class MainMenu
    {

        private static MainMenu _instance;
        private readonly string _headMenuPath = Path.Combine(Environment.CurrentDirectory, "TextFiles", "main_menu.txt");
        private readonly string _mainMenu;
        private GarageHandler<Vehicle> _garageHandler = null;



        private MainMenu()
        {
            _mainMenu = CmdUtils.ReadTextFile(_headMenuPath);
        }

        internal static MainMenu Instance
        {
            get
            {
                if(_instance is null)
                {
                    _instance = new MainMenu();
                }
                return _instance;
            }
        }

        internal void ShowMenu()
        {
            _garageHandler = CreateGarageMenu.Instance.CreateGarageOrQuit();

            if (_garageHandler is null)
            {
                return;
            }

            string option = null;

            do
            {
                Console.WriteLine(_mainMenu);
                option = CmdUtils.AskForString("Option: ");
                switch (option)
                {
                    case "0":
                        //Quit
                        break;
                    case "1":
                        //List all parked vehicles
                        ListVehiclesMenu.Instance.ShowAll(_garageHandler);
                        break;
                    case "2":
                        //List vehicle types and their count
                        ListVehiclesMenu.Instance.ShowVehicleTypesAndCount(_garageHandler);
                        break;
                    case "3":
                        //Add vehicles
                        AddVehiclesMenu.Instance.AddVehicles(_garageHandler);
                        break;
                    case "4":
                        //Remove vehicles
                        RemoveVehiclesMenu.Instance.RemoveVehicles(_garageHandler);
                        break;
                    case "5":
                        //Find vehicles by reg number
                        break;
                    case "6":
                        //Find vehicles by specific properties and values
                        break;
                    default:
                        Console.WriteLine($"{option} is not and option!!");
                        break;
                }
            } while (!option.Equals("0"));
        }
    }
}
