using System;
using System.IO;
using System.Text;

namespace vCard_CSHARP;

public class AddContact
{
    //Declaration of variables 
    private string? _fn;
    public string?  Fn {get => _fn; set => _fn = value;}
    private string?  _mail;
    public string?  Email {get => _mail; set=> _mail = value;}
    private string?  _phone;
    public string?  Phone {get => _phone; set => _phone = value;}


    private Dictionary<string, string> information;
    
    public  AddContact(string? fn, string? mail, string? phone)
    {
       
        Fn = fn;
        Email = mail;
        Phone = phone;

        information = new Dictionary<string, string>
        {
            { "BEGIN", "VCARD" },
            { "FN",  Fn },
            { "TEL", Phone },
            { "EMAIL", Email },
            { "END", "VCARD" },
        };
    }

    public string ShowItem()
    {
        StringBuilder sb = new StringBuilder();
        
        foreach (var item in information)
        {
            sb.AppendLine($"{item.Key}:{item.Value}");
        }
        
        //Add empty line 
        sb.AppendLine();
        return sb.ToString();
    }

    public void SaveToVcf(string filePath)
    {
        File.AppendAllText(filePath, ShowItem());
    }
   
}