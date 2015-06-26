using Newtonsoft.Json;

namespace NTelegramBot.Types
{
    [JsonObject]
    public class Message
    {
        [JsonProperty("message_id")] public long MessageId;
        [JsonProperty("from")] public User From;
        [JsonProperty("date")] public long Date;
        [JsonProperty("text")] public string Text;
        [JsonProperty("photo")] public PhotoSize[] Photo;
        [JsonProperty("location")] public Location Loacaton;
    }
}