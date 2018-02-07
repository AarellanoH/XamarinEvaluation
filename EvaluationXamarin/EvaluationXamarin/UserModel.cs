using System;
namespace EvaluationXamarin
{
    public class UserModel
    {
        public String name { get; set; }
        public String username { get; set; }
        public int phone { get; set; }
        public String mail { get; set; }
        public String password { get; set; }
        public String authtoken { get; set; }

        public UserModel()
        {


        }

        public UserModel (String name, String username, int phone, String mail, String password, String authtoken)
        {
            this.name = name;
            this.username = username;
            this.phone = phone;
            this.mail = mail;
            this.password = password;
            this.authtoken = authtoken;
        }

        public UserModel(String name, String username, int phone, String mail, String password)
        {
            this.name = name;
            this.username = username;
            this.phone = phone;
            this.mail = mail;
            this.password = password;
            this.authtoken = "";
        }

    }
}
