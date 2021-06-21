using Classes.Enums;
using Classes.Vehicles;
using Entities.Enums;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Vehicles
{
    public class Bike : BaseVehicle, IBike
    {
        public Bike(string model, int manufacturedYear, string color) 
             : base(VehicleType.Bike, FuelType.Not_Fueled, model, manufacturedYear, color, 2)
        {
                
        }
        public void DoStunts()
        {
            Console.WriteLine("Flips.. Wheelies.. Jumps!");
        }

        public override void IsDriveable()
        {
            Console.WriteLine($"You cannot ride the {Model} on the open road! Only on bike tracks!");
        }

        public override void VehicleInfo()
        {
            Console.WriteLine($"Vehicle: {TypeOfVehicle}\nModel: {Model}\nYear: {ManufacturedYear}\nColor: {Color}");

        }
    }
}
