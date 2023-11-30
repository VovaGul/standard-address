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
        private readonly CleanClientAsync _cleanClientAsync;

        public StandardAddressController(CleanClientAsync cleanClientAsync)
        {
            _cleanClientAsync = cleanClientAsync;
        }

        [HttpGet(Name = "StandardizeAddress")]
        public async Task<string> StandardizeAddressAsync(string rawAddress)
        {
            var address = await _cleanClientAsync.Clean<Address>(rawAddress);

            if (address.result == null)
            {
                throw new StandardizedAddressException($"не удалось стандартизировать адрес {rawAddress}");
            }

            return address.result;
        }
    }
}
