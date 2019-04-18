using Decorator.Component;

namespace Decorator.ConcreteComponent
{
   public class DokumentyZatwierdzoneZaOstatniRokObrotowy : FormComponent
   {
      private readonly bool m_isRequired;

      public DokumentyZatwierdzoneZaOstatniRokObrotowy(bool a_isRequired)
      {
         m_isRequired = a_isRequired;
      }

      /// <summary>
      /// Ustawienie właściwości formularza
      /// </summary>
      public override void SetSettings()
      {
         //Ustawienie wymagalności widoczności
         m_documentSetList.IsRequired = m_isRequired;
         m_documentSetList.Name = FormName;
         m_documentSetList.Type = DocumentSetListType.Single;
      }

      public override string FormPath
      {
         get { return "Formularze/ModulAnaliz/Rating/WyborDokumentow/FormularzZListaZestawowDokumentu"; }
      }

      public override string FormName
      {
         get { return "Zatwierdzone za ostatni rok obrotowy - " + m_isRequired.ToString(); }
      }
   }

   public class DokumentyZatwierdzoneZaPoprzedniRokObrotowy : FormComponent
   {
      private readonly bool m_isRequired;

      public DokumentyZatwierdzoneZaPoprzedniRokObrotowy(bool a_isRequired)
      {
         m_isRequired = a_isRequired;
      }

      /// <summary>
      /// Ustawienie właściwości formularza
      /// </summary>
      public override void SetSettings()
      {
         //Ustawienie wymagalności widoczności
         m_documentSetList.IsRequired = m_isRequired;
         m_documentSetList.Name = FormName;
         m_documentSetList.Type = DocumentSetListType.Single;
      }

      public override string FormPath
      {
         get { return "Formularze/ModulAnaliz/Rating/WyborDokumentow/FormularzZListaZestawowDokumentu"; }
      }

      public override string FormName
      {
         get { return "Zatwierdzony za poprzedni rok obrotowy - " + m_isRequired.ToString(); }
      }
   }

   public class DokumentySrodroczne : FormComponent
   {
      private readonly bool m_isRequired;

      public DokumentySrodroczne(bool a_isRequired)
      {
         m_isRequired = a_isRequired;
      }

      /// <summary>
      /// Ustawienie właściwości formularza
      /// </summary>
      public override void SetSettings()
      {
         //Ustawienie wymagalności widoczności
         m_documentSetList.IsRequired = m_isRequired;
         m_documentSetList.Name = FormName;
         m_documentSetList.Type = DocumentSetListType.Single;
      }

      public override string FormPath
      {
         get { return "Formularze/ModulAnaliz/Rating/WyborDokumentow/FormularzZListaZestawowDokumentu"; }
      }

      public override string FormName
      {
         get { return "Śródroczne - " + m_isRequired.ToString(); }
      }
   }

   public class DokumentySrodroczneZaOstatniKwartal : FormComponent
   {
      private readonly bool m_isRequired;

      public DokumentySrodroczneZaOstatniKwartal(bool a_isRequired)
      {
         m_isRequired = a_isRequired;
      }

      /// <summary>
      /// Ustawienie właściwości formularza
      /// </summary>
      public override void SetSettings()
      {
         //Ustawienie wymagalności widoczności
         m_documentSetList.IsRequired = m_isRequired;
         m_documentSetList.Name = FormName;
         m_documentSetList.Type = DocumentSetListType.Single;
      }

      public override string FormPath
      {
         get { return "Formularze/ModulAnaliz/Rating/WyborDokumentow/FormularzZListaZestawowDokumentu"; }
      }

      public override string FormName
      {
         get { return "Śródroczne za ostatni kwartał - " + m_isRequired.ToString(); }
      }
   }

   public class DokumentyPrognozowane : FormComponent
   {
      private readonly bool m_isRequired;
      private readonly FormComponent m_childForm;

      public DokumentyPrognozowane(bool a_isRequired, FormComponent a_childForm)
      {
         m_isRequired = a_isRequired;
         m_childForm = a_childForm;
      }

      /// <summary>
      /// Ustawienie właściwości formularza
      /// </summary>
      public override void SetSettings()
      {
         //Ustawienie wymagalności widoczności
         m_documentSetList.IsRequired = m_isRequired;
         m_documentSetList.Name = FormName;
         m_documentSetList.Type = DocumentSetListType.WithChildForm;
         m_documentSetList.Child = m_childForm;
      }

      public override string FormPath
      {
         get { return "Formularze/ModulAnaliz/Rating/WyborDokumentow/FormularzZListaZestawowPrognozowanych"; }
      }

      public override string FormName
      {
         get { return "Prognozy - " + m_isRequired.ToString(); }
      }
   }

   public class ZestawyWchodzaceWSkladPrognozy : FormComponent
   {
      private readonly bool m_isRequired;
      private int ParentId { get; set; }
      private readonly string m_name;

      public ZestawyWchodzaceWSkladPrognozy(bool a_isRequired, string a_name)
      {
         m_isRequired = a_isRequired;
         m_name = a_name;
      }

      /// <summary>
      /// Ustawienie właściwości formularza
      /// </summary>
      public override void SetSettings()
      {
         //Ustawienie wymagalności widoczności
         m_documentSetList.IsRequired = m_isRequired;
         m_documentSetList.Name = FormName;
         m_documentSetList.Type = DocumentSetListType.Single;
         m_documentSetList.ParentId = ParentId;
      }

      public override string FormPath
      {
         get { return "Formularze/ModulAnaliz/Rating/WyborDokumentow/FormularzZListaZestawowDokumentu"; }
      }

      public override string FormName
      {
         get { return m_name + " - " + m_isRequired.ToString(); }
      }
   }
}