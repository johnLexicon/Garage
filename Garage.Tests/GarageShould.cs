using Xunit;
using Garage.Biz;
using Garage.Biz.Vehicles;
using System;

namespace Garage.Tests
{
    public class GarageShould
    {
        [Fact]
        public void AddOneVehicle_WhenCapacityEqualsOne()
        {
            //Arrange
            Garage<Vehicle> sut = new Garage<Vehicle>(capacity: 1);
            Vehicle airplane = new Airplane("RRR123", "grey", wheelsNr: 2, enginesNr: 4);

            //Act
            bool vehicleWasAdded = sut.Add(airplane);

            //Assert
            Assert.True(vehicleWasAdded);
        }

        [Fact]
        public void AddOneVehicle_CheckThatSpacesAvailableEqualsZero()
        {
            //Arrange
            Garage<Vehicle> sut = new Garage<Vehicle>(capacity: 1);
            Vehicle airplane = new Airplane("RRR123", "grey", wheelsNr: 2, enginesNr: 4);
            int expectedSpacesAvailable = 0;

            //Act
            bool vehicleWasAdded = sut.Add(airplane);

            //Assert
            Assert.Equal(expectedSpacesAvailable, sut.SpacesAvailable);
        }

        [Fact]
        public void CreateGarage_CapacityZero_NotNull()
        {
            //Arrange
            int capacity = 0;
            Garage<Vehicle> sut = null;

            //Act
            sut = new Garage<Vehicle>(capacity);

            //Assert
            Assert.NotNull(sut);
        }

        [Fact]
        public void AddVehicle_CapacityZero_ReturnFalse()
        {
            //Arrange
            Garage<Vehicle> sut = new Garage<Vehicle>(capacity: 0);
            Vehicle airplane = new Airplane("RRR123", "grey", wheelsNr: 2, enginesNr: 4);

            //Act
            bool vehicleWasAdded = sut.Add(airplane);

            //Assert
            Assert.False(vehicleWasAdded);
        }

        [Fact]
        public void CreateGarage_NegativeCapacity_ArgumentOutOfRangeExceptionThrown()
        {
            //Arrange
            int capacity = -1;

            //Act

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Garage<Vehicle>(capacity));
        }

        [Fact]
        public void RemoveVehicleByRef_ReturnTrue()
        {
            //Arrange
            Garage<Vehicle> sut = new Garage<Vehicle>(capacity: 1);
            Vehicle boat = new Boat("BBB321", "Red", wheelsNr: 0, length:500);
            sut.Add(boat);

            //Act
            bool vehicleRemoved= sut.Remove(boat);

            //Assert
            Assert.True(vehicleRemoved);
        }

        [Fact]
        public void RemoveVehicleNullRef_ReturnFalse()
        {
            //Arrange
            Garage<Vehicle> sut = new Garage<Vehicle>(capacity: 1);

            //Act
            bool vehicleRemoved = sut.Remove(null);

            //Assert
            Assert.False(vehicleRemoved);
        }

    }
}
