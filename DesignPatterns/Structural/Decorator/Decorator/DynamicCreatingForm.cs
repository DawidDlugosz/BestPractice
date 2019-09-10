using System.Collections.Generic;
using Decorator.Component;
using System.Linq;

namespace Decorator.Decorator
{
   public abstract class DynamicCreatingForm : FormComponent
   {
      protected List<FormComponent> DecoratedForms { get; set; }
      protected abstract List<FormComponent> DefoultForm { get; set; }

      protected DynamicCreatingForm(params FormComponent[] a_decoratedForms)
      {
         if(DecoratedForms == null)
            DecoratedForms = new List<FormComponent>();

         DecoratedForms.AddRange(a_decoratedForms);
         DefoultForm = new List<FormComponent>();
      }

      /// <summary>
      /// Ustawienie właściwości formularza
      /// </summary>
      public override void SetSettings()
      {
         if(DecoratedForms != null)
            DecoratedForms.ForEach(a_singleForm => a_singleForm.SetSettings());
      }

      /// <summary>
      /// Nazwa formularza
      /// </summary>
      public override string FormName
      {
         get
         {
            return string.Format("{0} :\n\t{1}\n\n{2}\n",
                                 SectionName,
                                 string.Join("\n\t ", DefoultForm.Select(a_singleForm =>a_singleForm.FormName)),
                                 string.Join("\n\n", DecoratedForms.Select(a_singleForm =>a_singleForm.FormName)));
         }
      }

      protected void AddNewForm(FormComponent a_singleForm)
      {
         //Dodanie nowego podformularza
         //Wskazanie ścieżki do formularza który będzie zawierał podformularz
      }

      /// <summary>
      /// Renderowanie formularza
      /// </summary>
      protected void RenderForm()
      {
         if(DecoratedForms != null)
            DecoratedForms.ForEach(AddNewForm);
      }

      /// <summary>
      /// Nazwa sekcji
      /// </summary>
      protected abstract string SectionName { get; }
   }
}