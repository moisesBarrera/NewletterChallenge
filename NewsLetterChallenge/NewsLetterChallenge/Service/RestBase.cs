using NewsLetterChallenge.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace NewsLetterChallenge.Service
{
	public class RestBase
	{

		public string BaseUrl { get; set; }

		private int DefaultTimeout { get; }

		private readonly HttpClient _httpClient;

		public RestBase(string baseUrl, int defaultTimeOut, HttpClient httpClient)
		{
			BaseUrl = baseUrl;
			DefaultTimeout = defaultTimeOut;
			_httpClient = httpClient;

         ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

         _httpClient.BaseAddress = new Uri(BaseUrl);
         _httpClient.Timeout.Add(new TimeSpan(0, 0, 0, DefaultTimeout));
         _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

      }

      public T Get<T>(string resource) where T : class, new()
		{

			var url = string.Concat(BaseUrl != null ? BaseUrl.TrimEnd('/') : "", resource);

         using (var request = new HttpRequestMessage())
         {
            request.Method = new HttpMethod("GET");
            request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

            request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);

            var response = _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).Result;
            try
            {
               var status = ((int)response.StatusCode).ToString();

               var headers = Enumerable.ToDictionary(response.Headers, h => h.Key, h => h.Value);
               if (response.Content?.Headers != null)
               {
                  foreach (var item in response.Content.Headers)
                  {
                     headers[item.Key] = item.Value;
                  }
               }

               switch (status)
               {
                  case "200":
                     {
                        var responseData = response.Content?.ReadAsStringAsync().Result;
                        try
                        {
                           var result = JsonConvert.DeserializeObject<T>(responseData);
                           return result;
                        }
                        catch (Exception exception)
                        {
                           throw new HttpClientCustomException("Could not deserialize the response body.", (int)response.StatusCode, responseData, headers, exception);
                        }
                     }
                  default:
                     {
                        var responseData = response.Content?.ReadAsStringAsync().Result;
                        throw new HttpClientCustomException("The HTTP status code of the response was not expected (" + (int)response.StatusCode + ").", (int)response.StatusCode, responseData, headers, null);
                     }
               }
            }
            finally
            {
               response.Dispose();
            }
         }
      }
	}
}
