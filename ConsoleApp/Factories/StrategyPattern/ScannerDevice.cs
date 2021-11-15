using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Factories.StrategyPattern.Interfaces;

namespace ConsoleApp.Factories.StrategyPattern
{
    public sealed class ScannerDevice : IScannerDevice
    {
        public ScannerDevice()
        {
        }

        public int Cpu { get; set; }
        public int Memory { get; set; }

        public void Accept(IMonitorVisitor visitor, IScannerLogger logger)
        {
            visitor.VisitScanner(this, logger);
        }

        public Stream Scan(string filePath)
        {
            Random rnd = new Random();

            Cpu = rnd.Next(1, 101);
            Memory = rnd.Next(1, 2000);

            string path = filePath;

            Console.WriteLine($"Scanning....{filePath}");
            return File.OpenRead(path);
        }
    }
}