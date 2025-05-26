using System.IO;
namespace vCard_CSHARP;

public class ReadFileCSF //ReadFile 
{
    
    private string? line;

    private string? PathForAll = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.FullName??".", "contacts.vcf"); 
    public ReadFileCSF()
    {
        try
        {
            StreamReader sr = new StreamReader(PathForAll);
            line = sr.ReadLine();

            while (line != null)
            {
                Console.WriteLine(line);
                line = sr.ReadLine();
            }

            sr.Close();
            Console.WriteLine(line);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception : " + e.Message);
        }
        finally
        {
            Console.WriteLine("Executing finally block");
        }
    }

    public void SearchByName(ReadFileCSF search)
    {
        
    }



}