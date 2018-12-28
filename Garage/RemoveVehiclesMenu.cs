using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Cmd
{
    internal class RemoveVehiclesMenu
    {
        private static RemoveVehiclesMenu _instance;

        private RemoveVehiclesMenu()
        {
        }

        internal RemoveVehiclesMenu Instance
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
    }
}
