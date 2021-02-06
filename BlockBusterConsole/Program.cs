using BlockBuster;
using BlockBuster.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BlockBusterConsole
{
    class Program
    {
        private static String ohType;
        private static String findBy;
        private static Movie movie = new Movie();
        private static List<Movie> movies = new List<Movie>();


        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();
            AreArguementsValid(args);

            var oh = new outputHelper();

            if (ohType == "console")
            {
                if (findBy != "id")
                {
                    oh.writeToConsole(movies);
                }
                else
                {
                    oh.writeToConsole1(movie);
                }
            }
            else if (ohType == "csv")
            {
                Console.WriteLine("Writting to csv file");
                if (findBy != "id")
                {
                    oh.writeToCSV(movies);
                }
                else
                {
                    oh.writeToCSV1(movie);
                }
            }
        }

       
        public static void AreArguementsValid(string[] args)
        {

            ohType = args[1].ToLower();
            findBy = args[2].ToLower();
            if (ohType == "csv" || ohType == "console")
            {
                if (findBy == "all" && args.Length == 3)
                {
                    Console.WriteLine("Valid");
                    movies = BlockBusterBasicFunctions.GetAllMovies();
                }
                else if (findBy == "id" && args.Length == 4)
                {
                    int id;
                    if (int.TryParse(args[3], out id))
                    {
                        movie = BlockBusterBasicFunctions.GetMovieById(id);
                        if (movie is null)
                        {
                            Console.WriteLine($"No movie with id {id}");
                        }
      
                    }
                    else
                    {
                        Console.WriteLine("Proper ID not provided");
                    }
                }
                else if (findBy == "genre" && args.Length == 4)
                {

                    String[] genres = { "action", "thriller", "horror", "drama", "adventure", "sci-fi", "comedy" };
                    if (genres.Contains(args[3].ToLower()))
                    {
                        var genre = args[3].ToLower();
                        Console.WriteLine("Valid");
                        movies = BlockBusterBasicFunctions.GetAllGenreMovies(genre);
                    }
                    else
                    {
                        Console.WriteLine("Genre must be: action, thriller, horror, drama, adventure, sci - fi, comedy");
                    }
                }
                else if (findBy == "director" && args.Length == 4)
                {
                    var director = args[3];
                    movies = BlockBusterBasicFunctions.GetAllDirectorMovies(director);
                    if (movies.Count < 1)
                    {
                        Console.WriteLine($"No movie by director {director}");
                    }
                }
                else
                {
                    Console.WriteLine("Search by: all, id, genre, or director");
                }

            }

            else
            {
                Console.WriteLine("Select console or csv and search type to receive movies");
            }

        }
    }
}
