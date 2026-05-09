using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiNemaPlus.Models
{
    public class Movie
    {
        public bool Adult { get; set; }

        public string Backdrop_path { get; set; } = string.Empty;

        public List<int> Genre_ids { get; set; } = new List<int>();

        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Original_language{ get; set; }= string.Empty;

        public string Original_title { get; set; } = string.Empty;

        public string Overview {  get; set; } = string.Empty;

        public double Popularity { get; set; }

        public string Poster_path {get; set; } = string.Empty;

        public string Release_date {get; set; } = string.Empty;    

        public bool Softcore { get; set; }

        public bool Video { get; set; }

        public double Vote_average {get; set; }
        
        public int Vote_count { get; set; }

        public string FullPosterUrl => $"https://image.tmdb.org/t/p/w500{Poster_path}";

        public Credits Credits { get; set; } = new();

        public Videos Videos { get; set; } = new();
    }

    public class Credits { public List<Cast> Cast { get; set; } = new();}

    public class Cast
    {
        public string Name { get; set; } = string.Empty;
        public string Profile_path { get; set; } = string.Empty;

        public string Character { get; set; } = string.Empty;

        public string FullProfileUrl => !string.IsNullOrEmpty(Profile_path) 
            ? $"https://image.tmdb.org/t/p/w185{Profile_path}" 
            : $"";
    }

    public class Videos() {
        public List<Results> Results { get; set; } = new();

        public string FullYoutubeEmbedLink => YoutubeEmbedLink();

        public string YoutubeEmbedLink()
        {
            var video = Results?.FirstOrDefault(r => r.Name == "Official Trailer")
                 ?? Results?.FirstOrDefault(r => r.Type == "Trailer")
                 ?? Results?.FirstOrDefault();

            return video != null
            ? $"https://www.youtube.com/watch?v={video.Key}"
            : string.Empty;
        }
    }

    public class Results()
    {
        public string Key { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
    }
}
