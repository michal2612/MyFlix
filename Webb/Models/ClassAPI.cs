using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Webb.Models
{
    public static class ClassAPI
    {
        private static readonly string _loginpath = "http://192.168.99.100:5000/api/login";

        private static WebClient GetWebclient()
        {
            var client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            return client;
        }

        public static string UserLogin(User user)
        {
            var client = GetWebclient();
            var token = client.UploadString(_loginpath, JsonConvert.SerializeObject(new User() { Username = user.Username, Password = user.Password }));
            return token;
        }
    }
}
