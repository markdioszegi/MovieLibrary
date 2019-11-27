using System;
using System.Collections.Generic;

namespace MovieLibrary
{
    class Program
    {
        public static void Main(String[] args)
        {
            String[] menuPoints = { "Exit program", "Show Movies", "Show Dicks" };
            String[] optionInput = { "" };
            Dictionary<String, Dictionary<String, String>> movies = FileHandler.LoadFromINI("movies.ini");

            while (true)
            {
                //Console.Clear();
                Display.PrintMenu("[-Main Menu-]", menuPoints);
                int options = Display.GetInputs("Choose an option", optionInput);
                switch (options)
                {
                    case 0:
                        {
                            System.Environment.Exit(0);
                        }
                        break;
                    case 1:
                        {
                            ShowMovies(movies);
                        }
                        break;
                    case 2:
                        {
                            ShowDicks();
                        }
                        break;
                    default:
                        {
                            throw new Exception("Not an option!");
                            Display.Print("Not an option!");
                        }
                        break;
                }
            }
        }

        public static void ShowMovies(Dictionary<String, Dictionary<String, String>> movies)
        {
            Display.PrintMovies(movies);
        }
        public static void asd()
        {

        }
        public static void ShowDicks()
        {
            String s = "8=Đ";
            System.Console.WriteLine(s.Split("=")[0] + s.Split("=")[1]);
        }
    }
}
