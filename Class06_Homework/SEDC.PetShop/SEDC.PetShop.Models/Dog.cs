using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PetShop.Models
{
    public class Dog : Pet
    {
        public Dog(string name, int age, string favFood) : base(name, AnimalType.Dog, age)
        {
            FavouriteFood = favFood;
        }
        public string FavouriteFood { get; set; }
        public override void PrintInfo()
        {
            Console.WriteLine($"{Name} is a {Type}. He is {Age} years old and his favourite food is {FavouriteFood}");
        }
    }
}
