using System;
using vCard_CSHARP;

namespace vCard_CSHARP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Fonction utilitaire pour centrer du texte
            void CenteredWriteLine(string text)
            {
                int consoleWidth = Console.WindowWidth;
                int padding = Math.Max((consoleWidth - text.Length) / 2, 0);
                Console.WriteLine(new string(' ', padding) + text);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            CenteredWriteLine("╔════════════════════════════════════╗");
            CenteredWriteLine("║     ✨ Welcome to the VCard! ✨      ║");
            CenteredWriteLine("╚════════════════════════════════════╝");
            Console.ResetColor();
            string? response;
            string? test;
            do 
            {


                Console.ForegroundColor = ConsoleColor.Blue;
                CenteredWriteLine(""); // ligne vide centrée
                CenteredWriteLine("You can choose an option:");
                CenteredWriteLine(""); // espace
                CenteredWriteLine("1. Show all contact");
                CenteredWriteLine("2. Add a new contact");
                CenteredWriteLine("3. Search Contact by name");
                CenteredWriteLine("4. Delete Contact by name");
                CenteredWriteLine("5. Export a contact into a separate file (.vcf)");
                CenteredWriteLine("6. Exit");
                CenteredWriteLine(""); // ligne vide
                Console.ResetColor();

                static void AfficherPromptCentre(string prompt)
                {
                    int consoleWidth = Console.WindowWidth;
                    int promptX = (consoleWidth - prompt.Length) / 2;
                    int promptY = Console.CursorTop;

                    Console.SetCursorPosition(promptX, promptY);
                    Console.Write(prompt);
                }
            
                AfficherPromptCentre("Choose an option: ");

                // Lis la réponse juste à côté du prompt
                response = Console.ReadLine();
                switch (response)
                {
                    case "1":
                        CenteredWriteLine("📇 Displaying all contacts...");
                        DisplayAllContact displayAllContact = new DisplayAllContact();
                        displayAllContact.DisplayAllListContact();
                        break;
                    case "2":
                        CenteredWriteLine("➕ Adding a new contact...");
                        string Name, Email, Phone;
                        List<string> containerPhrase = new List<string> { "FirstName : ", "LastName : ", "Email : ", "Phone : " };
                        List<string> dataNewContact = new List<string> {  };
                        for (int i = 0; i < containerPhrase.Count; i++)
                        {
                            
                            AfficherPromptCentre($"{containerPhrase[i]}");
                            string prompt = Console.ReadLine();
                            dataNewContact.Add(prompt);
                            
                        }
                        AddContact contact = new AddContact(dataNewContact[0], dataNewContact[1], dataNewContact[2], dataNewContact[3]);
                        string? pathForAll = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.FullName??".", "contacts.vcf"); 
                        
                        contact.SaveToVcf(pathForAll);
                        Console.WriteLine(contact.ShowItem());
                       
                        
                        break;
                    case "3":
                        CenteredWriteLine("🔍 Searching contact by name...");
                        string promptSearchByName = Console.ReadLine();
                        Console.Clear();
                        
                        SearchContactByName searchName = new SearchContactByName($"{promptSearchByName}");
                        searchName.SomeMethod();
                        break;
                    case "4":
                        CenteredWriteLine("🗑️ Deleting contact by name...");
                        string promptDeleteName = Console.ReadLine();
                        DeleteContactByName deleteName = new DeleteContactByName($"{promptDeleteName}");
                        deleteName.DeleteContact();
                        break;
                    case "5":
                        CenteredWriteLine("📤 Exporting contact...");
                        string promptExportName = Console.ReadLine();
                        ExportContact teeeeest = new(promptExportName);
                        teeeeest.Exportcontact();
                        break;
                    case "6":
                        CenteredWriteLine("👋 Exiting... Goodbye!");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        CenteredWriteLine("❗ Invalid option. Please try again.");
                        Console.ResetColor();
                        break;
                }

                CenteredWriteLine("Voullez-vous faire un autre traitement ?(Y/N) ");
                test = Console.ReadLine().ToUpper();
                if (test.ToUpper() == "Y")
                {
                    Console.Clear();
                }else if (test.ToUpper() == "N")
                {
                    Console.Clear();
                }

                // ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                // char response = keyInfo.KeyChar;
            }
            while (test != "N");
     
            
            // Console.WriteLine(); // saut de ligne après l’entrée
            
        }


    }
}
