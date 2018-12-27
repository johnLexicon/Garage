using System;
using Garage.Biz;
using Garage.Biz.Vehicles;

namespace Garage.Cmd
{
    internal class CreateGarageMenu
    {
        private static CreateGarageMenu _instance;

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

        internal GarageHandler<Vehicle> CreateGarage()
        {
            int capacity = CmdUtils.AskForInteger("Garage capacity: ");
            return new GarageHandler<Vehicle>(garageCapacity: capacity);
        }
    }
}
