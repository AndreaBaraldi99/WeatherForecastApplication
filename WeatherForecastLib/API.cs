using System.Net.Http.Headers;

namespace WeatherForecastLib
{
    internal class API
    {
        public HttpResponseMessage? CallAPI(string url)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try 
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                response = client.GetAsync(url).Result;
            }
            catch(Exception e)
            {
                Console.WriteLine("API call error");
            }
            
            return response;
            
        }
    }
}