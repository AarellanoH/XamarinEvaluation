using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace EvaluationXamarin
{
    public class UserDAO
    {
        private static HttpClient client;
        private const String baseUrl = "https://baas.kinvey.com/user/kid_SyXkBdMVM";

        public static UserModel currentUser
        {
            get
            {
                if (currentUser == null)
                {
                    return new UserModel();
                }
                else
                {
                    return currentUser;
                }
            }
            set { }
        }

        public static String currentAuthToken { get; set; }

        public UserDAO()
        {
        }


        public static async void Login(String username,
                                       String password,
                                       Action<bool> success,
                                       Action<String> error
                                      )
        {
            //Connect to webservice and post username and password
            UsernamePassword userpass = new UsernamePassword(username, password);
            String url = UserDAO.baseUrl + "/login";
            var uri = new Uri(url);
            String jsonUserPass = JsonConvert.SerializeObject(userpass);

            var content = new StringContent(jsonUserPass, Encoding.UTF8, "application/json");
            using (client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic a2lkX1N5WGtCZE1WTToyOGQwOThmOTQ0N2Q0OWNmYmI0MTUwN2FjOWU3MDZiOA==");
                client.DefaultRequestHeaders.Add("X-Kinvey-API-Version", "3");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);


                //Receive JSON, deserialize it to UserModel
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    UserModel userResponse = JsonConvert.DeserializeObject<UserModel>(responseString);
                    UserDAO.currentUser = userResponse;
                    dynamic obj = JsonConvert.DeserializeObject(responseString);
                    String authtoken = obj._kmd.authtoken;
                    UserDAO.currentAuthToken = authtoken;

                    success(true);
                }
                else
                {
                    error("Error logging in " + response);
                }
            }
        
        }

        public static async void Register(UserModel user,
                                          Action<UserModel> success,
                                          Action<String> error)
        {
            String url = UserDAO.baseUrl;
            var uri = new Uri(url);
            String jsonUser = JsonConvert.SerializeObject(user);

            using (client = new HttpClient())
            {
                var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "Basic a2lkX1N5WGtCZE1WTToyOGQwOThmOTQ0N2Q0OWNmYmI0MTUwN2FjOWU3MDZiOA==");
                client.DefaultRequestHeaders.Add("X-Kinvey-API-Version", "3");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header


                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);


                //Serialize user to JSON
                //Connect to webservice and post user to register
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    UserModel userResponse = JsonConvert.DeserializeObject<UserModel>(responseString);
                    success(userResponse);
                }
                else
                {
                    error("Error registering user " + response);
                }
            }
        }
    }

    public class UsernamePassword
    {
        public String username { get; set; }
        public String password { get; set; }

        public UsernamePassword()
        {
            
        }

        public UsernamePassword(String username, String password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
