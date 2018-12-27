using Garage.Biz.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Data
{
    public interface IVehiclesDAO
    {
        bool SaveAllVehicles(Vehicle[] vehicles);
        Vehicle[] RetrieveAllVehicles();
    }
}
