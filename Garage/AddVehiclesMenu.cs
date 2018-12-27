using System;
namespace Garage.Cmd
{
    internal class AddVehiclesMenu
    {

        private static AddVehiclesMenu _instance;
        //private readonly string menuPath = ""

        private AddVehiclesMenu()
        {
        }

        internal static AddVehiclesMenu Instance
        {
            get
            {
                if(_instance is null)
                {
                    _instance = new AddVehiclesMenu();
                }
                return _instance;
            }
        }
    }
}
