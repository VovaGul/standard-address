using Dadata;
using Dadata.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;

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
        public async Task StandardizeAddressAsync(string rawAddress)
        {
            var token = _dadataAuth.Token;
            var secret = _dadataAuth.Secret;

            var api = new CleanClientAsync(_dadataAuth.Token, _dadataAuth.Secret);

            var result = await api.Clean<Address>(rawAddress);
        }
    }
}
