using System;
using Decorator.Component;
using Decorator.ConcreteDecorator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Singleton.Test
{
   [TestClass]
   public class DecoratorTest
   {
      private const string CATEGORY_NAME = "Decorator";

      [TestMethod, TestCategory(CATEGORY_NAME)]
      public void Test()
      {
         FormComponent dokumenty = new Zatwierdzone(true, false,
                                    new Srodroczne(false, true, 
                                    new Prognozy(true, false, "Okres obliczeniowy")
                                             ));

         Console.WriteLine(dokumenty.FormName);
      }
   }
}