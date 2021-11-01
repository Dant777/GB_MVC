using System;
using System.Collections.Generic;
using ConsoleApp.Entities;

namespace ConsoleApp.FacadeObj
{
    public class DBClass
    {
        private readonly List<WorkEntities> _workEntitiesList;

        public DBClass()
        {
            _workEntitiesList = new List<WorkEntities>();
        }

        public List<WorkEntities> WorkEntitiesList
        {
            get => _workEntitiesList;
        }

        public void Add(WorkEntities workEntities)
        {
            _workEntitiesList.Add(workEntities);
            Console.WriteLine($"**************** DB count = {_workEntitiesList.Count}******************");
            Console.WriteLine($"Add in db - {workEntities.Name}");
            Console.WriteLine($"*************************************************\n");
        }
    }
}