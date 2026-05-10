using CiNemaPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CiNemaPlus.Services
{
    public class MoviesApiService
    {
        private readonly HttpClient _httpClient;
        //private GenresApiResponse _genresApiResponse;

        public MoviesApiService(HttpClient httpClient) 
        { 
            _httpClient = httpClient;
            //_genresApiResponse = genresApiResponse;
        }

        public async Task<(List<Movie> movies, bool estFallBack)> GetData()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<MoviesApiResponse>($"movie/popular?api_key={Constants.MoviesApiKey}");

                if (response?.Movies == null || response.Movies.Count == 0)
                    return (GetMoviesLocaux(), true);

                return (response.Movies, false);
            }
            catch (Exception)
            {
                return (GetMoviesLocaux(), true);
            }
        }

        public async Task<Movie> GetFullMovieDetails(int movieId)
        {
            var response = await _httpClient.GetFromJsonAsync<Movie>($"movie/{movieId}?api_key={Constants.MoviesApiKey}&append_to_response=videos,credits");

            return response;
        }

        //public async Task<List<Dictionary<string,object>>> GetGenreList()
        //{
        //    try
        //    {
        //        var response = await _httpClient.GetFromJsonAsync<GenresApiResponse>($"genre/movie/list?api_key={Constants.MoviesApiKey}");

        //        return response.Genres;
        //    }
        //    catch (Exception)
        //    {
        //        return new List<Dictionary<string, object>>();
        //    }
            
        //}

        private List<Movie> GetMoviesLocaux() => new()
        {
            new Movie
            {
               Title = "The Super Mario Galaxy Movie",
               Overview = "Having thwarted Bowser's previous plot to marry Princess Peach, " +
                "Mario and Luigi now face a fresh threat in Bowser Jr., " +
                "who is determined to liberate his father from captivity and restore the family legacy. " +
                "Alongside companions new and old, the brothers travel across the stars to stop the young heir's crusade."
            },
            new Movie
            {
               Title = "Apex",
               Overview = "A grieving woman pushing her limits on a solo adventure in the Australian" +
                " wild is ensnared in a twisted game with a cunning killer who thinks she's prey."
            },
            new Movie
            {
               Title = "Swapped",
               Overview = "A small woodland creature and a majestic bird, two natural sworn enemies of the Valley," +
                " magically trade places and set off on an adventure of a lifetime to switch back." +
                " Their journey soon uncovers a greater threat—one that could endanger not only their species," +
                " but the entire valley they call home."
            }
        };
    }
}
