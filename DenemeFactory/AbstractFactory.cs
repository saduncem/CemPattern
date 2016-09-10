using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeFactory
{

    public abstract class SoyutArabaFabrikasi
    {

        abstract public SoyutArabaKasasi KasaUret();
        abstract public SoyutArabaLastigi LastikUret();
   }

  public  class MercedesFabrikasi : SoyutArabaFabrikasi
   {
       public override SoyutArabaKasasi KasaUret()
       {
           return new MercedesE200();
       }

       public override SoyutArabaLastigi LastikUret()
       {
           return new MercedesLastik();
       }
   }

 public  class FordFabrikasi : SoyutArabaFabrikasi
   {
       public override SoyutArabaKasasi KasaUret()
       {
           return new FordFocus();
       }

       public override SoyutArabaLastigi LastikUret()
       {
           return new FordLastik();
       }
   }

  public  abstract class SoyutArabaKasasi
   {
       abstract public void LastikTak(SoyutArabaLastigi a);
   }
 public  abstract class SoyutArabaLastigi
   {
   }

  public class MercedesE200 : SoyutArabaKasasi
   {
       public override void LastikTak(SoyutArabaLastigi lastik)
       {
           Console.WriteLine(lastik + " lastikli MercedesE200");
       }
   }

  public  class FordFocus : SoyutArabaKasasi
   {
       public override void LastikTak(SoyutArabaLastigi lastik)
       {
           Console.WriteLine(lastik + " lastikli FordFocus");
       }

   }


  public  class MercedesLastik : SoyutArabaLastigi
   {

   }

  public class FordLastik : SoyutArabaLastigi
   {

   }

   public class FabrikaOtomasyon
   {
       private SoyutArabaKasasi ArabaKasasi;
       private SoyutArabaLastigi ArabaLastigi;

       public FabrikaOtomasyon(SoyutArabaFabrikasi fabrika)
       {
           ArabaKasasi = fabrika.KasaUret();
           ArabaLastigi = fabrika.LastikUret();
       }

       public void LastikTak()
       {
           ArabaKasasi.LastikTak(ArabaLastigi);
       }
   }

  
}
