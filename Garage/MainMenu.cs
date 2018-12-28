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
        private GarageHandler<Vehicle> _garageHandler = null;


        private MainMenu()
        {
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

            string mainMenu = CmdUtils.ReadTextFile(_headMenuPath);
            string option = null;

            do
            {
                Console.WriteLine(mainMenu);
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

                        break;
                    case "3":
                        //Add vehicles
                        AddVehiclesMenu.Instance.AddVehicles(_garageHandler);
                        break;
                    case "4":
                        //Remove vehicles
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
