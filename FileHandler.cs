using System;
using System.IO;
class FileHandler
{
    public static void loadFile(String fileName)
    {
        try
        {
            StreamReader sr = new StreamReader(fileName);

            String line = sr.ReadLine();

            while (line != null)
            {
                System.Console.WriteLine(line);
                line = sr.ReadLine();
            }
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
        }
    }
}