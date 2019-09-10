using System;
using NullObject.Interface;

namespace NullObject.Pattern
{
   public abstract class Methodology : IMethodology, INullObject
   {
      public abstract string Name { get; }
      public abstract Guid Key { get; }
      public abstract void DoSomething();
      public abstract void ImportantMethod(string a_value);

      public virtual bool IsNull
      {
         get { return false; }
      }
   }

   public sealed class NullMethodology : Methodology
   {
      #region [Constuctors]
      private NullMethodology()
      {
      }

      public static NullMethodology Instance
      {
         get { return SingletonConstructor.m_instance; }
      }

      private class SingletonConstructor
      {
         static SingletonConstructor()
         {
         }

         internal static readonly NullMethodology m_instance =
            new NullMethodology();
      }
      #endregion
      
      public override string Name
      {
         get { return string.Empty; }
      }

      public override Guid Key
      {
         get { return Guid.Empty; }
      }

      public override void DoSomething()
      {
         //do nothing
      }

      public override void ImportantMethod(string a_value)
      {
         //np: Logujemy specyficzny komunikat do bazy
         Console.WriteLine(string.Format("Metodyka {0} - Brak implementacji metody ImportantMethod dla tej metodyki", a_value));
      }

      public override bool IsNull
      {
         get { return true; }
      }
   }

	class Methodology10M : Methodology
	{
		public override string Name
		{
			get { return "Metodyka 10-"; }
		}

		public override Guid Key
		{
			get { return new Guid(); }
		}

		public override void DoSomething()
		{
			Console.WriteLine("Metodyka 10- metoda Do Something");
		}

	   public override void ImportantMethod(string a_value)
	   {
         Console.WriteLine(string.Format("Metodyka {0} metoda Wykonuje bardzo ważną czynność", a_value));
	   }
	}

	class Methodology30P : Methodology
	{
		public override string Name
		{
			get { return "Metodyka 30+"; }
		}

		public override Guid Key
		{
			get { return new Guid(); }
		}

		public override void DoSomething()
		{
			Console.WriteLine("Metodyka 30+ metoda Do Something");
		}

	   public override void ImportantMethod(string a_value)
	   {
         Console.WriteLine(string.Format("Metodyka {0} metoda Wykonuje bardzo ważną czynność", a_value));
	   }
	}

	public static class MetodykaFactory
	{
		public static Methodology GetMetodology(string a_kodMetodyki)
		{
			switch (a_kodMetodyki)
			{
				case "10-":
					return new Methodology10M();
				case "30+":
					return new Methodology30P();
				default:
					return NullMethodology.Instance;
			}
		}
	}
}
