﻿using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace vCard_CSHARP;
//Faire un système qui vérifie le numéro de téléphone, si le numéro de tel est déjà enregistré retourner un message " ce numéro de téléphone est déjà enregistré au nom de : nom prénom email et numéro de la personne
public class AddContact
{
    //Declaration of variables 
    
    private string _firstName;
    public string FirstName {get => _firstName; set => _firstName = value; }
    private string _lastName;
    public string LastName {get => _lastName; set => _lastName = value; }
    private string? _fn;
    public string?  Fn {get => _fn; set => _fn = value;}
    private string?  _mail;
    public string?  Email {get => _mail; set=> _mail = value;}
    private string?  _phone;
    public string?  Phone {get => _phone; set => _phone = value;}


    private Dictionary<string, string> information;
    
    public  AddContact(string? firstName, string? lastName, string? mail, string? phone)
    {
       
        Fn = firstName + " " + lastName;
        Email = mail;
        Phone = phone;

        information = new Dictionary<string, string>
        {
            { "BEGIN", "VCARD" },
            { "FN",  Fn },
            { "TEL", ValidateInput(phone) },
            { "EMAIL", ValidateInput(mail) },
            { "END", "VCARD" },
        };
    }

    public string ShowItem()
    {
        StringBuilder sb = new StringBuilder();
        
        foreach (var item in information)
        {
            sb.AppendLine($"{item.Key}:{item.Value}");
            if (item.Value.Equals("invalid"))
            {
                throw new InvalidDataException("Invalid data");
            }
        }
        
        //Add empty line 
        sb.AppendLine();
        return sb.ToString();
    }

    public void SaveToVcf(string filePath)
    {
        File.AppendAllText(filePath, ShowItem());
    }

    public string ValidateInput(string input)
    {
        var emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        var phonePattern = @"^\+\d{6,15}$";

        if (Regex.IsMatch(input, emailPattern, RegexOptions.IgnoreCase))
        {
            return $"{input}";
        }
        else if (Regex.IsMatch(input, phonePattern))
        {
            return $"{input}";
        }
        else
        {
            return "invalid";
        }
    }
    
}