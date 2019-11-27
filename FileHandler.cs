using System;
using System.IO;
using System.Collections.Generic;

namespace MovieLibrary
{
    class FileHandler
    {
        /// <summary>
        /// Gives back a Dictionary&lt;String, Dictionary&lt;String, String&gt;&gt;.
        /// </summary>
        /// <param name="fileName"></param>
        public static Dictionary<String, Dictionary<String, String>> loadFromINI(String fileName)
        {
            try
            {
                StreamReader sr = new StreamReader(fileName);

                String line = sr.ReadLine();
                Dictionary<String, Dictionary<String, String>> outerMap = new Dictionary<String, Dictionary<String, String>>();
                Dictionary<String, String> innerMap = new Dictionary<String, String>();

                int tmp = 1;

                while (line != null)
                {
                    if (line.IndexOf("[") == 0 && line.IndexOf("]") == line.Length - 1)   //Sections!
                    {
                        innerMap = new Dictionary<String, String>();
                        outerMap.Add(line.Substring(line.IndexOf("[") + 1, line.IndexOf("]") - 1), innerMap);
                        tmp++;
                    }
                    else    //Properties!
                    {
                        if (line.Length > 1)
                        {
                            String[] splittedLine = line.Split("=");
                            innerMap.Add(splittedLine[0], splittedLine[1]);
                        }
                    }
                    line = sr.ReadLine();
                }
                return outerMap;
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}