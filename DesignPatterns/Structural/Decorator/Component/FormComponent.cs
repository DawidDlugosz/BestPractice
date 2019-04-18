namespace Decorator.Component
{
   public class DocumentSetList
   {
      public bool IsRequired { get; set; }
      public string Name { get; set; }
      public DocumentSetListType Type { get; set; }
      public FormComponent Child { get; set; }
      public int ParentId { get; set; }
   }

   public enum DocumentSetListType
   {
      Single,
      WithChildForm
   }


   /// <summary>
   /// Component
   /// </summary>
   public abstract class FormComponent
   {
      protected DocumentSetList m_documentSetList;

      /// <summary>
      /// Ustawienie właściwości formularza
      /// </summary>
      public abstract void SetSettings();

//      /// <summary>
//      /// Renderowanie formularza
//      /// </summary>
//      protected abstract void RenderForm();

      /// <summary>
      /// Ścieżka do formularza
      /// </summary>
      public abstract string FormPath { get; }

      /// <summary>
      /// Nazwa formularza
      /// </summary>
      public abstract string FormName { get; }
   }
}