using FluentInterface.FluentInterfacePattern;
using FluentInterface.TraditionalCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternTest.Creational
{
   [TestClass]
   public class FluentInterfaceTest
   {
      private const string CATEGORY_NAME = "Fluent interface";

      [TestMethod, TestCategory(CATEGORY_NAME)]
	   public void TraditionalCode_PersonFinderTest_Example1()
      {
         var finder = new PersonFinder();
         finder.FirstName = "Jan";
         finder.LastName = "Kowalski";
         finder.Address = "Kraków, ul. Królewska 22";
         finder.CorrespondenceAddress = "Kraków, ul. Lea 112";
         finder.IncludePhoto = true;

         var persons = finder.Find();
      }

      [TestMethod, TestCategory(CATEGORY_NAME)]
      public void TraditionalCode_PersonFinderTest_Example2()
      {
         var finder = new PersonFinder("Jan", "Kowalski", "Kraków, ul. Królewska 22", "Kraków, ul. Lea 112", true);
         
         var persons = finder.Find();
      }

      [TestMethod, TestCategory(CATEGORY_NAME)]
      public void FluentInterface_PersonFinderFluent01_Simple()
      {
         var persons = new PersonFinderFluent()
            .FirstName("Jan")
//            .LastName("Kowalski")
            .Address("Kraków, ul. Królewska 22")
            .CorrespondenceAddress("Kraków, ul. Lea 112")
            .IncludePhoto
               .Find();
      }

      [TestMethod, TestCategory(CATEGORY_NAME)]
      public void FluentInterface_PersonFinderFluent02_Interface()
      {
         var persons = new PersonFinderFluentInterface()
            .FirstName("Jan")
            .LastName("Kowalski")
            .Address("Kraków, ul. Królewska 22")
            .CorrespondenceAddress("Kraków, ul. Lea 112")
            .IncludePhoto
               .Find();
      }

      [TestMethod, TestCategory(CATEGORY_NAME)]
      public void FluentInterface_PersonFinderFluent03_Steps()
      {
         var persons = new PersonFinderFluentInterfaceSteps()
            .SetPID("4561651")
               .SetFirstName("Jan")
               .SetLastName("Kowalski")
               .IncludePhoto
                  .Find();
      }
   }
}