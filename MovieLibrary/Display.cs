using System;
using System.Collections.Generic;

namespace MovieLibrary
{
    class Display
    {
        public static void Print(String text)
        {
            System.Console.WriteLine(text);
        }

        public static void PrintMenu(String title, String[] points)
        {
            Print(title);
            for (int i = 0; i < points.Length; i++)
            {
                Console.Write("{0}. {1}\n", i, points[i]);
            }
            Print("");
        }

        [Obsolete("Use the List type one.")]
        public static void PrintMovies(Dictionary<String, Dictionary<String, String>> movies)
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
        public static void PrintMovies(List<Movie> movies)
        {
            foreach (Movie movie in movies)
            {
                foreach (var property in movie.GetType().GetProperties())
                {
                    if (property.Name == "Title")
                    {
                        Print(String.Format("[{0}]", property.GetValue(movie, null)));    //TODO
                    }
                    else
                    {
                        Print(String.Format("{0}: {1}", property.Name, property.GetValue(movie, null)));    //TODO
                    }
                }
                Print(null);
            }
        }

        public static void PrintPretty(List<Movie> movies)
        {
            int offsetMax = 1;

            foreach (Movie movie in movies)     //Offset finding
            {
                foreach (var property in movie.GetType().GetProperties())
                {
                    if (property.GetValue(movie, null).ToString().Length > offsetMax)
                    {
                        offsetMax = property.GetValue(movie, null).ToString().Length;
                    }
                }
            }
            string offsetStr = new string(' ', offsetMax);

            //System.Console.WriteLine("Offset!!: " + offset);

            foreach (var property in movies[0].GetType().GetProperties())
            {
                System.Console.Write(property.Name + offsetStr);
            }

            //print("\n" + "-" * offset * len(titles))
            System.Console.WriteLine("\n-----------------------");    //Dashes

            foreach (Movie movie in movies)     //Data
            {
                foreach (var property in movie.GetType().GetProperties())
                {
                    System.Console.Write(property.GetValue(movie, null) + offsetStr);
                }
                Print(null);
            }
        }

        public static String[] GetInputs(String description, String[] inputs)
        {
            String[] choices = new String[inputs.Length];

            Print(description);

            for (int i = 0; i < inputs.Length; i++)
            {
                System.Console.Write(inputs[i]);
                choices[i] = Console.ReadLine();
            }
            return choices;
        }

    }
}