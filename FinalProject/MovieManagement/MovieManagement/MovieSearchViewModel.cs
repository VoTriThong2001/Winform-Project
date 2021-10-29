using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace MovieManagement
{

    public class Movie
    {
        public int movieId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public decimal Rating { get; set; }

    }

    class MovieSearchViewModel : BaseViewModel
    {
        private int m_selectedId;

        public int SelectedId
        {
            get => m_selectedId;
            set
            {
                m_selectedId = value;
                OnPropertyChanged(nameof(SelectedId));
            }
        }

        private string m_searchTitle;
        public string SearchTitle
        {
            get => m_searchTitle;
            set
            {
                m_searchTitle = value;
                OnPropertyChanged(nameof(SearchTitle));
            }
        }

        private string m_selectedGenre;
        public string SelectedGenre
        {
            get => m_selectedGenre;
            set
            {
                m_selectedGenre = value;
                OnPropertyChanged(nameof(SelectedGenre));
            }
        }

        private int m_selectedYear;

        public int SelectedYear
        {
            get => m_selectedYear;
            set
            {
                m_selectedYear = value;
                OnPropertyChanged(nameof(SelectedYear));
            }
        }

        private decimal m_selectedRating;

        public decimal SelectedRating
        {
            get => m_selectedRating;
            set
            {
                m_selectedRating = value;
                OnPropertyChanged(nameof(SelectedRating));
            }
        }

        private Movie m_selectedMovie;
        public Movie SelectedMovie
        {
            get => m_selectedMovie;
            set
            {
                m_selectedMovie = value;
                OnPropertyChanged(nameof(SelectedMovie));
            }
        }

        private string m_SelectedOrderBy;

        public string SelectedOrderBy
        {
            get => m_SelectedOrderBy;
            set
            {
                m_SelectedOrderBy = value;
                OnPropertyChanged(nameof(SelectedOrderBy));
            }
        }

        public ICommand SearchCommand { get; set; }
        public ICommand ResetCommand { get; set; }
        public ICommand OpenDetailCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

  

        public void DoOpenDetail()
        {
            m_movieSrv = new MovieServiceWithEF();
            //movieService = new MovieServiceWithFile();
            if (SelectedMovie != null)
            {
                var movieDetailViewModel = new MovieDetailViewModel(m_movieSrv, SelectedMovie.movieId);
                Window1 studentDetail = new Window1(movieDetailViewModel);
                studentDetail.DataContext = movieDetailViewModel;
                studentDetail.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a movie first!", "Error");
            }
                
        }

        public ObservableCollection<Movie> Movies { get; set; }
        private IMovieService m_movieSrv;
        public void DoReset()
        {
            SearchTitle = null;
            SelectedGenre = null;
            SelectedYear = 0;
            SelectedOrderBy = null;
        }
        private void DoSearch()
        {
            Movies.Clear();
            var result = m_movieSrv.SearchMovie(SearchTitle, SelectedGenre, SelectedYear, SelectedOrderBy);
            foreach (var s in result)
            {
                Movies.Add(s);
            }
        }

        private void DoDelete()
        {
            m_movieSrv.DeleteMovieById(SelectedMovie.movieId);
            MessageBox.Show("Deleted selected movie", "Deletion");
            Movies.Clear();
            var result = m_movieSrv.SearchMovie(SearchTitle, SelectedGenre, SelectedYear, SelectedOrderBy);
            foreach (var s in result)
            {
                Movies.Add(s);
            }
        }
        public MovieSearchViewModel()
        {
            m_movieSrv = new MovieServiceWithEF();
            //m_movieSrv = new MovieServiceWithFile();
            Movies = new ObservableCollection<Movie>(m_movieSrv.SearchMovie(string.Empty, string.Empty, int.MinValue, string.Empty));

            OpenDetailCommand = new ConditionalCommand(x => DoOpenDetail());
            SearchCommand = new ConditionalCommand(x => DoSearch());
            ResetCommand = new ConditionalCommand(x => DoReset());
            DeleteCommand = new ConditionalCommand(x => DoDelete());
        }
    }

    

}
