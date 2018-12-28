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
            Vehicle newVehicle = CreateVehicle();
            if(newVehicle != null)
            {
                garageHandler.Add(newVehicle);
            }
        }

        private Vehicle CreateVehicle()
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
                        break;
                    case "2":
                        //Boat
                        vehicle = CreateBoat();
                        break;
                    case "3":
                        //Bus
                        vehicle = CreateBus();
                        break;
                    case "4":
                        //Car
                        vehicle = CreateCar();
                        break;
                    case "5":
                        //MotorCycle
                        vehicle = CreateMotorcycle();
                        break;
                    default:
                        Console.WriteLine($"{answer} is not an option!!");
                        break;
                }
            } while (!finished);

            return vehicle;
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
            return new Car("DKL325", "Green", 2, "Diesel");
        }

        private Vehicle CreateBus()
        {
            return new Bus("DKL325", "Green", 2, 30);
        }

        private Vehicle CreateBoat()
        {
            return new Boat("DKL325", "Green", 2, 230);
        }

        private Vehicle CreateAirplane()
        {
            return new Airplane("DKL325", "Green", 2, 4);
        }
    }
}
