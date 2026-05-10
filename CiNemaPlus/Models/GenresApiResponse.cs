using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CiNemaPlus.Models
{
    public class GenresApiResponse
    {
        public string Status { get; set; } = string.Empty;

        public List<Dictionary<string, object>> Genres { get; set; } = new();
    }
}
