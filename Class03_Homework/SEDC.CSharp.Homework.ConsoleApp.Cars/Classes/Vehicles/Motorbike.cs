using Classes.Enums;
using Classes.Vehicles;
using Entities.Enums;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Vehicles
{
    public class Motorbike : BaseVehicle, IMotorbike
    {
        public Motorbike(MotorbikeTypes type, FuelType fuelType, string model, int manufacturedYear, string color, int wheels, short hp)
                  : base(VehicleType.Motorbike, fuelType, model, manufacturedYear, color, wheels, hp)
        {
            Type = type;
        }
        public MotorbikeTypes Type { get; set; }

        public override void IsDriveable()
        {
            if (Type == MotorbikeTypes.Dirt_Bike)
            {
                Console.WriteLine($"Your bike is illegal to drive on the road. You can only drive it on race tracks");
            }
            else
            {
                Console.WriteLine($"The {Type} {TypeOfVehicle} - {Model} is driveable on the road.");
            }
        }

        public override void VehicleInfo()
        {
            Console.WriteLine($"Vehicle: {TypeOfVehicle}\nModel: {Model}\nMotorbike type: {Type}\nFuelType: {FuelType}\nYear: {ManufacturedYear}\nHorsePower: {HorsePower}\nColor: {Color}\n");
        }
    }
}
