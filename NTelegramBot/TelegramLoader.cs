using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using NTelegramBot.Types;

namespace NTelegramBot
{
    public class TelegramLoader
    {
        private string _server = "https://api.telegram.org/bot";
        private readonly string _token;

        private string GetRequst(string command)
        {
            UriBuilder url = new UriBuilder(_server + _token + "/" + command);
            WebRequest request = WebRequest.Create(url.Uri);
            Debug.Assert(request != null, "request != null");
            WebResponse response = request.GetResponse();
            Debug.Assert(response != null, "response != null");
            Stream resStream = response.GetResponseStream();
            Debug.Assert(resStream != null, "resStream != null");
            StreamReader reader = new StreamReader(resStream);
            return reader.ReadToEnd();
        }

        public TelegramLoader(string token)
        {
            _token = token;
        }

        public Request<Update[]> GetUpdates()
        {
            return JsonConvert.DeserializeObject<Request<Update[]>>(GetRequst("getUpdates"));
        }

        public Request<Update[]> GetUpdates(long updateId)
        {
            StringBuilder commandString = new StringBuilder("getUpdates");
            commandString.Append("?offset=");
            commandString.Append(updateId);

            var s = GetRequst(commandString.ToString());
            return JsonConvert.DeserializeObject<Request<Update[]>>(s);
        }

        public Request<Message> SendMessage(long chatId, string text)
        {
            StringBuilder commandString = new StringBuilder("sendMessage");
            commandString.Append("?chat_id=");
            commandString.Append(chatId);
            commandString.Append("&text=");
            commandString.Append( text);

            var s = GetRequst(commandString.ToString());
            return JsonConvert.DeserializeObject<Request<Message>>(s);
        }

        public Request<Location> SendLocation(long chatId, Location location)
        {
            StringBuilder commandString = new StringBuilder("sendLocation");
            commandString.Append("?chat_id=");
            commandString.Append(chatId);
            commandString.Append("&latitude=");
            commandString.Append(location.Latitude.ToString(CultureInfo.InvariantCulture));
            commandString.Append("&longitude=");
            commandString.Append(location.Longitude.ToString(CultureInfo.InvariantCulture));

            string requestText = GetRequst(commandString.ToString());
            return JsonConvert.DeserializeObject<Request<Location>>(requestText);
        }
    }
}