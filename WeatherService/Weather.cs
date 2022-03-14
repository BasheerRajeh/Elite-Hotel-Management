using System.Runtime.Serialization;

namespace WeatherService
{
    [DataContract]
    public class Weather
    {
        [DataMember]
        public string Response { get; set; }
    }
}