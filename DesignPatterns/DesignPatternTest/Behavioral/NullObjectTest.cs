using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NullObject.Interface;

namespace DesignPatternTest.Behavioral
{
	[TestClass]
	public class NullObjectTest
	{
		private const string CATEGORY_NAME = "Null Object";

		
		[TestMethod, TestCategory(CATEGORY_NAME)]
		[ExpectedException(typeof(NullReferenceException))]
		public void NullObject_TraditionalCode_NotSafety()
		{
         IMethodology metodyka10 = NullObject.TraditionalCode.MetodykaFactory.GetMetodology("10-");
         IMethodology metodyka30 = NullObject.TraditionalCode.MetodykaFactory.GetMetodology("30+");
         IMethodology metodyka40 = NullObject.TraditionalCode.MetodykaFactory.GetMetodology("40+");

         ExecuteMethodology(metodyka10, "10-");
         ExecuteMethodology(metodyka30, "30+");
         ExecuteMethodology(metodyka40, "40+");

			Console.WriteLine("\nZakoñczono wykonywanie");
		}

		[TestMethod, TestCategory(CATEGORY_NAME)]
		public void NullObject_TraditionalCode_Safety()
		{
			IMethodology metodyka10 = NullObject.TraditionalCode.MetodykaFactory.GetMetodology("10-");
         IMethodology metodyka30 = NullObject.TraditionalCode.MetodykaFactory.GetMetodology("30+");
         IMethodology metodyka40 = NullObject.TraditionalCode.MetodykaFactory.GetMetodology("40+");

         CheckMethodologyBeforeExecute(metodyka10, "10-");
         CheckMethodologyBeforeExecute(metodyka30, "30+");
         CheckMethodologyBeforeExecute(metodyka40, "40+");
			
			Console.WriteLine("\nZakoñczono wykonywanie");
		}

      [TestMethod, TestCategory(CATEGORY_NAME)]
      public void NullObject_UsingNullObjectPattenr()
      {
         IMethodology metodyka10 = NullObject.Pattern.MetodykaFactory.GetMetodology("10-");
         IMethodology metodyka30 = NullObject.Pattern.MetodykaFactory.GetMetodology("30+");
         IMethodology metodyka40 = NullObject.Pattern.MetodykaFactory.GetMetodology("40+");

         ExecuteMethodology(metodyka10, "10-");
         ExecuteMethodology(metodyka30, "30+");
         ExecuteMethodology(metodyka40, "40+");

         Console.WriteLine("\nZakoñczono wykonywanie");
      }

	   #region [Helpers]
	   private void ExecuteMethodology(IMethodology a_methodology, string a_methodologyKey)
	   {
	      Console.WriteLine();
	      Console.WriteLine(string.Format("Nazwa: \t{0}", a_methodology.Name));
	      Console.WriteLine(string.Format("Klucz: \t{0}", a_methodology.Key));
	      a_methodology.DoSomething();
	      a_methodology.ImportantMethod(a_methodologyKey);
	   }

	   private void CheckMethodologyBeforeExecute(IMethodology a_methodology, string a_methodologyKey)
	   {
	      if (a_methodology != null)
	         ExecuteMethodology(a_methodology, a_methodologyKey);
	   }
	   #endregion
	}
}