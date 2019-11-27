using System;
using System.Collections.Generic;

namespace MovieLibrary
{
    class Display
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

        public static void printMovies(Dictionary<String, Dictionary<String, String>> movies)
        {
            foreach (var section in movies)
            {
                System.Console.WriteLine("Movie Title: {0}", section.Key);
                foreach (var property in section.Value)
                {
                    System.Console.WriteLine("{0}: {1}", property.Key, property.Value);
                }
            }

        }

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