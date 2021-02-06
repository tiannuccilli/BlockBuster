using BlockBuster.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace BlockBusterConsole
{
    class outputHelper
    {
        public void writeToConsole(List<Movie> movies)
        {
            Console.WriteLine("List of Movies");
            foreach (var m in movies)
            {
                Console.WriteLine($"MovieID: {m.MovieId}    Title: {m.Title}    Release Year:{m.ReleaseYear}");

            }
        }
        public void writeToConsole1(Movie movie)
        {
            Console.WriteLine("Movie");

                Console.WriteLine($"MovieID: {movie.MovieId}    Title: {movie.Title}    Release Year:{movie.ReleaseYear}");
        }

        public void writeToCSV(List<Movie> movies)
        {
            using (var writer = new StreamWriter(@"..\file.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(movies);
            }
        }
        public void writeToCSV1(Movie movie)
        {
            using (var writer = new StreamWriter(@"..\file.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecord(movie);
            }
        }
    }
}
