using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http; //for HttpClient
using System.Net.Http.Headers; //for MediaTypeWithQualityHeaderValue
using System.Threading.Tasks;
using ConsumeWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json; //nugetten indirilmeli for JsonConvert

namespace ConsumeWebApi.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<HotelApi> hotelList = new List<HotelApi>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:63625/api/hotels"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    hotelList = JsonConvert.DeserializeObject<List<HotelApi>>(apiResponse);
                }
            }
            return View(hotelList);
        }

    }
}