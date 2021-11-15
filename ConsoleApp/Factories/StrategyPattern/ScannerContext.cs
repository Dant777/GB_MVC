using System;
using ConsoleApp.Factories.StrategyPattern.Interfaces;

namespace ConsoleApp.Factories.StrategyPattern
{
    public sealed class ScannerContext
    {
        private readonly IScannerDevice _device;
        private IScanOutputStrategy _currentStrategy;
        private IScannerLogger _logger;
        private IMonitorVisitor _visitor;

        public ScannerContext(IScannerDevice device, IScannerLogger logger, IMonitorVisitor visitor)
        {
            _device = device;
            _logger = logger;
            _visitor = visitor;
        }

        public void SetupOutputScanStrategy(IScanOutputStrategy strategy)
        {
            _currentStrategy = strategy;
        }

        public void Execute(string outputFileName)
        {
            if (_device is null)
            {
                string txt = $"{DateTime.Today.Day} - Device can not be null";
                _logger.Write(txt);
                throw new ArgumentNullException(txt);
            }
            if (_currentStrategy is null)
            {
                string txt = $"{DateTime.Today.Day} - Current scan strategy can not be null";
                _logger.Write(txt);
                throw new ArgumentNullException(txt);
            }
            if (string.IsNullOrWhiteSpace(outputFileName))
            {
                outputFileName = Guid.NewGuid().ToString();
            }
            _currentStrategy.ScanAndSave(_device, outputFileName);

            _device.Accept(_visitor, _logger);
            Console.WriteLine("Успешно!");
        }
    }


}



