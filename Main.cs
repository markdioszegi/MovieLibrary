using System;

namespace MovieLibrary
{
    class Program
    {
        public static void Main(String[] args)
        {
            //Display.printMovies(FileHandler.loadFile("src/app/movies.ini"));

            String[] menuPoints = { "Exit program", "Show Movies", "Show Dicks" };
            String[] optionInput = { "" };

            while (true)
            {
                //Console.Clear();
                Display.printMenu("[-Main Menu-]", menuPoints);
                int options = Display.getInputs("Choose an option", optionInput);
                switch (options)
                {
                    case 0:
                        {
                            System.Environment.Exit(0);
                        }
                        break;
                    case 1:
                        {
                            showMovies();
                        }
                        break;
                    case 2:
                        {
                            showDicks();
                        }
                        break;
                    default:
                        {
                            throw new Exception("Not an option!");
                            Display.print("Not an option!");
                        }
                        break;
                }
            }
        }

        public static void showMovies()
        {
            Display.printMovies(FileHandler.loadFromINI("movies.ini"));
        }

        public static void showDicks()
        {
            String s = "sajt=béla";
            System.Console.WriteLine(s.Split("=")[0] + s.Split("=")[1]);
        }
    }
}
