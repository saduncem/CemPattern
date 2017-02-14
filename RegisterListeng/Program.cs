using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace RegisterListeng
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                while (true)
                {
                    string sRegPath = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings";
                    int proxyStatus = (int) Registry.GetValue(sRegPath,"ProxyEnable",0);
                    if (proxyStatus == 1)
                    {
                        Registry.SetValue(sRegPath, "ProxyEnable",0);
                        Console.WriteLine("{0}  Zaman :{1}", "Register Değişti",DateTime.Now);
                       
                    }
                    System.Threading.Thread.Sleep(60000);
                    Console.WriteLine("{0}", Registry.GetValue(sRegPath, "ProxyEnable", 0).ToString());
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("{0}","Hata");
            }
            
        }


    }
}
