using System;
using Xunit;
using Garage.Biz;
using Garage.Biz.Vehicles;

namespace Garage.Tests
{
    public class GarageHandlerShould
    {

        [Fact]
        public void AddVehicle_CapacityOne_ReturnTrue()
        {
            //Arrange
            GarageHandler<Vehicle> sut = new GarageHandler<Vehicle>(garageCapacity: 1);
            Vehicle airplane = new Airplane("RRR123", "grey", wheelsNr: 2, enginesNr: 4);

            //Act
            bool vehicleWasAdded = sut.Add(airplane);

            //Assert
            Assert.True(vehicleWasAdded);
        }

        [Fact]
        public void RemoveVehicleByRef_ReturnTrue()
        {
            //Arrange
            GarageHandler<Vehicle> sut = new GarageHandler<Vehicle>(garageCapacity: 1);
            Vehicle boat = new Boat("BBB321", "Red", wheelsNr: 0, length: 500);
            sut.Add(boat);

            //Act
            bool vehicleRemoved = sut.Remove(boat);

            //Assert
            Assert.True(vehicleRemoved);
        }

        [Fact]
        public void FindVehicleByRegnr_ReturnFoundVehicle()
        {
            //Arrange
            GarageHandler<Vehicle> sut = new GarageHandler<Vehicle>(garageCapacity: 1);
            string regNr = "BBB321";
            Vehicle expected = new Boat(regNr, "Red", wheelsNr: 0, length: 500);
            sut.Add(expected);

            //Act
            Vehicle actual = sut.Find(regNr);

            //Assert
            Assert.Same(expected, actual);
        }
    }
}
