using Newtonsoft.Json;

namespace NTelegramBot.Types
{
    [JsonObject]
    public class Request<TResult>
    {
        [JsonProperty("ok")] public bool Ok;
        [JsonProperty("result")] public TResult Result;
    }
}