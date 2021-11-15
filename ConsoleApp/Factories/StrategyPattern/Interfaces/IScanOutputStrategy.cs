namespace ConsoleApp.Factories.StrategyPattern.Interfaces
{
    public interface IScanOutputStrategy
    {
        void ScanAndSave(IScannerDevice scannerDevice, string outputFileName);
    }
}
