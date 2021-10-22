using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement
{
    public interface IMovieService
    {
        IList<Movie> SearchMovie(string title, string genre, int year);

        Movie LoadMovieById(long id);

        void UpdateOrCreateMovie(Movie movie);

        void DeleteMovieById(int id);
    }
}
