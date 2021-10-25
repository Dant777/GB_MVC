using System;
using System.Threading;
using ConsoleApp.MainClasses;

namespace ConsoleApp
{
    // Используя знания о паттернах, выберите приглянувшийся вам
    class Program
    {
        static void Main(string[] args)
        {
            //Паттерн прототип
            PostPackege postPackege_1 = new PostPackege();
            postPackege_1.id = 1;
            postPackege_1.name = "Name_1";
            postPackege_1.postDate = Convert.ToDateTime("2021-10-05");
            postPackege_1.country = new Country("Country name - 1");

          
            PostPackege postPackege_2 = (PostPackege)postPackege_1.ShallowCopy();

            PostPackege postPackege_3 = (PostPackege)postPackege_1.DeepCopy();

            
            Console.WriteLine("Изначальные значения");
            Console.WriteLine("   postPackege_1: ");
            PrintValues(postPackege_1);
            Console.WriteLine("   postPackege_2:");
            PrintValues(postPackege_2);
            Console.WriteLine("   postPackege_3:");
            PrintValues(postPackege_3);

            
            postPackege_1.id = 2;
            postPackege_1.postDate = Convert.ToDateTime("2022-10-05");
            postPackege_1.name = "Name_2";
            postPackege_1.country.countryName = "Country name - 2";
            Console.WriteLine("\nВсе значения после изменения прототипа:");
            Console.WriteLine("   postPackege_1 instance values: ");
            PrintValues(postPackege_1);
            Console.WriteLine("   postPackege_2 содержит ссылку без изменений:");
            PrintValues(postPackege_2);
            Console.WriteLine("   postPackege_3 полное копирование:");
            PrintValues(postPackege_3);


            Console.ReadKey();
        }

        public static void PrintValues(PostPackege packege)
        {
            Console.WriteLine("      Id: {0}, Name: {1}, PostDate: {2:MM/dd/yy}",
                packege.id, packege.name, packege.postDate);
            Console.WriteLine("      Country: {0:d}", packege.country.countryName);
        }
    }
}
