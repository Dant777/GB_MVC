using System.IO;

namespace ConsoleApp.Factories.StrategyPattern.Interfaces
{
    public interface IScannerDevice
    {

        public int Cpu { get; set; }

        public int Memory { get; set; }

        public void Accept(IMonitorVisitor visitor, IScannerLogger logger);
     
        Stream Scan(string filePath);
    }

   
}