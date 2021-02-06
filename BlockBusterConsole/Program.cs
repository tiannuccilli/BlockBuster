using BlockBuster;
using BlockBuster.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BlockBusterConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //var conOhType = args[0].ToLower();
            var ohType = "";
            var askType = true;
            while (askType == true)
            {
                Console.WriteLine("How would you like to recieve movies?(console/csv)");
                var ohTypetemp = Console.ReadLine();
                ohType = ohTypetemp.ToLower();
                if (ohType == "console" || ohType == "csv")
                {
                    askType = false;
                }
                Console.Clear();
            }
            
            var findBy = "";
            var movie = new Movie();
            List<Movie> movies = new List<Movie>();
            var ask = true;
            while (ask == true)
            {
                Console.WriteLine("How would you like to search movies?(all, id, genre, director)");
                var findByTemp = Console.ReadLine();
                findBy = findByTemp.ToLower();
                if (findBy == "all")
                {
                    movies = BlockBusterBasicFunctions.GetAllMovies();
                    ask = false;
                }
                else if (findBy == "id")
                {
                    movie = BlockBusterBasicFunctions.GetMovieById(5);
                    ask = false;
                }
                else if (findBy == "genre")
                {
                    movies = BlockBusterBasicFunctions.GetAllGenreMovies("action");
                    ask = false;
                }
                else if (findBy == "director")
                {
                    movies = BlockBusterBasicFunctions.GetAllDirectorMovies("Spielberg");
                    ask = false;
                }
                else
                {
                    Console.WriteLine("Not a proper search case (all, id, genre, director)");
                }
            }

            var oh = new outputHelper();
            if(findBy == "id")
            {
                if (ohType == "console")
                {
                    oh.writeToConsole1(movie);
                }
                else if (ohType == "csv")
                {
                    oh.writeToCSV1(movie);
                }
            }
            else if (ohType == "console")
            {
                oh.writeToConsole(movies);
            }
            else if (ohType == "csv"){
                oh.writeToCSV(movies);
            }
        }
    }
}
