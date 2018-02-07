using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace EvaluationXamarin
{
    public partial class MovieListPage : ContentPage
    {
        private MovieModel[] movies { get; set; }
        public MovieListPage()
        {
            InitializeComponent();

            var adapter = new ObservableCollection<MovieModel>();
            MovieDAO.GetMovies((movies) => {
                this.movies = movies;
                foreach (MovieModel movie in this.movies)
                {
                    adapter.Add(movie);
                }

                this.lvMovies.ItemsSource = adapter;
                this.lvMovies.RowHeight = 50;

                this.lvMovies.ItemTapped += (sender, e) => {
                    MovieModel movie = e.Item as MovieModel;
                    var movieDetailPage = new MovieDetailPage();
                    movieDetailPage.movie = movie;
                    this.Navigation.PushAsync(movieDetailPage);
                };
            }, (error) => {
                DisplayAlert("Error", error, "Ok", "Cancel");
            });
        }

        protected override void OnAppearing()
        {
            
        }
    }
}
