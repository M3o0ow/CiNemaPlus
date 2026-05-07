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
    }
}
