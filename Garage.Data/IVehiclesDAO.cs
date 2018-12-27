using Garage.Biz.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Data
{
    interface IVehiclesDAO
    {
        void SaveAllVehicles(Vehicle[] vehicles);
        Vehicle[] RetrieveAllVehicles();
    }
}
