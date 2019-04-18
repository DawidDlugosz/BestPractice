using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mediator.Test
{
	[TestClass]
	public class MediatorTest
	{
		private const string CATEGORY_NAME = "Mediator";

		[TestMethod, TestCategory(CATEGORY_NAME)]
		public void Mediator_ChatroomTest()
		{
			Participant kuba = new Participant("Kuba");
			Participant bartek = new Participant("Bartek");
			Participant dawid = new Participant("Dawid");
			Participant marta = new Participant("Marta");
			
			Chatroom chatroom = new Chatroom();
			chatroom.Register(kuba);
			chatroom.Register(bartek);
			chatroom.Register(dawid);
			chatroom.Register(marta);

			kuba.Send("Dawid", "Cześć, co słychać?");
			marta.Send("Dawid", "Masz chwilę?");
			bartek.Send("Musimy pogadać");
			dawid.Send("Kuba", "Nudy");
			dawid.Send("Marta", "Właśnie idę na spotkanie");
			dawid.Send("Zapomniałem zablokować komputer dlatego jestem KONIEM");
		}

      [TestMethod, TestCategory(CATEGORY_NAME)]
      public void Mediator_ControlsRelationTest()
      {
         Mediator m = new Mediator();

         TexBox texBox = new TexBox(m, ControlName.TextBox);
         Button addButton = new Button(m, ControlName.PrzyciskDodaj);
         Button clearButton = new Button(m, ControlName.PrzycisWyczysc);
         Window window = new Window(m, ControlName.Okno);

         clearButton.ButtonClick();
         ShowInfo("Wciśnięcie przycisku Wyczyść:", texBox, addButton, clearButton, window);

         texBox.TextWriting("Tekst został wprowadzony.");
         ShowInfo("Wprowadzenie tekstu:", texBox, addButton, clearButton, window);

         addButton.ButtonClick();
         ShowInfo("Wciśnięcie przycisku Dodaj:", texBox, addButton, clearButton, window);
      }

      private void ShowInfo(string a_information, TexBox texBox, Button addButton, Button clearButton, Window window)
      {
         Console.WriteLine(a_information);
         Console.WriteLine("---------------------------------");
         Console.WriteLine(string.Format("{0} - Text: '{1}'", texBox.Name, texBox.Text));
         Console.WriteLine(string.Format("{0} - Text: '{1}'", window.Name, window.Text));
         Console.WriteLine(string.Format("{0} - Enabled: {1}", addButton.Name, addButton.Enabled));
         Console.WriteLine(string.Format("{0} - Enabled: {1}", clearButton.Name, clearButton.Enabled));
         Console.WriteLine();
      }
	}
}
