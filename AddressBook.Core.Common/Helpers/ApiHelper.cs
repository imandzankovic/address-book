using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Text;

namespace AddressBook.Core.Common.Helpers
{
    public sealed class ApiHelperFactory
    {
        public static ApiHelper ApiHelper
        {
            get
            {
                return new ApiHelper("");
            }
        }
    }

    public class ApiHelper
    {
        #region Fields

        private readonly HttpClient client = new HttpClient();

        #endregion Fields

        #region Constructors

        public ApiHelper(string baseAddress)
        {
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
        }

        #endregion Constructors

        #region Methods

        public Tresp Post<Tresp>(object tObject, string path, NameValueCollection parameters = null, IDictionary<string, string> headers = null)
            where Tresp : class
        {
            Tresp t = null;

            try
            {
                string jsonData = JsonConvert.SerializeObject(tObject);

                HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                path = AttachParameters(path, parameters);

                TryAddHeaders(client, headers);

                HttpResponseMessage response = client.PostAsync(Uri.EscapeUriString(path), content).Result;


                string responseData = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    t = JsonConvert.DeserializeObject<Tresp>(responseData);
                }
            }
            catch { }

            return t;
        }

        public T Update<T>(T tObject, string path, NameValueCollection parameters = null, IDictionary<string, string> headers = null) where T : class
        {
            T t = null;

            try
            {
                string jsonData = JsonConvert.SerializeObject(tObject);

                HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                path = AttachParameters(path, parameters);

                TryAddHeaders(client, headers);

                HttpResponseMessage response = client.PutAsync(Uri.EscapeUriString(path), content).Result;

                string responseData = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    t = JsonConvert.DeserializeObject<T>(responseData);
                }
            }
            catch { }

            return t;
        }

        public T Get<T>(string path, NameValueCollection parameters = null, IDictionary<string, string> headers = null) where T : class
        {
            T t = null;

            try
            {
                TryAddHeaders(client, headers);

                path = AttachParameters(path, parameters);

                HttpResponseMessage response = client.GetAsync(Uri.EscapeUriString(path)).Result;

                string responseData = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    var settings = new JsonSerializerSettings
                    {
                        ObjectCreationHandling = ObjectCreationHandling.Replace
                    };

                    t = JsonConvert.DeserializeObject<T>(responseData, settings);

                }
            }
            catch { }

            return t;
        }

        public HttpStatusCode Delete(string path)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync(path).Result;

                return response.StatusCode;
            }
            catch { }

            return HttpStatusCode.InternalServerError;
        }

        private string AttachParameters(string path, NameValueCollection parameters)
        {
            var stringBuilder = new StringBuilder();

            if (parameters != null && parameters.Count > 0)
            {
                string str = "?";

                for (int i = 0; i < parameters.Count; ++i)
                {
                    if (!string.IsNullOrWhiteSpace(parameters[i]) && !string.IsNullOrEmpty(parameters.AllKeys[i])
                        && parameters[i] != null)
                    {
                        stringBuilder.Append(str + parameters.AllKeys[i].Trim() + "=" + parameters[i].Trim());
                        str = "&";
                    }
                }

                path += stringBuilder.ToString();
            }

            return path;
        }

        private void TryAddHeaders(HttpClient client, IDictionary<string, string> headers)
        {
            if (headers == null)
            {
                return;
            }

            foreach (var header in headers)
            {
                client.DefaultRequestHeaders
                      .TryAddWithoutValidation(header.Key, "key= " + header.Value);

            }
        }

        #endregion Methods
    }
}
