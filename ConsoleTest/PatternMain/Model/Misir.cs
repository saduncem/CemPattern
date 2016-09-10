using ConsoleTest.PatternMain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest.PatternMain.Model
{
   public  class Misir:IKumpir
    {
        IKumpir _kumpir;
        public Misir(IKumpir kumpir)
        {
            _kumpir = kumpir;
        }
        public decimal ucret()
        {
            return 2.00m + _kumpir.ucret();
        }
        public string aciklama()
        {
            return "Mısırlı " + _kumpir.aciklama();
        }
    }
}
