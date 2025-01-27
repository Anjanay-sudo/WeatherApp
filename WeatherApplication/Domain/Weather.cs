

namespace WeatherApp.Models
{
    public class WeatherForecast
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Temperature { get; set; }
        public string Wind { get; set; }
        public double WindSpeed { get; set; }
        public double Humidity { get; set; }
        public double Pressure { get; set; }
        public string Cloudliness { get; set; }
        public TimeSpan SunRise { get; set; }
        public TimeSpan SunSet { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
