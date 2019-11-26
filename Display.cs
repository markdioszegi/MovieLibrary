using System;

namespace MovieLibrary
{
    public class Display
    {

        public static void print(String text)
        {
            System.Console.WriteLine(text); ;
        }

        public static void printMenu(String title, String[] points)
        {
            print(title);
            for (int i = 0; i < points.Length; i++)
            {
                Console.Write("{0}. {1}\n", i, points[i]);
            }
            print("");
        }

        /* public static void printMovies(HashMap<String, HashMap<String, String>> movies)
        {
            
             * for (String section : movies.keySet()) { print("" + section); for (String key
             * : movies.get(section).keySet()) { print(key + ": " +
             * movies.get(section).get(key)); } }
            
        } */

        public static int getInputs(String description, String[] inputs)
        {
            byte choice = 0;

            print(description);

            for (int i = 0; i < inputs.Length; i++)
            {
                print(inputs[i]);
                choice = Convert.ToByte(Console.ReadLine());
            }
            return choice;
        }

    }
}