using System;
using Garage.Biz;
using Garage.Biz.Vehicles;

namespace Garage.Cmd
{
    class Program
    {
        private static readonly string _headMenuPath = "/Users/johnlundgren/Projects/Garage/Garage/TextFiles/main_menu.txt";
        private static GarageHandler<Vehicle> garageHandler;

        static void Main(string[] args)
        {
            bool quit = CreateGarageMenu.Instance.CreateGarageOrQuit(garageHandler);

            if (quit)
            {
                Console.WriteLine("Program ends.");
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
                        //Create Garage
                        break;
                    case "2":
                        //List all parked vehicles
                        break;
                    case "3":
                        //List vehicle types and their count
                        break;
                    case "4":
                        //Add vehicles
                        break;
                    case "5":
                        //Remove vehicles
                        break;
                    case "6":
                        //Find vehicles by reg number
                        break;
                    case "7":
                        //Find vehicles by specific properties and values
                        break;
                    default:
                        Console.WriteLine($"{option} is not and option!!");
                        break;
                }
            } while (!option.Equals("0"));

            Console.WriteLine("Program ends.");
        }
    }
}
