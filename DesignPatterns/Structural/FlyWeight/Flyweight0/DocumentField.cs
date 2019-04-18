namespace FlyWeight.Flyweight0
{
   /// <summary>
   /// Wzorzec strukturalny
   /// Flyweight (waga piórkowa/pyłek)
   /// 
   /// Stosowany tam gdzie małe obiekty występują w bardzo dużych ilościach 
   /// i jest potrzeba aby conajmniej część składowych takiego obiektu 
   /// nie ulegała zmianom.
   /// 
   /// Przykładem mogą być obiekty reprezentujące poszczególne litery w książce elektronicznej.
   ///  </summary>
   public class DocumentField
   {
      public DocumentField(string a_symbol, string a_name, string a_description, int a_id, decimal a_value, int a_documentId)
      {
         Symbol = a_symbol;
         DocumentId = a_documentId;
         Value = a_value;
         Name = a_name;
         Description = a_description;
         Id = a_id;
      }

      /// <summary>
      /// Id dokumentu w którym się znajduje abstrakt
      /// </summary>
      public int DocumentId { get; private set; }

      /// <summary>
      /// Wartość abstraktu
      /// </summary>
      public decimal Value { get; private set; }

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
