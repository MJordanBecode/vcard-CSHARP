using System.IO;
namespace vCard_CSHARP;

public class ReadFileVCF //ReadFile 
{
    
    private string? line;

    public string? PathForAll = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.FullName??".", "contacts.vcf"); 
    public ReadFileVCF()
    {
        try
        {
            StreamReader sr = new StreamReader(PathForAll);
            line = sr.ReadLine();

            while (line != null)
            {
                // Console.WriteLine(line);
                line = sr.ReadLine();
            }

            sr.Close();
            Console.WriteLine(line);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception : " + e.Message);
        }
    }
}