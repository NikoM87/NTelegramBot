using Newtonsoft.Json;

namespace NTelegramBot.Types
{
    [JsonObject]
    public class User
    {
        [JsonProperty("id")] public long Id;
        [JsonProperty("first_name")] public string FirstName;
        [JsonProperty("last_name")] public string LastName;
        [JsonProperty("username")] public string Username;
    }
}