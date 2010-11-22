using System;
using System.IO;
using System.Net;
using System.Text;

namespace SunnyTrail
{
    /// <summary>
    /// Contains methods and properties for interacting with the SunnyTrail API (https://beta.thesunnytrail.com/developers)
    /// </summary>
    public class Client
    {
        private const string ApiUrl = "https://api.thesunnytrail.com/messages?apikey={0}";
        public string ApiKey { get; set; }

        public Client(string apiKey)
        {
            ApiKey = apiKey;
        }

        /// <summary>
        /// Saves a SunnyTrail event by submitting it to SunnyTrail via the JSON API
        /// </summary>
        /// <param name="event"></param>
        public void SaveEvent(Event @event)
        {
            if (@event == null) throw new ArgumentNullException("event");
            if (@event.Action == null) throw new ArgumentException( "event.Action must not be null", "event");
            if (@event.Plan == null) throw new ArgumentException("event.Plan must not be null", "event");
            if (string.IsNullOrEmpty(@event.Name)) throw new ArgumentException("event.Name must not be null or empty", "event");
            if (string.IsNullOrEmpty(@event.Email)) throw new ArgumentException("event.Email must not be null or empty", "event");
            if (@event.Id == 0) throw new ArgumentException("event.Id must be used correctly, duplicate ids for distinct accounts will cause SunnyTrail to merge data for separate accounts into one account", "event");

            // Build the message body and convert to a byte array
            var eventJson = @event.ToJson();
            var body = "message=" + eventJson;
            var bodyAsBytes = Encoding.UTF8.GetBytes(body);

            // Build the request
            var webRequest = (HttpWebRequest)WebRequest.Create(string.Format(ApiUrl, ApiKey));
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = bodyAsBytes.Length;
            using (var requestStream = webRequest.GetRequestStream())
                requestStream.Write(bodyAsBytes, 0, bodyAsBytes.Length);

            try
            {
                // POST the request (we know HttpWebRequest will throw if the API returns anything other than 2xx)
                webRequest.GetResponse().Close();
            }
            catch (WebException webException)
            {
                var errorMessage = string.Empty;
                var statusCode = 0;
                // Extract the body (if possible)
                if (webException.Response != null)
                {
                    using (var reader = new StreamReader(webException.Response.GetResponseStream()))
                        errorMessage = reader.ReadToEnd();
                    statusCode = (int)((HttpWebResponse) webException.Response).StatusCode;
                }
                throw new UnableToSaveEventException(errorMessage, statusCode, eventJson, webException);
            }
        }
    }
}
