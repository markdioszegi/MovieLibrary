using System;
using System.Collections.Generic;

namespace MovieLibrary
{
    public class Movie
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Stars { get; set; }
        public string Budget { get; set; }
        public float Points { get; set; }
        public Movie(string title)
        {
            Title = title;
        }
        public Movie(string title, string director, string genre, int releaseYear, string stars, string budget, float points)
        {
            Title = title;
            Director = director;
            Genre = genre;
            ReleaseYear = releaseYear;
            Stars = stars;
            Budget = budget;
            Points = points;
        }

        /* public object[] GetProperties(Movie movie)
        {
            return movie.GetType().GetProperties();
        } */

        public override string ToString()
        {
            string s = null;    //meaningful
            foreach (var property in this.GetType().GetProperties())
            {
                if (property.Name == "Title")
                {
                    s += String.Format("[{0}]", property.GetValue(this, null));
                }
                else
                {
                    s += property.Name + ": " + property.GetValue(this, null);
                }
                s += "\n";
            }
            return s;
        }

        public static List<Movie> LoadMoviesFromIni(Ini ini)
        {
            int index = 0;
            List<Movie> movies = new List<Movie>();
            foreach (var section in ini.Sections)
            {
                Movie movie = new Movie(section.Key);
                foreach (var property in section.Value)
                {
                    if (property.Key == "director")
                    {
                        movie.Director = property.Value;
                    }
                    else if (property.Key == "genre")
                    {
                        movie.Genre = property.Value;
                    }
                    else if (property.Key == "release_year")
                    {
                        movie.ReleaseYear = Convert.ToInt16(property.Value);
                    }
                    else if (property.Key == "stars")
                    {
                        movie.Stars = property.Value;
                    }
                    else if (property.Key == "budget")
                    {
                        movie.Budget = property.Value;
                    }
                    else if (property.Key == "points")
                    {
                        movie.Points = float.Parse(property.Value.Replace(".", ","));
                    }
                }
                movies.Add(movie);
                index++;
            }
            return movies;
        }
    }
}