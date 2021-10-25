using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Interfaces;

namespace ConsoleApp.MainClasses
{
    public class PostPackege:IClone
    {
        public int id;
        public string name;
        public DateTime postDate;
        public Country country;
        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        public object DeepCopy()
        {
            PostPackege clone = (PostPackege)this.MemberwiseClone();
            clone.country = new Country(country.countryName);
            return clone;
        }
    }
}
