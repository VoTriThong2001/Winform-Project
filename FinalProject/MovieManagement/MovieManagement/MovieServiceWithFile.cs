﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace MovieManagement
{
    class MovieServiceWithFile :IMovieService
    {
        public MovieServiceWithFile()
        {
            var data = File.ReadAllText(@"D:\Thong\College\IT\Windows\CMP170_Exercise\FinalProject\MovieManagement\MovieManagement\Movie_Data.json");
            m_movies = JsonSerializer.Deserialize<List<Movie>>(data);
        }
        private IList<Movie> m_movies;

        public void DeleteMovieById(int id)
        {
            var deletedMovie = LoadMovieById(id);

            if (deletedMovie != null)
            {
                m_movies.Remove(deletedMovie);
            }
        }

        public Movie LoadMovieById(long id)
        {
            return m_movies.FirstOrDefault(x => x.Id == id);
        }

        public IList<Movie> SearchMovie(string title, string genre, int year)
        {
            if (title == null)
            {
                var result = m_movies.Where(s => (title == null) && (s.Genre == genre || genre == null) && (s.Year == year || year == 0))
                          .OrderBy(s => s.Title).ToList();

                foreach (var s in result)
                {
                    Console.WriteLine(s);
                }
                return result;
            }

            else
                { 
                var result = m_movies.Where(s => (s.Title.Contains(title) || s.Title.ToLower().Contains(title) || title == null) && (s.Genre == genre || genre == null) && (s.Year == year || year == 0))
                         .OrderBy(s => s.Title).ToList();

                foreach (var s in result)
                {
                    Console.WriteLine(s);
                }
            return result;
             }
        }
        public void UpdateOrCreateMovie(Movie movie)
        {
            if (movie.Id > 0)
            {
                var updatedMovie = LoadMovieById(movie.Id);
                updatedMovie.Id = movie.Id;
                updatedMovie.Title = movie.Title;
                updatedMovie.Genre = movie.Genre;
                updatedMovie.Year = movie.Year;
                updatedMovie.Rating = movie.Rating;

            }
            else
            {
                var newMovieId = m_movies.Select(s => s.Id).OrderByDescending(s => s).FirstOrDefault();
                movie.Id = newMovieId + 1;
                m_movies.Add(movie);
            }
        }
    }

}
