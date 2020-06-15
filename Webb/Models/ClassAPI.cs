using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Webb.ViewModels;

namespace Webb.Models
{
    public static class ClassAPI
    {
        //PATHS
        private static readonly string _loginPath =        $"{ReturnServerIP.ServerIP()}:7001/api/login/";
        private static readonly string _registerPath =     $"{ReturnServerIP.ServerIP()}:7001/api/register/";
        private static readonly string _moviesVotingPath = $"{ReturnServerIP.ServerIP()}:7002/api/movies/";
        private static readonly string _votingPath =       $"{ReturnServerIP.ServerIP()}:7002/api/voting/";
        private static readonly string _moviesPath =       $"{ReturnServerIP.ServerIP()}:7003/api/movies/";
        private static readonly string _genresPath =       $"{ReturnServerIP.ServerIP()}:7003/api/genres/";
        private static readonly string _billingPath =      $"{ReturnServerIP.ServerIP()}:7004/api/checkuser/";
        private static readonly string _billingCardsPath = $"{ReturnServerIP.ServerIP()}:7004/api/billing/";
        private static readonly string _searchPath =       $"{ReturnServerIP.ServerIP()}:7006/api/search/";

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
        public static string CheckUser(int id) => GetWebclient().DownloadString(_billingPath + id.ToString());

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

        public static MovieDto[] ReturnMovies()
        {
            return JsonConvert.DeserializeObject<MovieDto[]>(GetWebclient().DownloadString(_moviesPath));
        }

        //MOVIES VOTING
        public static MovieDto[] ReturnVoting(int movieId)
        {
            return JsonConvert.DeserializeObject<MovieDto[]>(GetWebclient().DownloadString(_moviesVotingPath + movieId));
        }

        public static MovieDto[] ReturnMoviesVoting(int movieId)
        {
            return JsonConvert.DeserializeObject<MovieDto[]>(GetWebclient().DownloadString(_moviesVotingPath + movieId.ToString()));
        }

        public static void Vote(VotedViewModel votedViewModel)
        {
            GetWebclient().UploadString(_votingPath, JsonConvert.SerializeObject(votedViewModel));
        }

        public static List<GenreDto> GetGenres()
        {
            return JsonConvert.DeserializeObject<List<GenreDto>>(GetWebclient().DownloadString(_genresPath));
        }

        public static int[] GetSearchResult(string key) => JsonConvert.DeserializeObject<int[]>(GetWebclient().DownloadString(_searchPath + key));
    }
}
