using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EvaluationXamarin
{
    public partial class MovieDetailPage : ContentPage
    {
        public MovieModel movie { get; set; }
        public MovieDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.lblTitle.Text = this.movie.title;
            this.lblDescription.Text = this.movie.description;
            this.lblCategory.Text = this.movie.category;
            this.lblRating.Text = this.movie.rating.ToString();
            this.imgImage.Source = this.movie.image;
        }
    }
}
