using System;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using code_12.Models;


namespace code_12.Controllers
{
    public class AppController : Controller
    {
        static int counter;

        // 
        // GET: /App/

        public IActionResult Index()
        {
            counter = 0;
            return View();
        }

        // 
        // GET: /App/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }

        // 
        // POST: /App/Start/ 
        public string Start(string button)
        {
            counter++;
            while (counter != 100) counter++;
            Console.Write("--------------------------------------------------------------------------");

            return "App Started "+counter.ToString();
        }


        public async Task<IActionResult> City()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://api.coindesk.com");
                    var response = await client.GetAsync($"/v1/bpi/currentprice.json");
                    response.EnsureSuccessStatusCode();

                    string stringResult = await response.Content.ReadAsStringAsync();

                    var something = JsonConvert.DeserializeObject<ApiResponse>(stringResult);
                    Console.Write(stringResult);

                    return Ok(stringResult);
                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting weather from OpenWeather: {httpRequestException.Message}");
                }
            }
        }

    }
}