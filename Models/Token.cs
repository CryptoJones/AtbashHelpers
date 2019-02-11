using System;
using Newtonsoft.Json;

namespace Atbash.Helpers.Models
{
    public class Token
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonIgnore]
        public TimeSpan ExpiresInTimeSpan
        {
            get
            {
                return new TimeSpan(0, 0, 0, this.ExpiresIn);
            }
        }
    }
}
