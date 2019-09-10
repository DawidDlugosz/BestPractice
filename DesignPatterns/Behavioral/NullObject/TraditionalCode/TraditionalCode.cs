using System;
using NullObject.Interface;

namespace NullObject.TraditionalCode
{
   public abstract class Methodology : IMethodology
	{
		public abstract string Name { get; }
		public abstract Guid Key { get; }
		public abstract void DoSomething();
      public abstract void ImportantMethod(string a_value);
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
					return null;
			}
		}
	}
}
