using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PetShop.Models
{
    public class Cat : Pet
    {
        public Cat(string name, int age, bool lazy, int lives) : base(name, AnimalType.Cat, age)
        {
            Lazy = lazy;
            Lives = lives;
        }
        public bool Lazy { get; set; }
        public int Lives { get; set; }
        public override void PrintInfo()
        {
            if(Lazy == true)
            {
            Console.WriteLine($"{Name} is a {Type} with {Lives} lives. {Name} is {Age} years old and a very lazy cat. ");
            } else
            {
            Console.WriteLine($"{Name} is a {Type} with {Lives} lives. {Name} is {Age} years old and a very playful and energetic cat. ");
            }
        }
    }
}
