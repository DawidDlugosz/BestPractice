namespace FlyWeight.Flyweight3_InterfaceIBlokadaDostepu
{
   /// <summary>
   /// Klasa reprezentuje konkretny abstrakt wchodzący w skład dokumentu
   /// Kożystamy już bezpośrednio z fabryki aby pobrać konkretny abstrakt
   /// </summary>
   public class DocumentField
   {
      private readonly IAbstract m_abstract;

      public DocumentField(int a_documentId, decimal a_value, string a_abstractSymbol)
      {
         m_abstract = AbstractFactory.GetAbstract(a_abstractSymbol);
         DocumentId = a_documentId;
         Value = a_value;
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
      public int Id { get { return m_abstract.Id; } }

      /// <summary>
      /// Opis abstraktur
      /// </summary>
      public string Description { get { return m_abstract.Description; } }

      /// <summary>
      /// Nazwa abstraktu
      /// </summary>
      public string Name { get { return m_abstract.Name; } }

      /// <summary>
      /// Symbol abstraktu
      /// </summary>
      public string Symbol { get { return m_abstract.Symbol; } }
   }
}