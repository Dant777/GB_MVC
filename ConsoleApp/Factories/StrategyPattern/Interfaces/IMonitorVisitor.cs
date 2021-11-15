namespace ConsoleApp.Factories.StrategyPattern.Interfaces
{
    public interface IMonitorVisitor
    {
        void VisitScanner(IScannerDevice info, IScannerLogger logger);
        
    }
}