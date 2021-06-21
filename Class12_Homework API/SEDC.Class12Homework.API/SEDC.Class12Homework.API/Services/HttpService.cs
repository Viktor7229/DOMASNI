using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SEDC.Class12Homework.API.Services
{
    public class HttpService
    {
        public static string GetData(string url)
        {
            using (HttpClient _http = new HttpClient())
            {
                HttpResponseMessage response = _http.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    HttpContent responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    return responseString;
                }
                else
                {
                    return $"Request Failed! Message: {response.RequestMessage} StatusCode: {response.StatusCode}";
                }
            }

        }
    }
}
