using Classes.Enums;
using Classes.Vehicles;
using Entities.Enums;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Vehicles
{
    public class Car : BaseVehicle,ICar
    {
        public Car(FuelType fuelType,CarType typeOfCar, string model, int manufacturedYear, string color, int wheels, short hp)
            : base(VehicleType.Car, fuelType, model, manufacturedYear, color, wheels, hp)
        {
            CarType = typeOfCar;
        }

        public CarType CarType { get; set; }

        public override void IsDriveable()
        {
            Console.WriteLine($"The {CarType} {TypeOfVehicle} - {Model} is driveable on the road.");
        }

        public override void VehicleInfo()
        {
            Console.WriteLine($"Vehicle: {TypeOfVehicle}\nModel: {Model}\nType: {CarType}\nFuelType: {FuelType}\nYear: {ManufacturedYear}\nHorsePower: {HorsePower}\nColor: {Color}\n");
        }
    }
}
