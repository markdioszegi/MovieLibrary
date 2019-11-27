using System;
using System.Collections.Generic;

namespace MovieLibrary
{
    class Program
    {
        public static void Main(String[] args)
        {
            Movie[] movies;
            Ini ini = new Ini("movies.ini");
            movies = Movie.LoadMoviesFromIni(ini);

            System.Console.WriteLine("Sections: {0}, Properties: {1}", ini.SectionsLength, ini.PropertiesLength);
            Display.Print(ini.ToString());

            //Display.PrintMovies(ini.Sections);    //Old print
            Display.PrintMovies(movies);

            //Dictionary<String, Dictionary<String, String>> movies = FileHandler.LoadFromINI("movies.ini");
            //HandleMenu(movies);
        }

        /*public static void HandleMenu(Movie[] movies)
        {
            String[] menuPoints = { "Exit program", "Show Movies", "Show Director and genre of a movie" };
            String[] optionInput = { "" };

            while (true)
            {
                //Console.Clear();
                Display.PrintMenu("[-Main Menu-]", menuPoints);
                byte option = Convert.ToByte(Display.GetInputs("Choose an option", optionInput)[0]);
                switch (option)
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
                            String movieTitle = Display.GetInputs("Fill the blank(s)", new String[] { "Movie Title: " })[0];
                            Display.Print(GetDirectorAndGenre(movies, movieTitle));
                        }
                        break;
                    case 3:
                        {
                            String genre = Display.GetInputs("Fill the blank(s)", new String[] { "Genre: " })[0];
                            GetMoviesByGenre(movies, genre);
                        }
                        break;
                    default:
                        {
                            try
                            {
                                throw new Exception("Not an option!");
                            }
                            catch (Exception e)
                            {
                                Display.Print(e.Message);
                            }
                        }
                        break;
                }
            }
        }
        */
        public static void ShowMovies(Dictionary<String, Dictionary<String, String>> movies)
        {
            Display.PrintMovies(movies);
        }

        public static String GetDirectorAndGenre(Dictionary<String, Dictionary<String, String>> movies, String movieTitle)
        {
            String[] result = new String[2];
            foreach (var movie in movies)
            {
                if (movie.Key == movieTitle)
                {
                    foreach (var property in movie.Value)
                    {
                        if (property.Key == "director")
                        {
                            result[0] += property.Value;
                        }
                        else if (property.Key == "genre")
                        {
                            result[1] += property.Value;
                        }
                    }
                }
            }
            return "Director: " + result[0] + "\nGenre: " + result[1];
        }

        public static void GetMoviesByGenre(Dictionary<String, Dictionary<String, String>> movies, String genre)
        {
            //TODO
        }
    }
}
