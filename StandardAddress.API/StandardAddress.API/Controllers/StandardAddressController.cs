using Dadata;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StandardAddress.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandardAddressController : ControllerBase
    {

        [HttpGet(Name = "StandardizeAddress")]
        public async Task<IEnumerable<WeatherForecast>> StandardizeAddressAsync()
        {
            var token = "Replace with Dadata API key";
            var secret = "Replace with Dadata secret key";

            var api = new CleanClientAsync(token, secret);
            // or any of the following, depending on the API method
            var api1 = new SuggestClientAsync(token);
            var api2 = new OutwardClientAsync(token);
            var api3 = new ProfileClientAsync(token, secret);
        }
    }
}
