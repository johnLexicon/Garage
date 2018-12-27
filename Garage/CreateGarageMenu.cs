using System;
using Garage.Biz;
using Garage.Biz.Vehicles;

namespace Garage.Cmd
{
    internal class CreateGarageMenu
    {
        private static CreateGarageMenu _instance;
        private readonly string _startMenuPath = "/Users/johnlundgren/Projects/Garage/Garage/TextFiles/start_menu.txt";

        private CreateGarageMenu()
        {
        }

        internal static CreateGarageMenu Instance
        {
            get
            {
                if(_instance is null)
                {
                    _instance = new CreateGarageMenu();
                }
                return _instance;
            }
        }

        private GarageHandler<Vehicle> CreateGarage()
        {
            int capacity = CmdUtils.AskForInteger("Garage capacity: ");
            return new GarageHandler<Vehicle>(garageCapacity: capacity);
        }

        internal bool CreateGarageOrQuit(GarageHandler<Vehicle> garageHandler)
        {
            string startMenu = CmdUtils.ReadTextFile(_startMenuPath);
            string answer = string.Empty;
            
            do
            {
                Console.WriteLine(startMenu);
                answer = CmdUtils.AskForString("Option: ");
            } while (!answer.Equals("0") && !answer.Equals("1"));

            //If user wants to quit
            if(answer.Equals("0"))
            {
                return true;
            }

            garageHandler = CreateGarage();

            if(garageHandler != null)
            {
                Console.WriteLine($"Garage with capacity {garageHandler.GarageCapacity} has been created.");
            }

            return false;
        }
    }
}
