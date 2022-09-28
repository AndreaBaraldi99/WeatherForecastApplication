using System.Text.Json.Serialization;

namespace WeatherForecastLib
{
    public class Result
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }
        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("number")]
        public string Number { get; set; }
        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; }
        [JsonPropertyName("street")]
        public string Street { get; set; }
        [JsonPropertyName("confidence")]
        public double Confidence { get; set; }
        [JsonPropertyName("region")]
        public string Region { get; set; }
        [JsonPropertyName("region_code")]
        public string RegionCode { get; set; }
        [JsonPropertyName("county")]
        public string County { get; set; }
        [JsonPropertyName("locality")]
        public string Locality { get; set; }
        [JsonPropertyName("administrative_area")]
        public string AdministrativeArea { get; set; }
        [JsonPropertyName("neighbourhood")]
        public string Neighbourhood { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }
        [JsonPropertyName("continent")]
        public string Continent { get; set; }
        [JsonPropertyName("label")]
        public string Label { get; set; }
    }
}