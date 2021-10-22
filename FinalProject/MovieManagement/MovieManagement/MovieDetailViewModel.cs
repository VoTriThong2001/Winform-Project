using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MovieManagement
{
    class MovieDetailViewModel : BaseViewModel
    {
        private int m_IdDetail;
        private string m_TitleDetail;
        private string m_GenreDetail;
        private decimal m_RatingDetail;

        public int IdDetail
        {
            get => m_IdDetail;
            set
            {
                m_IdDetail = value;
                OnPropertyChanged(nameof(IdDetail));
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
            IdDetail = movie.Id;
            TitleDetail = movie.Title;
            GenreDetail = movie.Genre;
            RatingDetail = movie.Rating;
           
            SaveCommand = new ConditionalCommand(x => DoSave());
            CancelCommand = new ConditionalCommand(x => DoCancel());
        }

        private void DoCancel()
        {
            throw new NotImplementedException();
        }
        public Movie m_movie;
        private void DoSave()
        {
            m_movie.Id = IdDetail;
            m_movie.Title = TitleDetail;
            m_movie.Genre = GenreDetail;
            m_movie.Rating = RatingDetail;

            m_movieService.UpdateOrCreateMovie(m_movie);
        }
    }


}
