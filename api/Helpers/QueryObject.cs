using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace api.Helpers
{
    public class QueryObject
    {
        [JsonPropertyName("CustomerName")]
        public string? CustomerName { get; set; } = null;

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 5;
    }
}