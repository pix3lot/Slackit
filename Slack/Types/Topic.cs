using Newtonsoft.Json;

namespace Slack
{
    public class Topic
    {
        #region Properties

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("creator")]
        public string Creator { get; set; }

        [JsonProperty("last_set")]
        public string LastSet { get; set; }

        #endregion
    }
}