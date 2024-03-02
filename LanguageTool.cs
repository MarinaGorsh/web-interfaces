using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace Lr
{
    internal class Lang<T>
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public List<T> Results { get; set; }
    }
    internal class LanguageToolResponse
    {
        [JsonProperty("language")]
        public WordDetails Language { get; set; }
    }
}
