using BlockBuster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockBuster
{
    public class BlockBusterBasicFunctions
    {
        public static Movie GetMovieById(int id)
        {
            using(var db = new SE407_BlockBusterContext())
            {
                return db.Movies.Find(id);
            }
        }

        public static List<Movie> GetAllMovies()
        {
            using (var db = new SE407_BlockBusterContext())
            {
                return db.Movies.ToList();
            }
        }
        public static List<Movie> GetAllCheckedOutMovies()
        {
            using (var db = new SE407_BlockBusterContext())
            {
                return db.Movies
                .Join(db.Transactions,
                 m => m.MovieId,
                 t => t.Movie.MovieId,
                 (m, t) => new
                 {
                     MovieId = m.MovieId,
                     Title = m.Title,
                     ReleaseYear = m.ReleaseYear,
                     GenreId = m.GenreId,
                     DirectorId = m.DirectorId,
                     checkedIn = t.CheckedIn
                 }).Where(w => w.checkedIn == "N")
                 .Select(m => new Movie
                 {
                     MovieId = m.MovieId,
                     Title = m.Title,
                     ReleaseYear = m.ReleaseYear,
                     GenreId = m.GenreId,
                     DirectorId = m.DirectorId
                 }).ToList();

            }
        }
    }
}
