using AdvLINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvLINQ
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Dog> dogs = new List<Dog>(){
			new Dog("Charlie", "Black", 3, Race.Collie), // 0
			new Dog("Buddy", "Brown", 1, Race.Doberman),
			new Dog("Max", "Olive", 1, Race.Plott),
			new Dog("Archie", "Black", 2, Race.Mutt),
			new Dog("Oscar", "White", 1, Race.Mudi),
			new Dog("Toby", "Maroon", 3, Race.Bulldog), // 5
			new Dog("Ollie", "Silver", 4, Race.Dalmatian),
			new Dog("Bailey", "White", 4, Race.Pointer),
			new Dog("Frankie", "Gray", 2, Race.Pug),
			new Dog("Jack", "Black", 5, Race.Dalmatian),
			new Dog("Chanel", "Black", 1, Race.Pug), // 10
			new Dog("Henry", "White", 7, Race.Plott),
			new Dog("Bo", "Maroon", 1, Race.Boxer),
			new Dog("Scout", "Olive", 2, Race.Boxer),
			new Dog("Ellie", "Brown", 6, Race.Doberman),
			new Dog("Hank", "Silver", 2, Race.Collie), // 15
			new Dog("Shadow", "Silver", 3, Race.Mudi),
			new Dog("Diesel", "Brown", 4, Race.Bulldog),
			new Dog("Abby", "Black", 1, Race.Dalmatian),
			new Dog("Trixie", "White", 8, Race.Pointer), // 19
			};

			List<Person> people = new List<Person>(){
			new Person("Nathanael", "Holt", 20, Job.Choreographer),
			new Person("Rick", "Chapman", 35, Job.Dentist),
			new Person("Oswaldo", "Wilson", 19, Job.Developer),
			new Person("Kody", "Walton", 43, Job.Sculptor),
			new Person("Andreas", "Weeks", 17, Job.Developer),
			new Person("Kayla", "Douglas", 28, Job.Developer),
			new Person("Richie", "Campbell", 19, Job.Waiter),
			new Person("Soren", "Velasquez", 33, Job.Interpreter),
			new Person("August", "Rubio", 21, Job.Developer),
			new Person("Rocky", "Mcgee", 57, Job.Barber),
			new Person("Emerson", "Rollins", 42, Job.Choreographer),
			new Person("Everett", "Parks", 39, Job.Sculptor),
			new Person("Amelia", "Moody", 24, Job.Waiter)
			{ Dogs = new List<Dog>() {dogs[16], dogs[18] } },
			new Person("Emilie", "Horn", 16, Job.Waiter),
			new Person("Leroy", "Baker", 44, Job.Interpreter),
			new Person("Nathen", "Higgins", 60, Job.Archivist)
			{ Dogs = new List<Dog>(){dogs[6], dogs[0] } },
			new Person("Erin", "Rocha", 37, Job.Developer)
			{ Dogs = new List<Dog>() {dogs[2], dogs[3], dogs[19] } },
			new Person("Freddy", "Gordon", 26, Job.Sculptor)
			{ Dogs = new List<Dog>() {dogs[4], dogs[5], dogs[10], dogs[12], dogs[13] } },
			new Person("Valeria", "Reynolds", 26, Job.Dentist),
			new Person("Cristofer", "Stanley", 28, Job.Dentist)
			{ Dogs = new List<Dog>() {dogs[9], dogs[14], dogs[15] } }
			};

			// Find and print all persons first names starting with 'R', ordered by Age - DESCENDING ORDER
			List<Person> peopleStartingWithR = people.Where(p => p.FirstName.StartsWith("R"))
													 .OrderByDescending(p => p.Age)
													 .ToList();

			List<Person> PeopleStartingWithRSql = (from x in people
												   where x.FirstName.StartsWith("R")
												   orderby x.Age descending
												   select x)
												   .ToList();

			//peopleStartingWithR.ForEach(p => Console.WriteLine($"Name: {p.FirstName}   Age: {p.Age}"));
			//Console.WriteLine("==========================================");
			//PeopleStartingWithRSql.ForEach(p => Console.WriteLine($"Name: {p.FirstName}   Age: {p.Age}"));




			
			// Find and print all brown dogs names and ages older than 3 years, ordered by Age - ASCENDING ORDER
			List<Dog> brownDogsOlderThan3 = dogs.Where(d => d.Color == "Brown" && d.Age > 3)
												.OrderBy(d => d.Age)
												.ToList();

			List<Dog> brownDogsOlderThan3Sql = (from x in dogs
												where x.Color == "Brown" && x.Age > 3
												orderby x.Age
												select x)
												.ToList();


			//brownDogsOlderThan3.ForEach(d => Console.WriteLine($"Color: {d.Color}  Name: {d.Name}   Age: {d.Age}"));
			//Console.WriteLine("==========================================");
			//brownDogsOlderThan3Sql.ForEach(d => Console.WriteLine($"Color: {d.Color}  Name: {d.Name}   Age: {d.Age}"));
			




			// Find and print all persons with more than 2 dogs, ordered by Name - DESCENDING ORDER
			List<Person> personsWithMoreThan2Dogs = people.Where(p => p.Dogs.Count > 2)
														  .OrderByDescending(p => p.FirstName)
														  .ToList();

			List<Person> personsWithMoreThan2DogsSql = (from p in people
														where p.Dogs.Count > 2
														orderby p.FirstName descending
														select p)
														.ToList();

			//personsWithMoreThan2Dogs.ForEach(p => Console.WriteLine($"Name: {p.FirstName}   Dogs: {p.Dogs.Count}"));
			//Console.WriteLine("==========================================");
			//personsWithMoreThan2DogsSql.ForEach(p => Console.WriteLine($"Name: {p.FirstName}   Dogs: {p.Dogs.Count}"));





			// Find and print all Freddy`s dogs names older than 1 year
			List<Dog> FreddysDogsOlderThan1Year = people.Where(p => p.FirstName == "Freddy")
														.SelectMany(p => p.Dogs
																.Where(d => d.Age > 1))
														.ToList();

			List<Dog> FreddysDogsOlderThan1YearSql = (from p in people
												where p.FirstName == "Freddy"
												from d in p.Dogs
												where d.Age > 1
												select d)
												.ToList();



			//FreddysDogsOlderThan1Year.ForEach(d => Console.WriteLine(d.Name));
			//Console.WriteLine("==========================================");
			//FreddysDogsOlderThan1YearSql.ForEach(d => Console.WriteLine(d.Name));





			// Find and print Nathen`s first dog
			List<Dog> nathensFirstDog = people.Where(p => p.FirstName == "Nathen")
										.Select(d => d.Dogs.First())
										.ToList();

			List<Dog> nathensFirstDogSql = (from p in people
									  where p.FirstName == "Nathen"
									  select p.Dogs.FirstOrDefault())
									  .ToList();

			//nathensFirstDog.ForEach(d => Console.WriteLine($"Nathen's first dog is: {d.Name}"));
			//Console.WriteLine("==========================================");
			//nathensFirstDogSql.ForEach(d => Console.WriteLine($"Nathen's first dog is: {d.Name}"));





			// Find and print all white dogs names from Cristofer, Freddy, Erin and Amelia, ordered by Name - ASCENDING ORDER
			List<Dog> allWhiteDogs = people.Where(p => p.FirstName == "Christofer" ||
												 p.FirstName == "Freddy" ||
												 p.FirstName == "Erin" ||
												 p.FirstName == "Amelia")
									  .SelectMany(p => p.Dogs)
									  .Where(d => d.Color == "White")
									  .OrderBy(d => d.Name)
									  .ToList();

			var allWhiteDogsSql = (from p in people
								where p.FirstName == "Christofer" ||
									  p.FirstName == "Freddy" ||
									  p.FirstName == "Erin" ||
									  p.FirstName == "Amelia"
								from d in p.Dogs
								where d.Color == "White"
								orderby d.Name
								select d).ToList();
									  
			allWhiteDogs.ForEach(d => Console.WriteLine($"White dog from Christofer, Freddy, Erin and Amelia: {d.Name}"));
			Console.WriteLine("==========================================");
			allWhiteDogsSql.ForEach(d => Console.WriteLine($"White dog from Christofer, Freddy, Erin and Amelia: {d.Name}"));


			Console.ReadLine();


		}
    }
}
