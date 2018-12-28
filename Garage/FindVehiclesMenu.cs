using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Cmd
{
    internal class FindVehiclesMenu
    {
        private static FindVehiclesMenu _instance;
        private readonly string _removeVehicleMenuPath = Path.Combine(Environment.CurrentDirectory, "TextFiles", "remove_vehicles_menu.txt");
        private readonly string _removeVehicleMenu;
    }
}
