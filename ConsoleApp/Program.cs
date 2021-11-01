using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ConsoleApp.Entities;
using ConsoleApp.FacadeObj;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleApp
{
    //Придумайте небольшое приложение консольного типа, который берет различные Json структуры (предположительно из разных веб сервисов),
    //олицетворяюющие товар в магазинах. Структуры не похожи друг на друга, но вам нужно их учесть, сделать универсально. Структуры на ваше усмотрение.
    class Program
    {
        static void Main(string[] args)
        {
            //Паттерн прототип
            string path = @"JsonData/jsonData_1.json";
            List<string> listPath = new List<string>() {@"JsonData/jsonData_2.json", @"JsonData/jsonData_3.json"};

            DBClass db = new DBClass();
            AggregateJsonProduct aggregate = new AggregateJsonProduct();

            Facade facade = new Facade(aggregate, db);
            facade.AddInDB(path);
            facade.AddInDB(listPath);

            foreach (var work in db.WorkEntitiesList)
            {
                Console.WriteLine(work.Name);
                Console.WriteLine("--------------------------");
            }

            Console.ReadKey();
        }
    }
}