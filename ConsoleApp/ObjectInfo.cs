using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public sealed class ObjectInfo
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public List<Employee> Employees { get; set; }
        public List<Work> Works { get; set; }

    }
}