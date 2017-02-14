using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDesing
{
   public  class SingleTonTest
    {
        private static SingleTonTest instance;

        private SingleTonTest() { }
        public void DisplayMessage()
        {
            Console.WriteLine("My First SingleTon Program");
        }
        public static SingleTonTest InstanceCreation
        {
            get
                 {
                    if (instance == null)
                    {
                    instance = new SingleTonTest();
                    }
                    return instance;
                 }
        }
    }

}