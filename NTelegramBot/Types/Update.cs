using Newtonsoft.Json;

namespace NTelegramBot.Types
{
    [JsonObject]
    public class Update
    {
        [JsonProperty("update_id")] public long UpdateId;
        [JsonProperty("message")] public Message Message;
    }
}