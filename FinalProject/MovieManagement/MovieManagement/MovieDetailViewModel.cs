using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace MovieManagement
{
    class MovieDetailViewModel : BaseViewModel, ICloseable
    {
        private int m_YearDetail;
        private string m_TitleDetail;
        private string m_GenreDetail;
        private decimal m_RatingDetail;

        public int YearDetail
        {
            get => m_YearDetail;
            set
            {
                m_YearDetail = value;
                OnPropertyChanged(nameof(YearDetail));
            }
        }

        public string TitleDetail
        {
            get => m_TitleDetail;
            set
            {
                m_TitleDetail = value;
                OnPropertyChanged(nameof(TitleDetail));
            }
        }
        public string GenreDetail
        {
            get => m_GenreDetail;
            set
            {
                m_GenreDetail = value;
                OnPropertyChanged(nameof(GenreDetail));
            }
        }

        public decimal RatingDetail
        { 
            get => m_RatingDetail;
            set
            {
                m_RatingDetail = value;
                OnPropertyChanged(nameof(GenreDetail));
            }

        }
       

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }
     

        private readonly IMovieService m_movieService;
        public MovieDetailViewModel(IMovieService movieService, int Id)
        {
            m_movieService = movieService;

            var movie = m_movieService.LoadMovieById(Id);
            YearDetail = movie.Year;
            TitleDetail = movie.Title;
            GenreDetail = movie.Genre;
            RatingDetail = movie.Rating;
           
            SaveCommand = new ConditionalCommand(x => DoSave(Id));
            CancelCommand = new ConditionalCommand(x => DoCancel());
         
        }


        public event EventHandler CloseRequest;
        private void DoCancel()
        {
            var handler = CloseRequest;
            if (handler != null) handler(this, EventArgs.Empty);
        }
      

        private void DoSave(int Id)
        {
            var m_movie = m_movieService.LoadMovieById(Id);
            m_movie.Year = YearDetail;
            m_movie.Title = TitleDetail;
            m_movie.Genre = GenreDetail;
            m_movie.Rating = RatingDetail;

            m_movieService.UpdateOrCreateMovie(m_movie);
        }


    }


}
