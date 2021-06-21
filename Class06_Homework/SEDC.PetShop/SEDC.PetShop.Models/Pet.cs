using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PetShop.Models
{
    public abstract class Pet
    {
        public Pet(string name, AnimalType type, int age)
        {
            Name = name;
            Type = type;
            Age = age;
        }
        public string Name { get; set; }
        public AnimalType Type { get; set; }
        public int Age { get; set; }

        public abstract void PrintInfo();

    }
}
