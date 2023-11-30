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
        public async Task<string> StandardizeAddressAsync(string rawAddress)
        {
            var api = new CleanClientAsync(_dadataAuth.Token, _dadataAuth.Secret);

            var address = await api.Clean<Address>(rawAddress);

            if (address.result == null)
            {
                throw new StandardizedAddressException($"не удалось стандартизировать адрес {rawAddress}");
            }

            return address.result;
        }
    }
}
