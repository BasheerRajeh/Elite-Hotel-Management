using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.AspNetCore.Mvc;

namespace WeatherService
{
    public class WeatherService : IWeatherService
    {
        

        /*
        public string GetWeather(string apiKey, string city)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?appid={apiKey}&q=chicago";


            var httpRequest = (HttpWebRequest) WebRequest.Create(url);

            httpRequest.Accept = "application/json";


            var httpResponse = (HttpWebResponse) httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }

            Console.WriteLine(httpResponse.StatusCode);


            return $"this is lon {5} and this is the lat{6}";
        }
    */
        public string GetWeather(string apiKey, string lon, string lat)
        {
            var url =
                $"http://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={apiKey}";


            var httpRequest = (HttpWebRequest) WebRequest.Create(url);

            httpRequest.Accept = "application/json";


            var httpResponse = (HttpWebResponse) httpRequest.GetResponse();
            string result;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }
    }
}