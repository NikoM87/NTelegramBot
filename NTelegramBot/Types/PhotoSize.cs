using Newtonsoft.Json;

namespace NTelegramBot.Types
{
    public class PhotoSize
    {
        [JsonProperty("file_id")] public string FileId;
        [JsonProperty("width")] public long Width;
        [JsonProperty("height")] public long Height;
        [JsonProperty("file_size")] public long FileSize;
    }
}
