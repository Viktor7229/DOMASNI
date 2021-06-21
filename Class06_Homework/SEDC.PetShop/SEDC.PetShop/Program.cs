using SEDC.PetShop.Models;
using System;
using System.Collections.Generic;

namespace SEDC.PetShop
{
    class Program
    {

        static void Main(string[] args)
        {
            Dog rex = new Dog("Rex", 3, "pork");
            Dog mike = new Dog("Mike", 6, "beef");

            List<Dog> dogs = new List<Dog> { rex, mike };

            Cat kitty = new Cat("Kitty", 2, false, 8);
            Cat jane = new Cat("Jane", 3, true, 3);
            List<Cat> cats = new List<Cat> { kitty, jane };

            Fish mikey = new Fish("Mikey", 1, 5, "blue");
            Fish rocky = new Fish("Rocky", 3, 8, "yellow");
            List<Fish> fishes = new List<Fish> { mikey, rocky };

            Console.WriteLine("==================== CAT STORE ====================");
            PetStore<Cat>.Pets = cats;
            PetStore<Cat>.PrintPets();
            PetStore<Cat>.BuyPet("jane");
            jane.PrintInfo();
            PetStore<Cat>.PrintPets();
            Console.WriteLine("==================== FISH STORE ====================");
            PetStore<Fish>.Pets = fishes;
            PetStore<Fish>.PrintPets();
            PetStore<Fish>.BuyPet("mikey");
            mikey.PrintInfo();
            PetStore<Fish>.PrintPets();
            Console.WriteLine("==================== DOG STORE ====================");
            PetStore<Dog>.Pets = dogs;
            PetStore<Dog>.PrintPets();
            PetStore<Dog>.BuyPet("Rex");
            rex.PrintInfo();
            PetStore<Dog>.PrintPets();
            Console.ReadLine();
        }
    }
}
