using System;
using Garage.Biz;
using Garage.Biz.Vehicles;

namespace Garage.Cmd
{
    class Program
    {


        static void Main(string[] args)
        {
         
            MainMenu.Instance.ShowMenu();

            Console.WriteLine("Program ends.");
        }
    }
}
