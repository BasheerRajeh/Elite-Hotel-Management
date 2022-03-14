using System.Runtime.Serialization;

namespace WeatherService
{
    [DataContract]
    public class Weather
    {
        [DataMember]
        public string Result { get; set; }
    }
}