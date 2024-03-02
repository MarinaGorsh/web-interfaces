using Newtonsoft.Json;

namespace Lr
{
    internal class LangDetails
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("longCode")]
        public string LongCode { get; set; }
    }
    internal class WordDetails
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

    }
}
