using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mediator
{
   public class ControlName
   {
      public const string PrzyciskDodaj = "Przycisk Dodaj";
      public const string PrzycisWyczysc = "Przycisk Wyczyść";
      public const string TextBox = "TextBox";
      public const string Okno = "Okno";
   }

   public class Mediator
   {
      readonly List<IControl> m_controls = new List<IControl>();

      public List<IControl> Controls
      {
         get { return m_controls; }
      }

      private IControl GetControlByName(string a_controlName)
      {
         return m_controls.First(ctr => ctr.Name == a_controlName);
      }

      public void ButtonClick(string a_controlName)
      {
         switch (a_controlName)
         {
            case ControlName.PrzyciskDodaj:
            {
               var window = GetControlByName(ControlName.Okno) as Window;
               var textBox = GetControlByName(ControlName.TextBox) as TexBox;
               window.Text = textBox.Text;
               textBox.Text = string.Empty;
               break;
            }
            case ControlName.PrzycisWyczysc:
            {
               var window = GetControlByName(ControlName.Okno) as Window;
               var textBox = GetControlByName(ControlName.TextBox) as TexBox;
               var addButton = GetControlByName(ControlName.PrzyciskDodaj) as Button;

               window.Text = textBox.Text = string.Empty;
               addButton.Enabled = false;
               break;
            }
         }
      }

      public void TextWriting(string a_controlName, string a_text)
      {
         switch (a_controlName)
         {
            case ControlName.TextBox:
            {
               var addButton = GetControlByName(ControlName.PrzyciskDodaj) as Button;
               addButton.Enabled = true;
               break;
            }
         }
      }
   }

   public interface IControl
   {
      Mediator Mediator { get; set; }
      string Name { get; set; }
      ControlType Type { get; }
   }


   public abstract class ControlBase : IControl
   {
      protected ControlBase(Mediator a_mediator, string a_name)
      {
         Mediator = a_mediator;
         Name = a_name;
         Mediator.Controls.Add(this);
      }

      public abstract ControlType Type { get; }

      public Mediator Mediator { get; set; }

      public string Name { get; set; }
   }

   public enum ControlType
   {
      TextBox,
      Button,
      Window
   }

   public class TexBox : ControlBase
   {
      public TexBox(Mediator a_mediator, string a_name) 
         : base(a_mediator, a_name)
      {}

      public override ControlType Type
      {
         get { return ControlType.TextBox; }
      }

      public string Text { get; set; }

      public void TextWriting(string a_text)
      {
         Mediator.TextWriting(Name, a_text);
         Text = a_text;
      }
   }

   public class Button : ControlBase
   {
      public Button(Mediator a_mediator, string a_name)
         : base(a_mediator, a_name)
      {
         Enabled = true;
      }

      public override ControlType Type
      {
         get { return ControlType.Button; }
      }

      public bool Enabled { get; set; }

      public void ButtonClick()
      {
         Mediator.ButtonClick(Name);
      }
   }

   public class Window : ControlBase
   {
      public Window(Mediator a_mediator, string a_name)
         : base(a_mediator, a_name)
      { }

      public string Text { get; set; }

      public override ControlType Type
      {
         get { return ControlType.Window; }
      }
   }
}
