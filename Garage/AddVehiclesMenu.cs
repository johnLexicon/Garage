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
        private readonly string _vehicleTypeMenu;
        private readonly string vehicleTypeMenuPath = Path.Combine(Environment.CurrentDirectory, "TextFiles", "vehicle_type_menu.txt");

        private AddVehiclesMenu()
        {
            _vehicleTypeMenu = CmdUtils.ReadTextFile(vehicleTypeMenuPath);
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
            
            string answer = string.Empty;
            do
            {

                if(garageHandler.SpacesAvailable == 0)
                {
                    Console.WriteLine("No more spaces available, garage is full!!");
                    return;
                }

                Console.WriteLine(_vehicleTypeMenu);
                answer = CmdUtils.AskForString("Choose type of vehicle to create: ");
                switch (answer)
                {
                    case "0":
                        //Quit
                        CmdUtils.ShowMessageAndPressKeyToContinue("Exits Add Vehicle Menu. Press key to continue...");
                        finished = true;
                        break;
                    case "1":
                        //Airplane
                        vehicle = CreateAirplane();
                        AddVehicle(garageHandler, vehicle);
                        break;
                    case "2":
                        //Boat
                        vehicle = CreateBoat();
                        AddVehicle(garageHandler, vehicle);
                        break;
                    case "3":
                        //Bus
                        vehicle = CreateBus();
                        AddVehicle(garageHandler, vehicle);
                        break;
                    case "4":
                        //Car
                        vehicle = CreateCar();
                        AddVehicle(garageHandler, vehicle);
                        break;
                    case "5":
                        //MotorCycle
                        vehicle = CreateMotorcycle();
                        AddVehicle(garageHandler, vehicle);
                        break;
                    default:
                        Console.WriteLine($"{answer} is not an option!!");
                        break;
                }

                Console.WriteLine("Vehicle created!!");

            } while (!finished);

        }

        private void AddVehicle(GarageHandler<Vehicle> garageHandler, Vehicle vehicle)
        {
            try
            {
                garageHandler.Add(vehicle);
            }
            catch (GarageIsFullException e)
            {
                Console.WriteLine(e.Message);
            }
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
