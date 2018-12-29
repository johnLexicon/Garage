using System;
using Xunit;
using Xunit.Abstractions;
using Garage.Biz;
using Garage.Biz.Vehicles;
using Garage.Data;
using System.Collections.Generic;
using System.Linq;

namespace Garage.Tests
{
    public class GarageHandlerShould
    {

        //For being able to create output in the tests.
        private readonly ITestOutputHelper _output;

        public GarageHandlerShould(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void AddOneVehicle_WhenCapacityEqualsOne()
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
        public void AddOneVehicle_WhenGarageIsAlreadyFull()
        {
            //Arrange
            int garageCapacity = 0;
            GarageHandler<Vehicle> sut = new GarageHandler<Vehicle>(garageCapacity);
            Vehicle airplane = new Airplane("RRR123", "grey", wheelsNr: 2, enginesNr: 4);

            //Assert
            Assert.Throws<GarageIsFullException>(() => sut.Add(airplane));
        }

        [Fact]
        public void RemoveVehicleByRef()
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
        public void RemoveVehiclesByRegNr()
        {
            //Arrange
            GarageHandler<Vehicle> sut = new GarageHandler<Vehicle>(garageCapacity: 2);
            int expectedSpacesAvailable = 0;
            string regnr = "BBB321";
            Vehicle boat = new Boat(regnr, "Red", wheelsNr: 0, length: 500);
            Vehicle car = new Car("CCC123", "Green", wheelsNr: 4, fuelType: "Diesel");
            //Add two vehicles
            sut.Add(boat);
            sut.Add(car);

            //Act
            bool vehicleRemoved = sut.RemoveByRegnr(regnr);
            bool carRemoved = sut.RemoveByRegnr("CCC123");

            //Assert
            Assert.Equal(expectedSpacesAvailable, sut.SpacesAvailable);
        }

        [Fact]
        public void FindVehicleByRegnr()
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

        [Fact]
        public void GetVehiclesAndGroupByType()
        {
            //Arrange
            IVehiclesDAO dao = new VehiclesBinary(); 
            GarageHandler<Vehicle> sut = new GarageHandler<Vehicle>(garageCapacity: 10);
            ICollection<Vehicle> vehicles = dao.RetrieveAllVehicles();
            AddVehiclesToGarage(vehicles, sut);

            //Act
            var result = sut.GetVehiclesGroupedByType();

            foreach (var item in result)
            {
                _output.WriteLine($"Key: {item.Key.Name}, Count: {item.Count()}");
            }

            //TODO: Create som real assertion for the test.
            //Assert
            Assert.True(true);
        }

        [Fact]
        public void FindVehiclesByPropertyValues()
        {
            //Arrange
            IVehiclesDAO dao = new VehiclesBinary();
            GarageHandler<Vehicle> sut = new GarageHandler<Vehicle>(garageCapacity: 10);
            ICollection<Vehicle> vehicles = dao.RetrieveAllVehicles();
            AddVehiclesToGarage(vehicles, sut);

            var props = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("FuelType", "Diesel"),
                new Tuple<string, string>("WheelsNr", "4")
            };

            //Act
            var result = sut.FindVehiclesByPropertyValues(props);

            //Assert
            Assert.Equal(2, result.Count);
        }

        private void AddVehiclesToGarage(ICollection<Vehicle> vehicles, GarageHandler<Vehicle> handler)
        {
            foreach (var vehicle in vehicles)
            {
                handler.Add(vehicle);
            }
        }
    }
}
