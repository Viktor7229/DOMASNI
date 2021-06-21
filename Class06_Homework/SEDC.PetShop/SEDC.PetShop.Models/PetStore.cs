using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.PetShop.Models
{
    public static class PetStore<T> where T : Pet
    {
        public static List<T> Pets { get; set; } = new List<T>();
        public static void PrintPets()
        {
            if (Pets.Count == 0)
            {
                Console.WriteLine($"We currently dont have pets!");
            }
            else
            {
                Console.WriteLine($"Available Pets:");
                foreach (T pet in Pets)
                {
                    Console.WriteLine(pet.Name);
                }
            }
        }
        public static void BuyPet(string nameOfPet)
        {
            T purchasedPet = Pets.FirstOrDefault(p => p.Name.ToLower() == nameOfPet.ToLower());
            if (purchasedPet == null)
            {
                Console.WriteLine($"We dont have that pet in our store");
            }
            else
            {
                Console.WriteLine($"You purchased a {purchasedPet.Type} named {purchasedPet.Name}");
                Pets.Remove(purchasedPet);
            }
        }
    }
}
