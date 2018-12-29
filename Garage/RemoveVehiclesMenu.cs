using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Garage.Biz;
using Garage.Biz.Vehicles;

namespace Garage.Cmd
{
    internal class RemoveVehiclesMenu
    {
        private static RemoveVehiclesMenu _instance;
        private readonly string _removeVehicleMenuPath = Path.Combine(Environment.CurrentDirectory, "TextFiles", "remove_vehicles_menu.txt");
        private readonly string _removeVehicleMenu;

        private RemoveVehiclesMenu()
        {
            _removeVehicleMenu = CmdUtils.ReadTextFile(_removeVehicleMenuPath);
        }

        internal static RemoveVehiclesMenu Instance
        {
            get
            {
                if(_instance is null)
                {
                    _instance = new RemoveVehiclesMenu();
                }
                return _instance;
            }
        }

        internal void RemoveVehicles(GarageHandler<Vehicle> garageHandler)
        {
            string answer = string.Empty;
            do
            {
                Console.WriteLine(_removeVehicleMenu);
                answer = CmdUtils.AskForString("Option: ");
                switch (answer)
                {
                    case "0":
                        //Quit
                        CmdUtils.ShowMessageAndPressKeyToContinue("Exits Remove Vehicles Menu. Press key to continue...");
                        break;
                    case "1":
                        //Remove vehicle by Reg number
                        RemoveVehicleByRegNr(garageHandler);
                        break;
                    default:
                        Console.WriteLine($"{answer} is not an option!!");
                        break;
                }

            } while (!answer.Equals("0"));
        }

        private void RemoveVehicleByRegNr(GarageHandler<Vehicle> garageHandler)
        {
            string regNr = string.Empty;
            regNr = CmdUtils.AskForString("Regnr: ");
            bool isRemoved = garageHandler.RemoveByRegnr(regNr);
            if (isRemoved)
            {
                Console.WriteLine($"Vehicle with reg number {regNr} has been removed from garage.");
            }
            else
            {
                Console.WriteLine($"Was not able to remove vehicle with reg number {regNr}");
            }
            CmdUtils.ShowMessageAndPressKeyToContinue("Press key to continue...");
        }
    }
}
