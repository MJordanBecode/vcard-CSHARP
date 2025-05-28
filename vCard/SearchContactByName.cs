namespace vCard_CSHARP;

public class SearchContactByName
{
    private string line;
    public string Name { get; set; }

    public SearchContactByName(string name)
    {
        Name = name;
    }

    public List<List<string>> SomeMethod()
    {
        List<List<string>> foundContacts = new(); 

        if (string.IsNullOrWhiteSpace(Name))
        {
            Console.WriteLine("❗ You must enter a name to search.");
            return foundContacts;
        }

        ReadFileVCF test = new ReadFileVCF();
        string path = test.PathForAll;

        using StreamReader sr = new StreamReader(path);
        List<string> currentCard = new List<string>();
        bool insideCard = false;

        string line = sr.ReadLine();
        while (line != null)
        {
            if (line == "BEGIN:VCARD")
            {
                insideCard = true;
                currentCard.Clear();
                currentCard.Add(line);
            }
            else if (insideCard)
            {
                currentCard.Add(line);

                if (line == "END:VCARD")
                {
                    // Vérifie si le nom correspond
                    bool nameMatched = currentCard.Any(l =>
                        l.StartsWith("FN:") &&
                        l.Substring(3).Trim().Equals(Name, StringComparison.OrdinalIgnoreCase));

                    if (nameMatched)
                    {
                        // Ajoute une copie du contact trouvé
                        foundContacts.Add(new List<string>(currentCard));
                        for (int i = 0; i < foundContacts.Count; i++)
                        {
                            foreach (var lineInContact in foundContacts[i])
                            {
                                Console.WriteLine(lineInContact);
                            }
                            Console.WriteLine(); // Pour espacer entre les contacts
                        }

                        {
                            
                        }
                    }

                    insideCard = false;
                    currentCard.Clear();
                }
            }

            line = sr.ReadLine();
        }

        if (foundContacts.Count == 0)
        {
            Console.WriteLine("❌ Aucun contact ne correspond au nom saisi.");
        }

        return foundContacts; // Retourne les contacts trouvés
    }
}