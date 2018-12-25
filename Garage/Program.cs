using System;

namespace Garage.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            var motorCycle = new Motorcycle(regNr: "ABC123", color: "green", wheelsNr: 2, cylinderVol: 500);
            Console.WriteLine("Hello World!");
        }
    }
}
