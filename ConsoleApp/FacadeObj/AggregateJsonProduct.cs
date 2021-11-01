using System.IO;
using ConsoleApp.Entities;
using Newtonsoft.Json;

namespace ConsoleApp.FacadeObj
{
    public  class AggregateJsonProduct
    {
        public  WorkEntities CreateWorkEntities(string jsonPath)
        {
            string jsonTxt = File.ReadAllText(jsonPath);
            WorkEntities workEntities = JsonConvert.DeserializeObject<WorkEntities>(jsonTxt);
            workEntities.FullInfoJson = jsonTxt;
            return workEntities;
        }
    }
}