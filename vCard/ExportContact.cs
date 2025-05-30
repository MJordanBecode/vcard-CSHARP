using System.IO;
namespace vCard_CSHARP;

public class ExportContact
{
    public string Name { get; set; }
    public string ExportNameFile { get; set; }
    
    public string PathExportContact { get; set; }
    public ExportContact(string name)
    {
        Name =  name;
        ExportNameFile = $"{Name}.cvf";
        PathExportContact = Path.Combine("exportedContact", ExportNameFile);
    }
    
    public void Exportcontact()
    {
        Console.Write("je suis dans le export ZEBI");
        SearchContactByName search = new SearchContactByName($"{Name}");
        List<List<string>> foundContacts = search.SomeMethod();

        string texteFinal = "";
        foreach (List<string> contact in foundContacts)
        {
            
            string contactTexte = string.Join(Environment.NewLine, contact);

            //  Ajouter ce contact au texte final, avec une ligne vide entre chaque contact
            texteFinal += contactTexte + Environment.NewLine + Environment.NewLine;
        }
        
        File.WriteAllText(PathExportContact, texteFinal);
    }

   
}