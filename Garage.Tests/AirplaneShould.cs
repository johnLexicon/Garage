using System;
using Garage.Biz.Vehicles;
using Xunit;

namespace Garage.Tests
{
    public class AirplaneShould
    {
        [Fact]
        public void CreateAirplaneWithAllProperties()
        {
            //Arrange
            Airplane sut = null;
            string expectedRegNr = "ABC123";
            string expectedColor = "grey";
            short expectedWheelsNr = 2;
            short expectedEnginesNr = 4;

            //Act
            sut = new Airplane("ABC123", "grey", wheelsNr: 2, enginesNr: 4);

            //Assert
            
        }
    }
}
