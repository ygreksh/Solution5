using System;
using System.IO;
using System.Linq;

namespace IQueryableSample
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            /*
            Person[] personArray = new Person[]
            {
                new Person {Name = "Jhon Smith", Id = 1, BirthDate = new DateTime(1980,02,03), Sex = true},
                new Person {Name = "Ivan Ivanov", Id = 7, BirthDate = new DateTime(1999,12,2), Sex = true},
                new Person {Name = "Jhon Doe", Id = 6, BirthDate = new DateTime(2000,01,01), Sex = true},
                new Person {Name = "Mary kay", Id = 2, BirthDate = new DateTime(1980,01,01), Sex = false},
                new Person {Name = "Richard The Lionheart", Id = 10, BirthDate = new DateTime(1157,09,08), Sex = true},
                new Person {Name = "Maksim Gorkiy", Id = 5, BirthDate = new DateTime(1868,03,28), Sex = true},
                new Person {Name = "Merilyn Monroe", Id = 4, BirthDate = new DateTime(1926,06,01), Sex = false}
            };
            */

            var rand = new Random();
            Person[] crowd = new Person[10]; //для понимания работы достаточно 10 экземпляров, 100 - слишком много

            for (int i = 0; i < crowd.Length; i++)
            {
                crowd[i] = new Person {
                                    //Name = "",
                                    Name = Path.GetRandomFileName().Replace(".", ""), 
                                    Id = rand.Next(100), 
                                    //BirthDate = new DateTime(rand.Next(2000),rand.Next(12),rand.Next(28)),
                                    BirthDate = DateTime.Today.AddDays(-rand.Next(100*365)),
                                    Sex = (rand.Next(2) == 0)
                                    };
            }

            foreach (var item in crowd)
            {
                Console.WriteLine(item.Id + ", " + item.Name + ", " + item.Sex + ", " + item.BirthDate);
            }
            
            //Список тех, что имя начинается на "a"
            Console.WriteLine("item.Name.StartWith \"a\"");
            var selectedPersons = crowd.Where(t=>t.Name.StartsWith("a"));
            foreach (var item in selectedPersons)
            {
                Console.WriteLine(item.Name);
            }
            
            //Список тех, кто родился после 1950
            Console.WriteLine("item.BirthDate >= 1950 and <=2000");
            selectedPersons = crowd.Where(t=>t.BirthDate >= DateTime.Today.AddYears(-(2020-1950)) 
                                             && t.BirthDate <= DateTime.Today.AddYears(-(2020-2000)))
                                    .OrderBy(t=>t.BirthDate);
            foreach (var item in selectedPersons)
            {
                Console.WriteLine(item.Id + ", " + item.Name + ", " + item.Sex + ", " + item.BirthDate);
            }

            //Список женщин (Sex == false)
            Console.WriteLine("item.Sex == false (womens)");
            selectedPersons = crowd.Where(t=>t.Sex == false);
            foreach (var item in selectedPersons)
            {
                Console.WriteLine(item.Name);
            }

            //Сумма всех Id
            Console.WriteLine("Сумма всех Id");
            int Sum = crowd.Sum(t=>t.Id);
            Console.WriteLine(Sum);
             
            //Самый старый и самый молодой
            Console.WriteLine("Самый старый и самый молодой");
            var oldestPersons = crowd.Where(t=> t.BirthDate.Year == crowd.Min(m=>m.BirthDate.Year));
            foreach (var item in oldestPersons)
            {
                Console.WriteLine(item.Id + ", " + item.Name + ", " + item.BirthDate);
            }
            var youngestPersons = crowd.Where(t=> t.BirthDate.Year == crowd.Max(m=>m.BirthDate.Year));
            foreach (var item in youngestPersons)
            {
                Console.WriteLine(item.Id + ", " + item.Name + ", " + item.BirthDate);
            }
        }
    }
}