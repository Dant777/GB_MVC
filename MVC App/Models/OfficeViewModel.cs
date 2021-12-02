using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_App.Models
{
    public class OfficeViewModel
    {
        private readonly List<Employee> _employees;

        public OfficeViewModel(List<Employee> employees)
        {
            _employees = employees;
        }

        public int EmployeeCount => _employees.Count;

        public List<Employee> Employees => _employees;
    }
}