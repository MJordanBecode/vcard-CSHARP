namespace vCard_CSHARP;

public class DeleteContactByName
{
    public string Name { get; set; }


    public DeleteContactByName(string name)
    {
        Name = name;
    }

    public  void DeleteContact()
    {
        SearchContactByName deleteByName = new SearchContactByName($"{Name}");
        List<List<string>> foundContacts = deleteByName.SomeMethod();
        
        ReadFileVCF fileReader = new ReadFileVCF();
        string path = fileReader.PathForAll;
        List<string> allLines = File.ReadAllLines(path).ToList();

        foreach (var contact in foundContacts)
        {
            for (int i = 0; i < allLines.Count - contact.Count; i++)
            {
                if (allLines.GetRange(i, contact.Count).SequenceEqual(contact))
                {
                    allLines.RemoveRange(i, contact.Count);
                    Console.WriteLine("✅ Contact Delete With Success.");
                    break;
                }
            }
        }
        File.WriteAllLines(path, allLines);
        
    }

}