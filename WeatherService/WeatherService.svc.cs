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
        public Weather GetWeather(string apiKey, string lon, string lat)
        {
            /*var url =
                $"http://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={apiKey}";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.Accept = "application/json";

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            string result;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return new Weather
            {
                Response = result
            };*/

            return new Weather
            {
                Response = "something"
            };
        }
    }
}