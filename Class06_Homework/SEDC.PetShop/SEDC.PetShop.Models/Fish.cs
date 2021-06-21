using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PetShop.Models
{
    public class Fish : Pet
    {
        public Fish(string name, int age, int size, string color) : base(name, AnimalType.Fish, age)
        {
            Size = size;
            Color = color;
        }

        public int Size { get; set; }
        public string Color { get; set; }

        public override void PrintInfo()
        {
            if(Size <= 3)
            {
            Console.WriteLine($"{Name} is a {Color} {Type}. {Name} is {Age} years old and a really small fish.");
            } else if(Size > 3 && Size <= 6)
            {
            Console.WriteLine($"{Name} is a {Color} {Type}. {Name} is {Age} years old and a medium size fish.");
            }
            else
            {
            Console.WriteLine($"{Name} is a {Color} {Type}. {Name} is {Age} years old and a really big fish.");
            }
        }
    }
}
