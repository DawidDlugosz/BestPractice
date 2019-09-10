namespace FlyWeight.Flyweight3_InterfaceIBlokadaDostepu
{
   public interface IAbstract
   {
      /// <summary>
      /// Id abstraktu
      /// </summary>
      int Id { get; }

      /// <summary>
      /// Opis abstraktur
      /// </summary>
      string Description { get; }

      /// <summary>
      /// Nazwa abstraktu
      /// </summary>
      string Name { get; }

      /// <summary>
      /// Symbol abstraktu
      /// </summary>
      string Symbol { get; }
   }
}