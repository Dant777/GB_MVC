using System;
using System.Collections.Generic;
using System.Linq;


namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectInfo objectInfo = new ObjectInfo()
            {
                Name = "Name#1",
                StartDate = DateTime.Now,
                Employees = new List<Employee>()
                {
                    new Employee()
                    {
                        Name = "Employee name 1",
                        Position = "Employee Position 1"
                    },
                    new Employee()
                    {
                        Name = "Employee name 2",
                        Position = "Employee Position 2"
                    },
                    new Employee()
                    {
                        Name = "Employee name 3",
                        Position = "Employee Position 3"
                    }
                },
                Works = new List<Work>()
                {
                    new Work()
                    {
                        Name = "Work name 1",
                        Value = 111
                    },
                    new Work()
                    {
                        Name = "Work name 2",
                        Value = 222
                    },new Work()
                    {
                        Name = "Work name 3",
                        Value = 333
                    },
                }
            };

            ReportService reportService = new ReportService();

            reportService.GenerateReport(objectInfo);
        }
    }
}