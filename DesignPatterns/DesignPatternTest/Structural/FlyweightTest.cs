using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flyweight.Test
{
   [TestClass]
   public class FlyweightTest
   {
      readonly int[] m_instanceQuantity = new int[10000000];
      private const string CATEGORY_NAME = "Flyweight";

      private long MemoryUsed 
      {
         get { return Process.GetCurrentProcess().PagedMemorySize64; }
      }

      [TestMethod, TestCategory(CATEGORY_NAME)]
      public void MemoryTest_SimpleObjectAndFlyweight()
      {
         long usedMemory = MemoryUsed;
         
         FlyWeight.Flyweight0.DocumentField[] instance = m_instanceQuantity
            .AsParallel()
            .Select(x => new FlyWeight.Flyweight0.DocumentField("INWESTYCJE_K", 
                                                                "INWESTYCJE_KROTKOTERMINOWE", 
                                                                "Zmiany pozycji sprawozdania finansowego  i wskaźników",
                                                                1,
                                                                123.87M,
                                                                115)
            ).ToArray();
         long actualMemory = MemoryUsed;
         long usedMemory2 = actualMemory - usedMemory;
         Console.WriteLine(string.Format("Ilość tworzonych obiektów:  \t{0:N0}", m_instanceQuantity.Length));
         Console.WriteLine();
         Console.WriteLine(string.Format("Obiekty zwykłe wymagają:    \t{0:N0} [KB] pamięci", usedMemory2 / 1024));
         
         usedMemory = MemoryUsed;
         FlyWeight.Flyweight3_InterfaceIBlokadaDostepu.DocumentField[] flyweightInstance = m_instanceQuantity
            .AsParallel()
            .Select(x => new FlyWeight.Flyweight3_InterfaceIBlokadaDostepu.DocumentField(1, 
                                                                                         123.87M, 
                                                                                         "INWESTYCJE_K"))
            .ToArray();

         actualMemory = MemoryUsed;
         long usedMemory3 = actualMemory - usedMemory;
         Console.WriteLine(string.Format("Obiekty Flyweight wymagają: \t{0:N0} [KB] pamięci", usedMemory3/1024));
         Console.WriteLine();
         Console.WriteLine(string.Format("Użycie wzorca oszczędza nam {0:N0}[KB] pamięci.", (usedMemory2 - usedMemory3)/1024));
      }
   }
}
