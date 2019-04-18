namespace FlyWeight.Flyweight2_Fabryka
{
   /// <summary>
   /// Klasa zawiera tylko niezmienne wartości (Pyłek)
   /// </summary>
   public class Abstract
   {
      public Abstract(string a_symbol, string a_name, string a_description, int a_id)
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
}