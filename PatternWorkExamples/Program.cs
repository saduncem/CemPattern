using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingletonDesing;
using StrategyPattern;

namespace PatternWorkExamples
{
   public class Program
    {
        
        static void Main(string[] args)
        {
           CalculateClient client = new CalculateClient(new Minus());
             var sonuc = client.Calculate(1, 2);
            Console.WriteLine(string.Format("sonuc :{0}",sonuc));
            CalculateClient plusus = new CalculateClient(new Plussus());
            var p = plusus.Calculate(1, 2);
            Console.WriteLine(string.Format("sonuc :{0}", p));
            SingleTonTest.InstanceCreation.DisplayMessage();
        }
    }
}
