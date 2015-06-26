using Newtonsoft.Json;

namespace NTelegramBot.Types
{
    public class Location
    {
        [JsonProperty("longitude")] public double Longitude;
        [JsonProperty("latitude")] public double Latitude;
    }
}