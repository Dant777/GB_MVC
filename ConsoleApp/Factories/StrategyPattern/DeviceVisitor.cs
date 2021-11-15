using System;
using ConsoleApp.Factories.StrategyPattern.Interfaces;


namespace ConsoleApp.Factories.StrategyPattern
{
    public sealed class DeviceVisitor : IMonitorVisitor
    {
 
        public void VisitScanner(IScannerDevice info, IScannerLogger logger)
        {
            string txt = $"{DateTime.Now} - Загрузка процессора - {info.Cpu} \n{DateTime.Now} - Загрузка памяти - {info.Memory}";
            logger.Write(txt);
            Console.WriteLine(txt);
        }

     
    }
}