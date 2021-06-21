using Classes.Enums;
using Entities.Enums;
using Entities.Vehicles;
using System;

namespace SEDC.CSharp.Homework.ConsoleApp.Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Create a ConsoleApp for Cars. Build it with 
             * abstract class Vehicle and some derived classes like Car, Van, 
             * Motorbike, Boat and Bike. Think of different methods all the classes 
             * will have and create interfaces like ICar, IBoat, IBIke, IVan and put some 
             * specific methods in them Implement all the approperiate interfaces in the 
             * appropriate classes. Create objects and call the methods.*/
            Car tesla = new Car(FuelType.Electric, CarType.Sport, "Tesla", 2021, "white", 4, 450);
            tesla.VehicleInfo();
            tesla.IsDriveable();
            tesla.HarmsTheEnviroment();
            Console.WriteLine("================================================================");
            Van peugeot = new Van(FuelType.Disel, "Peugeot", 2010, "white", 4, 140, 18, true);
            peugeot.VehicleInfo();
            peugeot.IsDriveable();
            peugeot.IsTransporting();
            peugeot.HarmsTheEnviroment();
            Console.WriteLine("================================================================");
            Motorbike dirtBike = new Motorbike(MotorbikeTypes.Dirt_Bike, FuelType.Petrol, "Yamaha", 2017, "blue", 2, 65);
            dirtBike.VehicleInfo();
            dirtBike.IsDriveable();
            dirtBike.HarmsTheEnviroment();
            Console.WriteLine("================================================================");
            Boat jetSki = new Boat(BoatTypes.Jet_Ski, FuelType.Petrol, "Honda", 2015, "yellow", 45);
            jetSki.VehicleInfo();
            jetSki.IsDriveable();
            jetSki.HarmsTheEnviroment();
            Console.WriteLine("================================================================");
            Bike trek = new Bike("Trek", 2021, "grey");
            trek.VehicleInfo();
            trek.IsDriveable();
            trek.HarmsTheEnviroment();

            Console.ReadLine();

        }
    }
}
