﻿using System;
using System.IO;
using Garage.Biz;
using Garage.Biz.Vehicles;

namespace Garage.Cmd
{
    internal class CreateGarageMenu
    {
        private static CreateGarageMenu _instance;
        private readonly string _startMenuPath = Path.Combine(Environment.CurrentDirectory, "TextFiles", "start_menu.txt");
        private readonly string _startMenu;

        private CreateGarageMenu()
        {
            _startMenu = CmdUtils.ReadTextFile(_startMenuPath);
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

        internal GarageHandler<Vehicle> CreateGarageOrQuit()
        {
            string answer = string.Empty;
            
            do
            {
                Console.WriteLine(_startMenu);
                answer = CmdUtils.AskForString("Option: ");
            } while (!answer.Equals("0") && !answer.Equals("1"));

            //If user wants to quit
            if(answer.Equals("0"))
            {
                CmdUtils.ShowMessageAndPressKeyToContinue("Exits Program. Press key to continue...");
                return null;
            }

            GarageHandler<Vehicle> garageHandler = null;

            while (true)
            {
                try
                {
                    int capacity = CmdUtils.AskForInteger("Garage capacity: ");
                    garageHandler = new GarageHandler<Vehicle>(garageCapacity: capacity);
                    break;
                }
                catch(ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            if (garageHandler != null)
            {
                Console.WriteLine($"Garage with capacity {garageHandler.GarageCapacity} has been created.");
            }


            CmdUtils.ShowMessageAndPressKeyToContinue("Press key to continue...");

            return garageHandler;
        }
    }
}
