using System.Collections.Generic;
using Decorator.Component;
using Decorator.ConcreteComponent;
using Decorator.Decorator;
using System.Linq;

namespace Decorator.ConcreteDecorator
{
   public class Zatwierdzone : DynamicCreatingForm
   {
      
      public Zatwierdzone(bool a_isRequiredZaOstatniRok, bool a_isRequiredZaPoprzedniRok, params FormComponent[] a_decoratedForms) 
         : base(a_decoratedForms)
      {
         DefoultForm.Add(new DokumentyZatwierdzoneZaOstatniRokObrotowy(a_isRequiredZaOstatniRok));
         DefoultForm.Add(new DokumentyZatwierdzoneZaPoprzedniRokObrotowy(a_isRequiredZaPoprzedniRok));
      }

      public override string FormPath
      {
         get { return "Formularze/ModulAnaliz/Rating/WyborDokumentow/PustyFormularz"; }
      }

      protected override List<FormComponent> DefoultForm { get; set; }

      protected override string SectionName
      {
         get { return "Zatwierdzone"; }
      }
   }

   public class Srodroczne : DynamicCreatingForm
   {
      public Srodroczne(bool a_isRequiredSrodroczne, bool a_isRequiredSrodroczneZa4Kwartal, params FormComponent[] a_decoratedForms)
         : base(a_decoratedForms)
      {
         DefoultForm.Add(new DokumentySrodroczne(a_isRequiredSrodroczne));
         DefoultForm.Add(new DokumentySrodroczneZaOstatniKwartal(a_isRequiredSrodroczneZa4Kwartal));
      }

      public override string FormPath
      {
         get { return "Formularze/ModulAnaliz/Rating/WyborDokumentow/PustyFormularz"; }
      }

      protected override List<FormComponent> DefoultForm { get; set; }


      protected override string SectionName
      {
         get { return "Śródroczne"; }
      }
   }

   public class Prognozy : DynamicCreatingForm
   {
      public Prognozy(bool a_isRequiredPrognozy, bool a_isRequiredChild, string a_childFormName, params FormComponent[] a_decoratedForms)
         : base(a_decoratedForms)
      {
         DefoultForm.Add(new DokumentyPrognozowane(a_isRequiredPrognozy, new ZestawyWchodzaceWSkladPrognozy(a_isRequiredChild, a_childFormName)));
      }

      public override string FormPath
      {
         get { return "Formularze/ModulAnaliz/Rating/WyborDokumentow/PustyFormularz"; }
      }

      protected override List<FormComponent> DefoultForm { get; set; }

      protected override string SectionName
      {
         get { return "Prognozy"; }
      }
   }
}