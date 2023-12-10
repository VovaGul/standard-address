using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace StandardAddress.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("OpenCORSPolicy")]
    [ApiController]
    public class StandardAddressController : ControllerBase
    {
        private readonly DadataService _dadataService;
        private readonly IMapper _mapper;
        private readonly ILogger<StandardAddressController> _logger;

        public StandardAddressController(
            DadataService dadataService,
            IMapper mapper,
            ILogger<StandardAddressController> logger)
        {
            _dadataService = dadataService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet(Name = "StandardizeAddress")]
        public async Task<AddressDto> StandardizeAddressAsync(string rawAddress = "мск сухонска 11/-89")
        {
            var address = await _dadataService.CleanAsync(rawAddress);
            var addressDto = _mapper.Map<AddressDto>(address);
            return addressDto;
        }
    }
}
