﻿using System;
using System.Collections.Generic;

namespace MovieLibrary
{
    public class MainProgram
    {
        public List<Movie> movies;
        public static void Main(String[] args)
        {
            //Ini ini = new Ini("movies.ini");
            MainProgram mainProgram = new MainProgram(args);

            //System.Console.WriteLine("Sections: {0}, Properties: {1}", ini.SectionsLength, ini.PropertiesLength);
            //Display.Print(ini.ToString());

            //Display.PrintMovies(ini.Sections);    //Old print
            //Display.PrintMovies(movies);

            //Dictionary<String, Dictionary<String, String>> movies = FileHandler.LoadFromINI("movies.ini");
        }

        public MainProgram(String[] args)
        {
            Ini ini = new Ini(args[0]);
            movies = Movie.LoadMoviesFromIni(ini);
            if (args.Length == 2)
                if (args[1] == "-menu")
                    HandleMenu(movies);
        }

        public void HandleMenu(List<Movie> movies)
        {
            String[] menuPoints = { "Exit program", "Show Movies", "Show director and genre of a movie", "Get movies by genre", "Show movie trailer", "Get the highest rated movie" };
            String[] optionInput = { "Choose an option: " };

            while (true)
            {
                //Console.Clear();
                Display.PrintMenu("[-Main Menu-]", menuPoints);
                byte option;
                if (Byte.TryParse(Display.GetInputs(null, optionInput)[0], out option))
                {
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
                                if (GetDirectorAndGenre(movies, movieTitle) != null)
                                {
                                    Display.Print(GetDirectorAndGenre(movies, movieTitle));
                                }
                                else
                                {
                                    Display.Print("Couldn't find any movies with that title!");
                                }
                            }
                            break;
                        case 3:
                            {
                                String genre = Display.GetInputs("Fill the blank(s)", new String[] { "Genre: " })[0];
                                if (GetMoviesByGenre(movies, genre).Count > 0)
                                {
                                    Display.PrintMovies(GetMoviesByGenre(movies, genre));
                                }
                                else
                                {
                                    Display.Print("Couldn't find any movies with that genre!");
                                }
                            }
                            break;
                        case 4:
                            {
                                String movieTitle = Display.GetInputs("Fill the blank(s)", new String[] { "Movie Title: " })[0];
                                string url = "http://www.google.com/search?q=" + movieTitle;
                                try
                                {
                                    System.Diagnostics.Process.Start(url);
                                    System.Console.WriteLine("Opening...");
                                }
                                catch (Exception e)
                                {
                                    System.Console.WriteLine(e.Message); ;
                                }
                            }
                            break;
                        case 5:
                            {
                                Display.Print(GetHighestRatedMovie(movies).ToString());
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
        }

        public void ShowMovies(List<Movie> movies)
        {
            Display.PrintMovies(movies);
            //Display.PrintPretty(movies);
        }

        public String GetDirectorAndGenre(List<Movie> movies, String movieTitle)
        {
            String[] result = new String[2];
            bool found = false;
            foreach (var movie in movies)
            {
                if (movie.Title.ToLower() == movieTitle.ToLower())
                {
                    result[0] = movie.Director;
                    result[1] = movie.Genre;
                    found = true;
                }
            }
            if (found) return "Director: " + result[0] + "\nGenre: " + result[1];
            return null;
        }

        public List<Movie> GetMoviesByGenre(List<Movie> movies, String genre)
        {
            //genre = genre.Replace(" ", String.Empty);
            List<Movie> moviesByGenre = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.Genre.ToLower().Contains(genre.ToLower()))
                {
                    moviesByGenre.Add(movie);
                }
            }
            return moviesByGenre;
        }
        public Movie GetHighestRatedMovie(List<Movie> movies)
        {
            Movie highest = movies[0];
            foreach (var movie in movies)
            {
                if (movie.Points > highest.Points)
                {
                    highest = movie;
                }
            }
            return highest;
        }
    }
}
