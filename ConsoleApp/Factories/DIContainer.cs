using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ConsoleApp.Factories.StrategyPattern;
using ConsoleApp.Factories.StrategyPattern.Interfaces;
using ConsoleApp.Fastories.StrategyPattern;

namespace ConsoleApp.Factories
{
    public class DIContainer
    {
        private readonly ContainerBuilder _builder;

        public DIContainer()
        {
            _builder = new ContainerBuilder();

            DIRegister();

            GetContainer = _builder.Build();
        }

        public IContainer GetContainer { get; }

        private void DIRegister()
        {
            _builder.RegisterType<ScannerDevice>().As<IScannerDevice>();
            _builder.RegisterType<PdfScanOutputStrategy>().As<IScanOutputStrategy>();
            _builder.RegisterType<ScannerLogger>().As<IScannerLogger>();
            _builder.RegisterType<DeviceVisitor>().As<IMonitorVisitor>();
        }
    }
}