using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Factories.StrategyPattern.Interfaces;

namespace ConsoleApp.Factories.StrategyPattern
{
    public class ScannerLogger : IScannerLogger
    {
        public void Write(string txt)
        {
            string writePath = @"ScanLogger.txt";

            string text = txt;

            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(text);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}