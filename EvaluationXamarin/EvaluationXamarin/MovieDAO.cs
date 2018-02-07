using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace EvaluationXamarin
{
    public class MovieDAO
    {
        private static HttpClient client;
        private const String baseUrl = "https://baas.kinvey.com/appdata/kid_SyXkBdMVM";


        public MovieDAO()
        {
        }

        public static async void GetMovies(
            Action<MovieModel[]> success,
            Action<String> error
            )
        {
            String url = MovieDAO.baseUrl + "/movies";
            //UserModel user = UserDAO.currentUser;
            var uri = new Uri(url);

            using (client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Kinvey " + UserDAO.currentAuthToken);
                client.DefaultRequestHeaders.Add("X-Kinvey-API-Version", "3");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

                HttpResponseMessage response = null;
                response = await client.GetAsync(uri);


                //Receive JSON, deserialize it to UserModel
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    MovieModel[] movies = JsonConvert.DeserializeObject<MovieModel[]>(responseString);
                    success(movies);
                }
                else
                {
                    error("Error getting movies " + response);
                }
            }
        }
    }
}
