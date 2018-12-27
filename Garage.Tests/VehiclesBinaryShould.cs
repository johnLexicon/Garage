using Garage.Biz.Vehicles;
using Garage.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Garage.Tests
{
    public class VehiclesBinaryShould
    {

        private Vehicle[] GenerateVehicles()
        {
            return new Vehicle[] {
                new Car("ABC123", "Green", 4, "Diesel"),
                new Airplane("FFF123", "Blue", 2, 4),
                new Boat("BBB345", "Black", 0, 450),
                new Bus("BUS098", "red", 8, 89),
                new Motorcycle("MMM012", "Orange", 2, 450),
                new Car("ABC456", "Blue", 4, "Diesel"),
                new Airplane("FFF555", "Yellow", 2, 4),
                new Boat("BBB666", "White", 0, 250),
                new Bus("BUS998", "Cyan", 8, 25),
                new Motorcycle("MMM111", "Pink", 2, 1500)
            };
        } 


        [Fact]
        public void SaveAllVehicles()
        {
            //Arrange
            Vehicle[] vehicles = GenerateVehicles();
            IVehiclesDAO dao = new VehiclesBinary();

            //Act
            bool isSaved = dao.SaveAllVehicles(vehicles);

            //Assert
            Assert.True(isSaved);
        }

        [Fact]
        public void RetrieveSavedVehicles()
        {
            //Arrange
            IVehiclesDAO dao = new VehiclesBinary();

            //Act
            Vehicle[] vehicles = dao.RetrieveAllVehicles();

            //Assert
            Assert.NotNull(vehicles);
        }
    }
}
