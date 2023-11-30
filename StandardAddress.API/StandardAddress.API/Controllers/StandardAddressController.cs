using Dadata;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace StandardAddress.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandardAddressController : ControllerBase
    {
        private readonly DadataAuth _dadataAuth;

        public StandardAddressController(IOptions<DadataAuth> options)
        {
            _dadataAuth = options.Value;
        }

        [HttpGet(Name = "StandardizeAddress")]
        public async Task StandardizeAddressAsync()
        {
            var token = _dadataAuth.Token;
            var secret = _dadataAuth.Secret;

            var api = new CleanClientAsync(token, secret);
            // or any of the following, depending on the API method
            var api1 = new SuggestClientAsync(token);
            var api2 = new OutwardClientAsync(token);
            var api3 = new ProfileClientAsync(token, secret);
            return;
        }
    }
}
