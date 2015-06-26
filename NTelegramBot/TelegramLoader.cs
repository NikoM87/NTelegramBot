using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using NTelegramBot.Types;
using System.Collections.Specialized;

namespace NTelegramBot
{
    public class TelegramLoader
    {
        private string _server = "https://api.telegram.org/bot";
        private readonly string _token;

        private string GetRequst(string command, NameValueCollection parameters)
        {

            WebClient request = new WebClient();
            request.BaseAddress = _server + _token + "/";
            if (parameters != null)
                request.QueryString.Add(parameters);

            return request.DownloadString(command);
        }

        public TelegramLoader(string token)
        {
            _token = token;
        }

        public Request<Update[]> GetUpdates()
        {
            string json = GetRequst("getUpdates", null);
            return JsonConvert.DeserializeObject<Request<Update[]>>(json);
        }

        public Request<Update[]> GetUpdates(long updateId)
        {
            NameValueCollection query = new NameValueCollection();
            query.Add("offset", updateId.ToString());

            var json = GetRequst("getUpdates", query);
            return JsonConvert.DeserializeObject<Request<Update[]>>(json);
        }

        public Request<Message> SendMessage(long chatId, string text)
        {
            NameValueCollection query = new NameValueCollection();
            query.Add("chat_id", chatId.ToString());
            query.Add("text", text.ToString());

            var json = GetRequst("sendMessage", query);
            return JsonConvert.DeserializeObject<Request<Message>>(json);
        }

        public Request<Location> SendLocation(long chatId, Location location)
        {

            NameValueCollection query = new NameValueCollection();
            query.Add("chat_id", chatId.ToString());
            query.Add("latitude", location.Latitude.ToString(CultureInfo.InvariantCulture));
            query.Add("longitude", location.Longitude.ToString(CultureInfo.InvariantCulture));

            string json = GetRequst("sendLocation", query);
            return JsonConvert.DeserializeObject<Request<Location>>(json);
        }
    }
}