using Classes.Enums;
using Classes.Vehicles;
using Entities.Enums;
using Entities.Interfaces;
using System;

namespace Entities.Vehicles
{
    public class Van : BaseVehicle,IVan
    {
        public Van(FuelType fuelType, string model, int manufacturedYear, string color, int wheels, short hp,float trunkArea, bool isAvailable)
            : base(VehicleType.Van, fuelType, model, manufacturedYear, color, wheels, hp)
        {
            TrunkArea = trunkArea;
            IsAvailable = isAvailable;
        }

        public bool IsAvailable { get; set; }
        public float TrunkArea { get; set; }

        public override void IsDriveable()
        {
            Console.WriteLine($"The {TypeOfVehicle} - {Model} is driveable on the road.");
        }

        public void IsTransporting()
        {
            if(IsAvailable == true)
            {
                Console.WriteLine("Your van is available and ready for transporting goods!");
            } else
            {
                Console.WriteLine("Your van is not available! Currently transporting goods!");
            }
        }

        public override void VehicleInfo()
        {
            Console.WriteLine($"Vehicle: {TypeOfVehicle}\nModel: {Model}\nFuelType: {FuelType}\nTrunk Area: {TrunkArea} Cubic Meters\nYear: {ManufacturedYear}\nHorsePower: {HorsePower}\nColor: {Color}\n");

        }
    }
}
