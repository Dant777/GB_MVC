using System;
using ConsoleApp.Factories.StrategyPattern.Interfaces;

namespace ConsoleApp.Factories.StrategyPattern
{
    public sealed class PdfScanOutputStrategy : IScanOutputStrategy
    {
        public void ScanAndSave(IScannerDevice scannerDevice, string outputFileName)
        {
            scannerDevice.Scan(outputFileName);
            Console.WriteLine($"do pdf output - {outputFileName}");
            //do pdf output
        }

    }
}
