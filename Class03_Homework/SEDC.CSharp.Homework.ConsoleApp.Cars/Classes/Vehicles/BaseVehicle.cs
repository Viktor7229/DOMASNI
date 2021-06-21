using Classes.Enums;
using Entities.Enums;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Classes.Vehicles
{
    public abstract class BaseVehicle : IEnvironmentallyFriendly, IDriveable
    {
        public BaseVehicle(VehicleType vehType,FuelType fuelType, string model, int manufacturedYear, string color, int wheels, short hp = 0)
        {
            TypeOfVehicle = vehType;
            FuelType = fuelType;
            Model = model;
            ManufacturedYear = manufacturedYear;
            Color = color;
            Wheels = wheels;
            HorsePower = hp;
        }

        public VehicleType TypeOfVehicle { get; set; }
        public FuelType FuelType { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int ManufacturedYear { get; set; }
        public int Wheels { get; set; }
        public short HorsePower { get; set; }
        public bool IsHarmful { get; set; }

        public void HarmsTheEnviroment()
        {
            if(FuelType == FuelType.Electric || FuelType == FuelType.Not_Fueled)
            {
                IsHarmful = false;
                Console.WriteLine("Your vehicle does not harm the environment!");
            } else
            {
                IsHarmful = true;
                Console.WriteLine("Your vehicle harms the environment!");
            }
        }

        public abstract void IsDriveable();


        public abstract void VehicleInfo();
    }
}
