using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Singleton.Test
{
   public class ClassForTest
   {
   }

	/// <summary>
	/// Summary description for SingletonTest
	/// </summary>
	[TestClass]
	public class SingletonTest
	{
      readonly int[] m_instanceQuantity = new int[10000000];
      private const string CATEGORY_NAME = "Singleton";
	   private Stopwatch m_watch;

      [TestMethod, TestCategory(CATEGORY_NAME)]
	   public void SimpleObject_Test()
      {
         m_watch = new Stopwatch();
         m_watch.Start();
	      ClassForTest[] notSingletons = m_instanceQuantity
	         .AsParallel()
	         .Select(x => new ClassForTest())
            .ToArray();
         ShowExecutingTime();

	      ValidateSingletonInstance(notSingletons, "NotSingleton");
	   }

      [TestMethod, TestCategory(CATEGORY_NAME)]
      public void Singleton1_Test()
		{
         m_watch = new Stopwatch();
         m_watch.Start();
		   Singleton1_NotThreadSafe[] singletons = m_instanceQuantity
		                                             .AsParallel()
		                                             .Select(a_x => Singleton1_NotThreadSafe.Instance)
                                                   .ToArray();
         ShowExecutingTime();
         ValidateSingletonInstance(singletons, "Singleton1");
		}

      [TestMethod, TestCategory(CATEGORY_NAME)]
      public void Singleton2_Test()
      {
         m_watch = new Stopwatch();
         m_watch.Start();
         Singleton2_ThreadSafety_Simple[] singletons = m_instanceQuantity
            .AsParallel()
            .Select(x => Singleton2_ThreadSafety_Simple.Instance)
            .ToArray();
         ShowExecutingTime();

         ValidateSingletonInstance(singletons, "Singleton2");
      }

      [TestMethod, TestCategory(CATEGORY_NAME)]
      public void Singleton3_Test()
      {
         m_watch = new Stopwatch();
         m_watch.Start();
         Singleton3_ThreadSafety_DoubleCheckLock[] singletons = m_instanceQuantity
            .AsParallel()
            .Select(x => Singleton3_ThreadSafety_DoubleCheckLock.Instance)
            .ToArray();
         ShowExecutingTime();

         ValidateSingletonInstance(singletons, "Singleton3");
      }

      [TestMethod, TestCategory(CATEGORY_NAME)]
      public void Singleton4_Test()
      {
         m_watch = new Stopwatch();
         m_watch.Start();
         Singleton4_ThreadSafety_WithoutUsingLock[] singletons = m_instanceQuantity
            .AsParallel()
            .Select(x => Singleton4_ThreadSafety_WithoutUsingLock.Instance)
            .ToArray();
         ShowExecutingTime();

         ValidateSingletonInstance(singletons, "Singleton4");
      }

      [TestMethod, TestCategory(CATEGORY_NAME)]
      public void Singleton5_Test()
      {
         m_watch = new Stopwatch();
         m_watch.Start();
         Singleton5_ThreadSafety_FullyLazy[] singletons = m_instanceQuantity
            .AsParallel()
            .Select(x => Singleton5_ThreadSafety_FullyLazy.Instance)
            .ToArray();
         ShowExecutingTime();

         ValidateSingletonInstance(singletons, "Singleton5");
      }

      [TestMethod, TestCategory(CATEGORY_NAME)]
      public void Singleton6_Test()
      {
         m_watch = new Stopwatch();
         m_watch.Start();
         ClassForTest[] singletons = m_instanceQuantity
            .AsParallel()
            .Select(x => Singleton6_ThreadSafety_FullyLazy_Generic<ClassForTest>.Generate)
            .ToArray();
         ShowExecutingTime();

         ValidateSingletonInstance(singletons, "Singleton6");
      }

      [TestMethod, TestCategory(CATEGORY_NAME)]
      public void Singleton6_InicjalizacjiaKilkuTypow()
      {
         m_watch = new Stopwatch();
         m_watch.Start();
         ClassForTest[] singletons = m_instanceQuantity
            .AsParallel()
            .Select(x => Singleton6_ThreadSafety_FullyLazy_Generic<ClassForTest>.Generate)
            .ToArray();
         ShowExecutingTime();

         ValidateSingletonInstance(singletons, "Singleton6 - Inicjalizacjia obiektu 'ClassForTest'");


         m_watch = new Stopwatch();
         m_watch.Start();
         Object[] singletons2 = m_instanceQuantity
            .AsParallel()
            .Select(x => Singleton6_ThreadSafety_FullyLazy_Generic<Object>.Generate)
            .ToArray();
         ShowExecutingTime();

         ValidateSingletonInstance(singletons2, "Singleton6 - Inicjalizacjia obiektu 'Object'");


         m_watch = new Stopwatch();
         m_watch.Start();
         ClassForTest[] singletons3 = m_instanceQuantity
            .AsParallel()
            .Select(x => Singleton6_ThreadSafety_FullyLazy_Generic<ClassForTest>.Generate)
            .ToArray();
         ShowExecutingTime();
         ValidateSingletonInstance(singletons3, "Singleton6 - Ponowna inicjalizacjia obiektu 'ClassForTest'");

         for (int i = 0; i < singletons.Length; i++)
         {
            Assert.AreSame(singletons[i], singletons3[i], string.Format("Obiekty {0} i {1} stworzone za pomocą '{2}' mają inną instancję.", i - 1, i, "Generica"));
         }
         Console.WriteLine("OK");
      }


	   #region [Helpers]

	   private void ShowExecutingTime()
	   {
	      m_watch.Stop();
	      Console.WriteLine("Czas wykonania: {0} [ms]/{1:N} [Ticks]",
	                        m_watch.Elapsed.Milliseconds,
	                        m_watch.Elapsed.Ticks);
	   }

	   private static void ValidateSingletonInstance(object[] a_singletons,
	                                                 string a_validationName)
	   {
	      for (int i = 1; i < a_singletons.Length; i++)
	      {
	         Assert.AreSame(a_singletons[i],
	                        a_singletons[i - 1],
	                        string.Format(
	                           "Obiekty {0} i {1} stworzone za pomocą '{2}' mają inną instancję.",
	                           i - 1,
	                           i,
	                           a_validationName));
	      }
	      Console.WriteLine("OK");
	   }

	   #endregion
	}
}
