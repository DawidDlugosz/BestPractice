using System.Collections.Generic;

namespace FlyWeight.Flyweight2_Fabryka
{
   /// <summary>
   /// Fabryka zwracaj¹ca konkretny abstrakt
   /// </summary>
   public class AbstractFactory
   {
      private static readonly Dictionary<string, Abstract> Sm_mAbstracts = new Dictionary<string, Abstract>();

      public AbstractFactory()
      {
         Sm_mAbstracts.Add("MIESIECZNA_SPPWKP", new Abstract("MIESIECZNA_SPPWKP", "MIESIECZNA_STAWKA_PODATKU_PLACONEGO_WEDLUG_KARTY_PODATKOWEJ", "Miesiêczna stawka podatku p³aconego wed³ug karty podatkowej", 114));
         Sm_mAbstracts.Add("INWESTYCJE_K", new Abstract("INWESTYCJE_K", "INWESTYCJE_KROTKOTERMINOWE", "Zmiany pozycji sprawozdania finansowego  i wskaŸników", 115));
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