using Classes.Enums;
using Classes.Vehicles;
using Entities.Enums;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Vehicles
{
    public class Boat : BaseVehicle, IBoat
    {
        public Boat(BoatTypes type, FuelType fuelType, string model, int manufacturedYear, string color,short hp)
                 : base(VehicleType.Boat, fuelType, model, manufacturedYear, color, 0, hp)
        {
            TypeOfBoat = type;
        }

        public BoatTypes TypeOfBoat { get; set; }

        public override void IsDriveable()
        {
            Console.WriteLine($"Your {TypeOfBoat} is drivable only on water!");
        }

        public override void VehicleInfo()
        {
            Console.WriteLine($"Vehicle: {TypeOfVehicle}\nModel: {Model}\nBoat type: {TypeOfBoat}\nFuelType: {FuelType}\nYear: {ManufacturedYear}\nHorsePower: {HorsePower}\nColor: {Color}\n");
        }
    }
}
