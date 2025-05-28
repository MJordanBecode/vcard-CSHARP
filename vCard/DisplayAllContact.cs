namespace vCard_CSHARP;

public class DisplayAllContact
{
    

    
    public void DisplayAllListContact()
    {
        ReadFileVCF file = new ReadFileVCF();
        
        string path = file.PathForAll;
        string line;
        try
        {
            StreamReader sr = new StreamReader(path);
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
    }
}