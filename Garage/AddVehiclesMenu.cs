using System;
using System.IO;
using Garage.Biz;
using Garage.Biz.Vehicles;
using Garage.Common;

namespace Garage.Cmd
{
    internal class AddVehiclesMenu
    {

        private static AddVehiclesMenu _instance;
        private readonly string vehicleTypeMenuPath = Path.Combine(Environment.CurrentDirectory, "TextFiles", "vehicle_type_menu.txt");

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

        internal void AddVehicles(GarageHandler<Vehicle> garageHandler)
        {
            CreateAndAddVehicle(garageHandler);
        }

        private void CreateAndAddVehicle(GarageHandler<Vehicle> garageHandler)
        {
            Vehicle vehicle = null;
            bool finished = false;
            string vehicleTypeMenu = CmdUtils.ReadTextFile(vehicleTypeMenuPath);
            string answer = string.Empty;
            do
            {

                Console.WriteLine(vehicleTypeMenu);
                answer = CmdUtils.AskForString("Choose type of vehicle to create: ");
                switch (answer)
                {
                    case "0":
                        //Quit
                        finished = true;
                        break;
                    case "1":
                        //Airplane
                        vehicle = CreateAirplane();
                        garageHandler.Add(vehicle);
                        break;
                    case "2":
                        //Boat
                        vehicle = CreateBoat();
                        garageHandler.Add(vehicle);
                        break;
                    case "3":
                        //Bus
                        vehicle = CreateBus();
                        garageHandler.Add(vehicle);
                        break;
                    case "4":
                        //Car
                        vehicle = CreateCar();
                        garageHandler.Add(vehicle);
                        break;
                    case "5":
                        //MotorCycle
                        vehicle = CreateMotorcycle();
                        garageHandler.Add(vehicle);
                        break;
                    default:
                        Console.WriteLine($"{answer} is not an option!!");
                        break;
                }

            } while (!finished);

        }

        private VehicleBaseProperties GetBaseProperties()
        {
            var baseProperties = new VehicleBaseProperties();
            baseProperties.RegNr = CmdUtils.AskForString("RegNr: ");
            baseProperties.Color = CmdUtils.AskForString("Color: ");
            baseProperties.WheelsNr = CmdUtils.AskForInteger("Number of wheels: ");
            return baseProperties;
        }

        private Vehicle CreateMotorcycle()
        {
            var baseProps = GetBaseProperties();
            int cylinderVol = CmdUtils.AskForInteger("Cylinder volume: ");
            return new Motorcycle(baseProps.RegNr, baseProps.Color, baseProps.WheelsNr, cylinderVol);
        }

        private Vehicle CreateCar()
        {
            var baseProps = GetBaseProperties();
            string fuelType = CmdUtils.AskForString("Fuel type: ");
            return new Car(baseProps.RegNr, baseProps.Color, baseProps.WheelsNr, fuelType);
        }

        private Vehicle CreateBus()
        {
            var baseProps = GetBaseProperties();
            int seatsNr = CmdUtils.AskForInteger("Number of seats: ");
            return new Bus(baseProps.RegNr, baseProps.Color, baseProps.WheelsNr, seatsNr);
        }

        private Vehicle CreateBoat()
        {
            var baseProps = GetBaseProperties();
            double length = CmdUtils.AskForDouble("Boat length: ");
            return new Boat(baseProps.RegNr, baseProps.Color, baseProps.WheelsNr, length);
        }

        private Vehicle CreateAirplane()
        {
            var baseProps = GetBaseProperties();
            int enginesNr = CmdUtils.AskForInteger("Number of engines: ");
            return new Airplane(baseProps.RegNr, baseProps.Color, baseProps.WheelsNr, enginesNr);
        }
    }
}
