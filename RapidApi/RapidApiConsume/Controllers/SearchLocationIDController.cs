using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
    public class SearchLocationIDController : Controller
    {
        public async Task<IActionResult> Index(string cityName)
        {
            //istenen şehrin bilgisini getirme
            if (!string.IsNullOrEmpty(cityName))
            {
                List<BookingApiLoactionSearchViewModel> models = new List<BookingApiLoactionSearchViewModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityName}&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "1445f77dadmsh71bf87484dd9894p18bd76jsn937143b91954" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    models = JsonConvert.DeserializeObject<List<BookingApiLoactionSearchViewModel>>(body);
                    return View(models.Take(1).ToList());
                }
            }
            //default olarak paris şehrinin bilgisini getirme
            else 
            {
                List<BookingApiLoactionSearchViewModel> models = new List<BookingApiLoactionSearchViewModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?name=Paris&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "1445f77dadmsh71bf87484dd9894p18bd76jsn937143b91954" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    models = JsonConvert.DeserializeObject<List<BookingApiLoactionSearchViewModel>>(body);
                    return View(models.Take(1).ToList());
                }
            }
      
        }
    }
}
