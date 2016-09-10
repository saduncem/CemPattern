using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTest.PatternMain.Interface;
namespace ConsoleTest.PatternMain.Model
{
    public class Kumpir:IKumpir
    {

        public int PARAMTERID { get; set; }
        public int Name { get; set; }

        public int date;

        public decimal ucret()
        {
            return 0.5M;
        }

        public string aciklama()
        {
            return "Kumpir";
        }
    }
}
