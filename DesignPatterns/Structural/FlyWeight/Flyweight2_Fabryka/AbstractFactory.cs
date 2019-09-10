using System.Collections.Generic;

namespace FlyWeight.Flyweight2_Fabryka
{
   /// <summary>
   /// Fabryka zwracaj�ca konkretny abstrakt
   /// </summary>
   public class AbstractFactory
   {
      private static readonly Dictionary<string, Abstract> Sm_mAbstracts = new Dictionary<string, Abstract>();

      public AbstractFactory()
      {
         Sm_mAbstracts.Add("MIESIECZNA_SPPWKP", new Abstract("MIESIECZNA_SPPWKP", "MIESIECZNA_STAWKA_PODATKU_PLACONEGO_WEDLUG_KARTY_PODATKOWEJ", "Miesi�czna stawka podatku p�aconego wed�ug karty podatkowej", 114));
         Sm_mAbstracts.Add("INWESTYCJE_K", new Abstract("INWESTYCJE_K", "INWESTYCJE_KROTKOTERMINOWE", "Zmiany pozycji sprawozdania finansowego  i wska�nik�w", 115));
         Sm_mAbstracts.Add("AKTYWA_RSB", new Abstract("AKTYWA_RSB", "AKTYWA_RAZEM_SUMA_BILANSOWA", "Aktywa razem suma bilansowa", 116));
         Sm_mAbstracts.Add("AMORTYZACJA", new Abstract("AMORTYZACJA", "AMORTYZACJA", "Amortyzacja", 117));
      }

      public static Abstract GetAbstract(string a_symbol)
      {
         Abstract abstractResult;
         Sm_mAbstracts.TryGetValue(a_symbol, out abstractResult);
         return abstractResult;
      }
   }
}