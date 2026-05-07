using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CiNemaPlus.Models
{
    public class MoviesApiResponse
    {
        public string Status { get; set; } = string.Empty;

        [JsonPropertyName("results")]
        public List<Movie> Movies { get; set; } = new();
    }
}
