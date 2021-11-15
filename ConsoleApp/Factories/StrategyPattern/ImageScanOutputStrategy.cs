using System;
using ConsoleApp.Factories.StrategyPattern.Interfaces;

namespace ConsoleApp.Fastories.StrategyPattern
{
    public sealed class ImageScanOutputStrategy : IScanOutputStrategy
    {
        public void ScanAndSave(IScannerDevice scannerDevice, string outputFileName)
        {
            scannerDevice.Scan(outputFileName);

            Console.WriteLine($"do image outptut - {outputFileName}");
            //do image outptut
        }
    }
}