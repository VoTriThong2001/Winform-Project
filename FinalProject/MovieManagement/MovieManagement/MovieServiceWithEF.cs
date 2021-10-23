﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieManagement
{
    class MovieServiceWithEF : IMovieService
    {
        public MovieServiceWithEF()
        {
            using (var ctx = new MovieContext())
            {
                ctx.Database.EnsureCreated();
            }
        }

        public void DeleteMovieById(int id)
        {
            using (var ctx = new MovieContext())
            {
                var deletedMovie = ctx.Movies.Find(id);
                ctx.Movies.Remove(deletedMovie);
                ctx.SaveChanges();
            }
        }

        public Movie LoadMovieById(long id)
        {
            using (var ctx = new MovieContext())
            {
                return ctx.Movies.Find(id);
            }
        }

        public IList<Movie> SearchMovie(string title, string genre, int year)
        {
            using (var ctx = new MovieContext())
            {
                if (title == null)
                {
                var result = ctx.Movies.Where(s => (title == null) && (s.Genre == genre || genre == null) && (s.Year == year || year == 0))
                            .OrderBy(s => s.Title).ToList();

                return result;
                }

                else
                {
                    var result = ctx.Movies.Where(s => (s.Title.Contains(title) || s.Title.ToLower().Contains(title) || title == null) && (s.Genre == genre || genre == null) && (s.Year == year || year == 0))
                             .OrderBy(s => s.Title).ToList();

                    return result;
                }
            }
        }

        public void UpdateOrCreateMovie(Movie movie)
        {
            using (var ctx = new MovieContext())
            {
                if (movie.movieId > 0)
                {
                    var dbMovie = ctx.Movies.Find(movie.movieId);
                    dbMovie.Title = movie.Title;
                    dbMovie.Genre = movie.Genre;
                    dbMovie.Year = movie.Year;
                    dbMovie.Rating = movie.Rating;
                    
                }
                else
                {
                    ctx.Movies.Add(movie);
                }
                ctx.SaveChanges();
            }
        }
    }
}
