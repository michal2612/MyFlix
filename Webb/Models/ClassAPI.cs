using Newtonsoft.Json;
using System.Linq;
using System.Net;
using Webb.ViewModels;

namespace Webb.Models
{
    public static class ClassAPI
    {
        //PATHS
        private static readonly string _loginPath = "http://192.168.99.100:7000/users-login/";
        private static readonly string _registerPath = "http://192.168.99.100:7000/users-register/";
        private static readonly string _billingPath = "http://192.168.99.100:7000/billing-checkuser/";
        private static readonly string _billingCardsPath = "http://192.168.99.100:7000/billing/";
        private static readonly string _moviesPath = "http://192.168.99.100:7000/movies/";
        private static readonly string _genresPath = "http://192.168.99.100:7000/genres/";
        private static readonly string _moviesVotingPath = "http://192.168.99.100:7000/voting/";
        private static readonly string _votingPath = "http://192.168.99.100:7000/voting-movies/";

        //WEB CLIENT
        private static WebClient GetWebclient()
        {
            var client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            return client;
        }

        //USERS
        public static string UserLogin(User user)
        {
            return GetWebclient().UploadString(_loginPath, JsonConvert.SerializeObject(new User() { Username = user.Username, Password = user.Password }));
        }

        public static string RegisterUser(User user)
        {
            return GetWebclient().UploadString(_registerPath, JsonConvert.SerializeObject(user));
        }

        //BILLING
        public static string CheckUser(int id)
        {
            return GetWebclient().DownloadString(_billingPath + id.ToString());
        }

        public static UserCreditCards UserCreditCards(string token)
        {
            var cards = JsonConvert.DeserializeObject<CreditCard[]>(GetWebclient().DownloadString(_billingCardsPath + token));
            return new UserCreditCards() { CreditCards = cards.ToList() };
        }

        public static void AddCreditCard(CreditCard creditCard)
        {
            GetWebclient().UploadString(_billingCardsPath, JsonConvert.SerializeObject(creditCard));
        }

        //MOVIES
        public static MoviesViewModel MovieViewModel()
        {
            var movies = JsonConvert.DeserializeObject<MovieDto[]>(GetWebclient().DownloadString(_moviesPath));
            var genres = JsonConvert.DeserializeObject<GenreDto[]>(GetWebclient().DownloadString(_genresPath));
            return new MoviesViewModel() { Movies = movies, Genres = genres };
        }

        //MOVIES VOTING
        public static MovieDto[] ReturnVoting(string movieId)
        {
            return JsonConvert.DeserializeObject<MovieDto[]>(GetWebclient().DownloadString(_moviesVotingPath + movieId));
        }

        public static MovieDto[] ReturnMoviesVoting(int movieId)
        {
            return JsonConvert.DeserializeObject<MovieDto[]>(GetWebclient().DownloadString(_votingPath + movieId.ToString()));
        }
    }
}
