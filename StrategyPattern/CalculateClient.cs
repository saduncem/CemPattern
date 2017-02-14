using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public class CalculateClient
    {
        private ICalculateInterface calculateInterface;
        public CalculateClient(ICalculateInterface strategy)
         {
            calculateInterface = strategy;
         }
        public int Calculate(int value1, int value2)
        {
            return calculateInterface.Calculate(value1, value2);
        }
    }
}
