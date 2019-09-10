using System.Collections.Generic;

namespace FlyWeight.Flyweight3_InterfaceIBlokadaDostepu
{
   /// <summary>
   /// Fabryka zwracająca konkretny abstrakt
   /// </summary>
   public class AbstractFactory
   {
      /// <summary>
      /// Klasa zawiera tylko niezmienne wartości (Pyłek)
      /// Implementacja interfejsu
      /// Klasa wewnętrzna prywatna z konstruktorem dostępnym tylko dla fabryki
      /// </summary>
      private class Abstract : IAbstract
      {
         internal Abstract(string a_symbol, string a_name, string a_description, int a_id)
         {
            Symbol = a_symbol;
            Name = a_name;
            Description = a_description;
            Id = a_id;
         }

         /// <summary>
         /// Id abstraktu
         /// </summary>
         public int Id { get; private set; }

         /// <summary>
         /// Opis abstraktur
         /// </summary>
         public string Description { get; private set; }

         /// <summary>
         /// Nazwa abstraktu
         /// </summary>
         public string Name { get; private set; }

         /// <summary>
         /// Symbol abstraktu
         /// </summary>
         public string Symbol { get; private set; }
      }

      private static readonly Dictionary<string, Abstract> Sm_mAbstracts = new Dictionary<string, Abstract>();

      public AbstractFactory()
      {
         Sm_mAbstracts.Add("MIESIECZNA_SPPWKP", new Abstract("MIESIECZNA_SPPWKP", "MIESIECZNA_STAWKA_PODATKU_PLACONEGO_WEDLUG_KARTY_PODATKOWEJ", "Miesięczna stawka podatku płaconego według karty podatkowej", 114));
         Sm_mAbstracts.Add("INWESTYCJE_K", new Abstract("INWESTYCJE_K", "INWESTYCJE_KROTKOTERMINOWE", "Zmiany pozycji sprawozdania finansowego  i wskaźników", 115));
         Sm_mAbstracts.Add("AKTYWA_RSB", new Abstract("AKTYWA_RSB", "AKTYWA_RAZEM_SUMA_BILANSOWA", "Aktywa razem suma bilansowa", 116));
         Sm_mAbstracts.Add("AMORTYZACJA", new Abstract("AMORTYZACJA", "AMORTYZACJA", "Amortyzacja", 117));
      }

      public static IAbstract GetAbstract(string a_symbol)
      {
         Abstract abstractResult;
         Sm_mAbstracts.TryGetValue(a_symbol, out abstractResult);
         return abstractResult;
      }
   }
}