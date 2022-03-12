using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace WeatherService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name
    // "IService1" in both code and config file together.
    [ServiceContract]
    public interface IWeatherService
    {

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetWeather?apiKey={apiKey}&lon={lon}&lat={lat}")]
        string GetWeather(string apiKey,string lon, string lat);
        
        // [OperationContract]
        // [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetData?apiKey={apiKey}&q={city}")]
        // string GetWeather(string apiKey,string city);
        
        
        
    }

}