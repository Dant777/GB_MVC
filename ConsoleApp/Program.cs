using ConsoleApp.Factories.StrategyPattern;
using ConsoleApp.Fastories.StrategyPattern;
using System;
using System.Collections.Generic;
using Autofac;
using ConsoleApp.Factories;
using ConsoleApp.Factories.StrategyPattern.Interfaces;

namespace ConsoleApp
{
    /*
     *Используйте предыдущее домашнее задание с эмулятором сканера и
     * по максимуму переведите его на Autofac используя встроенный
     * функционал паттернов и внедрения зависимостей.
     */
    class Program
    {
        static void Main(string[] args)
        {
            ScannerRun();

            Console.ReadKey();
        }


        private static void ScannerRun()
        {
            //ScannerDevice scannerDevice = new ScannerDevice();
            //PdfScanOutputStrategy pdfScanOutput = new PdfScanOutputStrategy();
            //ImageScanOutputStrategy imageScan = new ImageScanOutputStrategy();
            //ScannerLogger logger = new ScannerLogger();
            //DeviceVisitor visitor = new DeviceVisitor();

            DIContainer diContainer = new DIContainer();

            ScannerContext scannerContext = new ScannerContext(
                diContainer.GetContainer.Resolve<IScannerDevice>(),
                diContainer.GetContainer.Resolve<IScannerLogger>(),
                diContainer.GetContainer.Resolve<IMonitorVisitor>());

            scannerContext.SetupOutputScanStrategy(diContainer.GetContainer.Resolve<IScanOutputStrategy>());
            scannerContext.Execute(@"scanText.txt");
        }
    }
}