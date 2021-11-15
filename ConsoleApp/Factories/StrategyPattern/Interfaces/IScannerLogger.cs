using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Factories.StrategyPattern.Interfaces
{
    public interface IScannerLogger
    {
        void Write(string txt);
    }
}
