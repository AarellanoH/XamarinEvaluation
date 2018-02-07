using System;
namespace EvaluationXamarin
{
    public class MovieModel
    {
        public String _id { get; set; }
        public String title { get; set; }
        public String description { get; set; }
        public String image { get; set; }
        public String category { get; set; }
        public int rating { get; set; }

        public MovieModel( String _id, String title,String description, String image, 
                          String category, int rating)
        {
            this._id = _id;
            this.title = title;
            this.description = description;
            this.image = image;
            this.category = category;
            this.rating = rating;
        }

        public MovieModel()
        {
        }

        public override string ToString()
        {
            return string.Format("[MovieModel: _id={0}, title={1}, description={2}, image={3}, category={4}, rating={5}]", _id, title, description, image, category, rating);
        }
    }
}
