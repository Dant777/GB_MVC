using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleApp.Entities
{
    public class WorkEntities
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonProperty("id")]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FullInfoJson { get; set; }
    }
}
