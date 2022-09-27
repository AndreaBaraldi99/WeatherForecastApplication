namespace WeatherForecast.DTO
{
    public class WeatherRequest
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } 
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Location { get; set; }
        public int ResponseCode { get; set; }
        public string Data { get; set; }
    }
}